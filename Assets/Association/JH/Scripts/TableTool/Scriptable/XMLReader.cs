using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

[CreateAssetMenu(fileName = "XMLReader", menuName = "ScriptableObjects/XMLReader", order = 2)]
public class XMLReader : ScriptableObject
{
    public string xmlFileName = "data.xml";
    
    private string filePath = "";
    private DateTime lastModifiedTime;
    private Dictionary<string, float[]> cachedData = new();

    // 파일의 수정 날짜를 체크하고, 캐시 여부를 결정
    public float[] GetData(string keyValue)
    {
        if (filePath == "")
        {
            filePath = Path.Combine(Application.streamingAssetsPath, xmlFileName);
            lastModifiedTime = File.GetLastWriteTime(filePath);
        }

        DateTime currentModifiedTime = File.GetLastWriteTime(filePath);

        // 캐시가 유효한 경우
        if (currentModifiedTime == lastModifiedTime && cachedData.ContainsKey(keyValue))
        {
            Debug.Log("Using cached data");
            return cachedData[keyValue];
        }

        // 새로운 데이터 읽기
        Debug.Log("Reading new data from file");
        ReadDataFromFile();
        lastModifiedTime = currentModifiedTime;

        return cachedData.TryGetValue(keyValue, out var data) ? data : null;
    }

    private void ReadDataFromFile()
    {
        cachedData.Clear();

        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (XmlReader reader = XmlReader.Create(fs))
        {
            while (reader.Read())
            {
                // Row를 찾아서 데이터 읽기
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Row")
                {
                    ReadRowData(reader);
                }
            }
        }
    }

    private void ReadRowData(XmlReader reader)
    {
        string aryname = null;
        List<float> rowValues = new List<float>();

        // Row의 모든 Cell을 반복적으로 처리
        while (reader.Read())
        {
            // Row의 끝에 도달했는지 확인
            if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Row")
            {
                break; // Row의 끝이면 종료
            }

            // Cell을 찾으면 그 안의 Data 읽기
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Cell")
            {
                if (reader.ReadToDescendant("Data"))
                {
                    string dataType = reader.GetAttribute("ss:Type");

                    if (aryname == null) // 첫 번째 셀 (aryname)
                    {
                        aryname = reader.ReadElementContentAsString(); // 첫 번째 셀 (aryname)
                    }
                    else if (dataType == "Number") // 이후 셀은 Number 타입 처리
                    {
                        float value = float.Parse(reader.ReadElementContentAsString());
                        rowValues.Add(value); // 나머지 숫자 값들
                    }
                }
            }
        }

        // 유효한 aryname과 값이 있을 경우 캐시 저장
        if (aryname != null && rowValues.Count > 0)
        {
            cachedData[aryname] = rowValues.ToArray(); // aryname - float[] 저장
        }
    }
}
