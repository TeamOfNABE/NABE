using DataSet;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] internal ManagingEnumData<VisualType_String, string> _VisualDataDBG = new();
    [SerializeField] internal ManagingEnumData<CurrencyType_Int,int> _CurrencyDBG = new();

    public ManagingEnumData<CurrencyType_Int, int> Currency { get { return _CurrencyDBG; } }
    public ManagingEnumData<VisualType_String, string> VisualData { get { return _VisualDataDBG; } }
}

public interface IManagingDataHandler<TEnum, T>
{
    void AddEvent(TEnum type, Action<T> interactFunc);

    void RemoveEvent(TEnum type, Action<T> interactFunc);

    T Get(TEnum type);

    void Set(TEnum type, T value);
}