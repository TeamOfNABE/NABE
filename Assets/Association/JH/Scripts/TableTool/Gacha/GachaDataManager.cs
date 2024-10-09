using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GachaStoreData
{
    public FloatArrayData table;
    public int gachaStoreLevel;
    public int gachaCombo;
    public float feverPer;

    public List<int> _cardData;
}

public class GachaDataManager : MonoBehaviour
{
    MyGachaHandler myGachaHandler;
    public iGachaProcessHandler<GachaStoreData, SampleResultData> mGH => myGachaHandler;
    [SerializeField] SampleResultData data;
    [SerializeField] GachaStoreData myData;
    
    [Space(10)]
    [SerializeField] public List<GachaData_ItemUnit> myItems;

    [ContextMenu("InteractGacha")]
    public void InteractGacha()
    {
        myGachaHandler = new(myData, data);
        myData._cardData.Add(myGachaHandler.ResultData.rtnIndex);
        mGH.ExcuteGacha();
    }


    [ContextMenu("MergeItem_byCards")]
    public void MergeItem_byCards()
    {
        if (myData._cardData.Count < 3)
            return;

        GachaData_ItemUnit temp = new GachaData_ItemUnit(myData);
        myItems.Add(temp);
        myData._cardData.Clear();
    }
}

[Serializable]
public class SampleResultData
{
    public string ResultName;
    public int rtnIndex;
}

[Serializable]
public class GachaData_ItemUnit
{
    public Vector3Int _cardData;
    public int _GachaStoreLevel;
    public bool isFever;

    public GachaData_ItemUnit(GachaStoreData _slotData)
    {
        var temp = _slotData._cardData;
        if (temp.Count < 2)
        {
            return;
        }

        _cardData.x = temp[0];
        _cardData.y = temp[1];
        _cardData.z = temp[2];

        _slotData._cardData = temp;
        _GachaStoreLevel = _slotData.gachaStoreLevel;
    }
}


class MyGachaHandler : iGachaProcessHandler<GachaStoreData, SampleResultData>
{
    #region impliement
    public GachaStoreData myData => _myData;
    public SampleResultData ResultData => _ResultData;

    GachaStoreData _myData;
    SampleResultData _ResultData;
    #endregion

    public MyGachaHandler(GachaStoreData input_myData, SampleResultData input_ResultData)
    {
        _myData = input_myData;
        _ResultData = input_ResultData;
    }

    public bool AvailableCheck()
    {
        if(_myData.table == null)
            return false;

        Debug.Log("AvailableCheck");
        return true;
    }

    public float[] GetTargetTable(GachaStoreData myData)
    {
        return myData.table.SnowballForm;
    }

    public void NotAvailableAction()
    {
        _ResultData.ResultName = "NotAvailableAction";
        Debug.Log("NotAvailableAction");
    }

    public SampleResultData SetReturnData(int returnValue)
    {
        if (_ResultData == null)
        {
            _ResultData = new();
        }
        _ResultData.rtnIndex = returnValue;
        Debug.Log("NotAvailableAction " + returnValue);
        return _ResultData;
    }

    public void ApplyResult(SampleResultData _ReturnData)
    {
        _ResultData.ResultName = "ApplyResult";
        _myData.gachaCombo++;
        Debug.Log("ApplyResult");
    }

    public void SetTicketDelta()
    {
        Debug.Log("SetTicketDelta");
    }

    public void SuccessAction(SampleResultData _ReturnData)
    {
        Debug.Log("SuccessAction "  + _myData.gachaCombo + " / " + _myData.gachaStoreLevel);
    }
}


