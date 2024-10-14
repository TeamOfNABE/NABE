using ProtoGacha_FuncSet;
using System.Collections.Generic;
using UnityEngine;

public class GachaDataManager : MonoBehaviour
{
    Handler_CardGacha _CardGachaHandler;  public iGachaProcessHandler<FactoryData_MainGacha, ProductData_CardGacha> gh_card => _CardGachaHandler;
    Handler_EquipItemGacha _EquipItemGacha; public iGachaProcessHandler<FactoryData_MainGacha, ProductData_CardGacha> gh_equip => _CardGachaHandler;

    [SerializeField] FactoryData_MainGacha factoryData;

    [Space(10)]
    [SerializeField] public List<ProductData_EquipItem> myItems;

    [ContextMenu("InteractGacha")]
    public void InteractGacha()
    {
        ProductData_CardGacha insData = new();
        _CardGachaHandler = new(factoryData, insData);
        gh_card.ExecuteGacha();
        _CardGachaHandler = null;
    }


    [ContextMenu("MergeItem_byCards")]
    public void MergeItem_byCards()
    {
        if (factoryData._cardData.Count < 3)
            return;

        ProductData_EquipItem temp = new ProductData_EquipItem(factoryData);
        myItems.Add(temp);
        factoryData.AddFeverPercent_byCreateItem(temp);

        factoryData._cardData.Clear();
    }
}
