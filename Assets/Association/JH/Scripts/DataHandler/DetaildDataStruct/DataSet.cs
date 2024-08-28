using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSet
{
    public interface IProfileData
    {
        string ServerName { get; set; }
        string UID { get; set; }

        Sprite ProfileImg { get; set; }
        string Name { get; set; }

        GenderSet Gender { get; set; }
        MbtiSet Mbti { get; set; }
        LivePlaceSet LivePlace { get; set; }
        string IntroduceComment { get; set; }


        Sprite SubProfile_1 { get; set; }
        Sprite SubProfile_2 { get; set; }
        Sprite SubProfile_3 { get; set; }

        InterestFlagSet InterestFlag { get; set; }

        VisualDataSet VisualData { get; set; }
    }

    public interface ICurrencyDataHandler
    {
        void AddEvent(CurrencyType_Int type, Action<int> interactFunc);


        int Get(CurrencyType_Int type);

        void Set(CurrencyType_Int type, int value);

    }
}



public enum CurrencyType_Int
{
    Gold,
    Diamond,
    Ruby,
    Ticket_0,
    Ticket_1,
    Ticket_2
}

public enum VisualType
{
    BaseCostume,
    BaseJob,
    BaseColor,
    WeaponType,
    DecorHair,
    DecorFace,
    PersonalityTitle,
    PersonalityFrame,
    PersonalityBubble,
    MiscMount,
    Costume
}


[Serializable]
public class VisualDataSet
{
    public int BaseCostume { get; set; }          // 기본 - 코스튬
    public int BaseJob { get; set; }              // 기본 - 직업
    public int BaseColor { get; set; }            // 기본 - 발색
    public int WeaponType { get; set; }           // 무기 - 일반 or 신물
    public int DecorHair { get; set; }            // 꾸밈 - 머리
    public int DecorFace { get; set; }            // 꾸밈 - 얼굴
    public int PersonalityTitle { get; set; }     // 개성 - 칭호
    public int PersonalityFrame { get; set; }     // 개성 - 프레임
    public int PersonalityBubble { get; set; }    // 개성 - 말풍선
    public int MiscMount { get; set; }            // 기타 – 탈것
    public int Costume { get; set; }              // 코스튬
}
