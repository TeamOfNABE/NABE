using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Proto_GachaScenario : MonoBehaviour
{
    public CardDataSet data;

    public RewardUnit rewardObj;
    [SerializeField] List<CardUnit> cardList = new();

    public void SetGUI_byCurrState()
    {
        for (int i = 0; i < 3; i++)
        {
            rewardObj.textObj[i].text = cardList[i].myType.ToString();
        }
    }

    public void SetCardData(int index)
    {
        cardList[index].SetCardData();
        int currData = (int)cardList[index].myType;
        cardList[index].SetCardColor(data.ColorList[currData]);
    }
}

[Serializable]
public class CardUnit
{
    public Image myCardImg;
    public TypeEnum myType;

    public void SetCardData()
    {
        long seed = DateTime.UtcNow.Ticks;
        System.Random random = new System.Random((int)(seed & 0xFFFFFFFF)); // 시드값으로 하위 32비트만 사용

        int count = System.Enum.GetValues(typeof(TypeEnum)).Length;
        int type = random.Next(1, count);
        myType = (TypeEnum)type;
    }

    public void SetCardColor(Color _color)
    {
        Color color = new Color(_color.r, _color.g, _color.b);
        myCardImg.color = color;
    }
}

[Serializable]
public class RewardUnit
{
    public List<TextMeshProUGUI> textObj;
}
