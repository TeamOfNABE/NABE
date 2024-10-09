using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    public string filePath = "Assets/YourCSVFile.csv";  // CSV 파일 경로

    [ContextMenu("exe")]
    void Execute()
    {
        List<float[]> floatList = ReadCSV(filePath);
        PrintFloatArrays(floatList);
    }

    List<float[]> ReadCSV(string path)
    {
        List<float[]> data = new List<float[]>();
        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // 쉼표로 구분된 문자열을 float로 변환
                    string[] values = line.Split(',');
                    float[] floatValues = Array.ConvertAll(values, float.Parse);
                    data.Add(floatValues);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error reading the CSV file: " + e.Message);
        }
        return data;
    }

    void PrintFloatArrays(List<float[]> floatList)
    {
        foreach (float[] floatArray in floatList)
        {
            string output = string.Join(", ", floatArray);
            Debug.Log(output);
        }
    }
}
