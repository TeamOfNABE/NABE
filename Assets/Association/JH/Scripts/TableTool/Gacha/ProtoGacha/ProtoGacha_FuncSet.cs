using ProtoGacha_Additional;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ProtoGacha_FuncSet
{
    class MyGachaHandler : iGachaProcessHandler<FactoryData_ofGacha, ItemData_byGacha>
    {
        #region impliement
        public FactoryData_ofGacha factoryData => _factoryData;
        FactoryData_ofGacha _factoryData;

        ItemData_byGacha _insData;
        #endregion

        public MyGachaHandler(FactoryData_ofGacha input_myData, ItemData_byGacha input_ResultData)
        {
            _factoryData = input_myData;
            _insData = input_ResultData;
        }

        public bool AvailableCheck()
        {
            if (_factoryData.table == null)
                return false;

            return true;
        }

        public float[] GetTargetTable(FactoryData_ofGacha myData)
        {
            return myData.table.SnowballForm;
        }

        public void NotAvailableAction()
        {
            _insData.ResultName = "NotAvailableAction";
        }

        public ItemData_byGacha SetReturnData(int returnValue)
        {
            if (_insData == null)
            {
                _insData = new();
            }

            _insData.rtnIndex = returnValue;
            //Debug.Log("SetReturnData " + returnValue);
            return _insData;
        }

        public void ApplyResult(ItemData_byGacha _ReturnData)
        {
            factoryData._cardData.Add(_insData.rtnIndex);
            _insData.ResultName = "ApplyResult";
            //_factoryData.gachaCombo++;

            //_GachaStoreData.feverPer;
            //Debug.Log("ApplyResult");
        }

        public void SetTicketDelta()
        {
            //Debug.Log("SetTicketDelta");
        }

        public void SuccessAction_GUI(ItemData_byGacha _ReturnData)
        {
            //Debug.Log("SuccessAction "  + _factoryData.gachaCombo + " / " + _factoryData.gachaStoreLevel);
        }
    }


    [Serializable]
    public class GachaData_ItemUnit
    {
        public Vector3Int _cardData;
        public int _GachaStoreLevel;
        public bool isFever;

        public GachaData_ItemUnit(FactoryData_ofGacha _slotData)
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

    [Serializable]
    public class ItemData_byGacha
    {
        public string ResultName;
        public int rtnIndex;
    }

    [Serializable]
    public class FactoryData_ofGacha
    {
        public FloatArrayData table;
        public int gachaStoreLevel;
        public int gachaCombo;
        public float percent_Gacha;
        public List<int> _cardData;


        FeverHandler feverObj = new();
        public float FeverPer => feverObj.GetFeverPercent();
        public bool IsFeverTime => feverObj.IsFeverTime();


        public bool isStored;
        public void AddFeverPercent_byCreateItem(GachaData_ItemUnit item)
        {
            feverObj.AddFeverPercent_byCreateItem(1f / ((int)MathF.Max(gachaStoreLevel, 1) + 2));
            percent_Gacha = Mathf.Round(FeverPer * 100) / 100.0f;

            isStored = feverObj.GetIsStored();
        }
    }

}
