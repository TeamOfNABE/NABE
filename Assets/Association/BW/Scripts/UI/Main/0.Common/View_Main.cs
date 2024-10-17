using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class View_Main : MonoBehaviour
{
#region View_Profile
    [field : SerializeField] public View_Profile view_Profile { get; private set; }
    public Image profileImg { get => view_Profile.profileImg; }
    public TMP_Text levelText { get => view_Profile.levelText; }
    public TMP_Text nickNameText { get => view_Profile.nickNameText; }
    public Image expImg { get => view_Profile.expImg; }
    public TMP_Text expText { get => view_Profile.expText; }
#endregion

#region View_Currency
    [field : SerializeField] public View_Currency view_Currency { get; private set; }
    public TMP_Text goldText { get => view_Currency.goldText; }
    public TMP_Text diamondText { get => view_Currency.diamondText; }
#endregion

#region View_RoundInfo
    [field : SerializeField] public View_RoundInfo view_RoundInfo { get; private set; }
    public UIItem AcceleratorButton { get => view_RoundInfo.AcceleratorButton; }
    public TMP_Text roundText { get => view_RoundInfo.roundText; }
    public RoundSlider roundSlider { get => view_RoundInfo.roundSlider; }
    public RoundTimer roundTimer { get => view_RoundInfo.roundTimer; }
    public UIItem bossButton { get => view_RoundInfo.bossButton; }
#endregion

#region View_Quick
    [field : SerializeField] public View_Quick view_Quick { get; private set; }
    public UIItem adventureButton { get => view_Quick.adventureButton; }
    public UIItem passButton { get => view_Quick.passButton; }
    public UIItem invisibleButton { get => view_Quick.invisibleButton; }
    public UIItem[] quickButton { get => view_Quick.quickButton; }
    public UIItem quickMinimize { get => view_Quick.quickMinimize; }
#endregion

#region View_Skill
    [field : SerializeField] public View_Skill view_Skill { get; private set; }
    public UIItem autoButton { get => view_Skill.autoButton; }
    public UIItem[] skill { get => view_Skill.skill; }
    public UIItem skillMinimize { get => view_Skill.skillMinimize; }
#endregion

#region View_Equipment
    [field : SerializeField] public View_Equipment view_Equipment { get; private set; }
    public UIItem hat { get => view_Equipment.hat; }
    public UIItem top { get => view_Equipment.top; }
    public UIItem belt { get => view_Equipment.belt; }
    public UIItem cape { get => view_Equipment.cape; }
    public UIItem weapon { get => view_Equipment.weapon; }
    public UIItem decoration { get => view_Equipment.decoration; }
    public UIItem bottom { get => view_Equipment.bottom; }
    public UIItem ring { get => view_Equipment.ring; }
    public UIItem gloves { get => view_Equipment.gloves; }
    public UIItem shell { get => view_Equipment.shell; }
#endregion

#region View_Option
    [field : SerializeField] public View_Option view_Option { get; private set; }
    public UIItem snail { get => view_Option.snail; }
    public UIItem inventory { get => view_Option.inventory; }
    public UIItem promotion { get => view_Option.promotion; }
    public UIItem stat { get => view_Option.stat; }
    public UIItem preset { get => view_Option.preset; }
    public UIItem optionMinimize { get => view_Option.optionMinimize; }
#endregion

#region View_Mission
    [field : SerializeField] public View_Mission view_Mission { get; private set; }
    public UIItem mission { get => view_Mission.mission; }
    public TMP_Text questText { get => view_Mission.questText; }
    public TMP_Text progressText { get => view_Mission.progressText; }
    public TMP_Text rewardText { get => view_Mission.rewardText; }
#endregion

#region View_Gacha
    [field : SerializeField] public View_Gacha view_Gacha { get; private set; }
    public UIItem gacha { get => view_Gacha.gacha; }
    public UIItem gachaLevelButton { get => view_Gacha.gachaLevelButton; }
    public TMP_Text gachaLevelText { get => view_Gacha.gachaLevelText; }
    public TMP_Text countText { get => view_Gacha.countText; }
    public UIItem auto { get => view_Gacha.auto; }
#endregion

#region View_Chat
    [field : SerializeField] public View_Chat view_Chat { get; private set; }
    public UIItem chat { get => view_Chat.chat; }
    public SmallChat[] smallChat { get => view_Chat.smallChat; }
#endregion

#region View_Bottom
    [field : SerializeField] public View_Bottom view_Bottom { get; private set; }
    public UIItem growth { get => view_Bottom.growth; }
    public UIItem dungeon { get => view_Bottom.dungeon; }
    public UIItem duel { get => view_Bottom.duel; }
    public UIItem town { get => view_Bottom.town; }
    public UIItem greenhouse { get => view_Bottom.greenhouse; }
    public UIItem shop { get => view_Bottom.shop; }
#endregion
}