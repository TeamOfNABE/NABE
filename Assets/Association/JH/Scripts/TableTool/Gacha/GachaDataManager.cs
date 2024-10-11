using ProtoGacha_FuncSet;
using System.Collections.Generic;
using UnityEngine;

public class GachaDataManager : MonoBehaviour
{
    MyGachaHandler myGachaHandler;
    public iGachaProcessHandler<FactoryData_ofGacha, ItemData_byGacha> mGH => myGachaHandler;
    [SerializeField] FactoryData_ofGacha factoryData;
    [SerializeField] ItemData_byGacha insData_Debug;

    [Space(10)]
    [SerializeField] public List<GachaData_ItemUnit> myItems;

    [ContextMenu("InteractGacha")]
    public void InteractGacha()
    {
        ItemData_byGacha insData = new();
        myGachaHandler = new(factoryData, insData);
        mGH.ExecuteGacha();
    }


    [ContextMenu("MergeItem_byCards")]
    public void MergeItem_byCards()
    {
        if (factoryData._cardData.Count < 3)
            return;

        GachaData_ItemUnit temp = new GachaData_ItemUnit(factoryData);
        myItems.Add(temp);
        factoryData.AddFeverPercent_byCreateItem(temp);


        factoryData._cardData.Clear();
    }
}
