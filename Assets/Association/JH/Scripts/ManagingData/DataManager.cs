using DataSet;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] internal ManagingCurrencyInt _CurrencyDBG = new();
    [SerializeField] internal ManagingVisualTypeString _VisualDataDBG = new();

    public IManagingDataHandler<CurrencyType_Int,int> Currency { get { return _CurrencyDBG; } }
    public IManagingDataHandler<VisualType_String, string> VisualData { get { return _VisualDataDBG; } }
}