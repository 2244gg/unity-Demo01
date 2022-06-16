/*
--FileInfo:
--Author:
--CreateTime:2022-05-01-15:47:24
--Description:����UI
*/
using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobbyView : GameView
{
    private Image headImage;
    private Text playerNameText;

    private Text AgNumText;
    //��������
    private Button classChessBtn;
    //����ģʽ
    private Button entertainModeBtn;
    //�̳�
    private Button marketBtn;
    //����
    private Button bagBtn;
    //��Ч
    private Button audioSettingBtn;
    //����
    private Button qualityBtn;
    //����
    private Button ruleBtn;
    //����
    private Button aboutBtn;

    private LobbyModel lobbyModel;
    // private Button marketBtn;
    public override IArchitecture GetArchitecture() // -+
    {
        return base.GetArchitecture();
    }
    public UILobbyView(IArchitecture achiture) : base(achiture)
    {

    }
    public override string PrefabPath()
    {
        string path = "";
        path = "Assets/GameData/Prefabs/Lobby/Panel_Lobby.prefab";
        return path;
    }
    public override void Start()
    {
        // ��ȡ
        lobbyModel = this.GetModel<LobbyModel>(); // -+
        // UI���ʼ��
        Init();
       
    }
    private void Init()
    {
/*        for(int i=0;i<this.mObj.transform.childCount;i++)
        {
            var temp = this.mObj.transform.GetChild(i);
            for (int j = 0; j < this.mObj.transform.GetChild(i).childCount; j++)
            {
                var temp2 = this.mObj.transform.GetChild(i).GetChild(j);
                this.playerNameText = temp2.transform.Find("Text_Name").GetComponent<Text>();
            }
        }*/
        
        this.headImage = this.mObj.transform.Find("AnchorLeftUpper/Panel_Person/Panel_PersonImg/RawImage/ImageHead").GetComponent<Image>();
        this.playerNameText = this.mObj.transform.Find("AnchorLeftUpper/Panel_Person/Text_Name").GetComponent<Text>();
        this.classChessBtn = this.mObj.transform.Find("AnchorCenter/Panel_ModeSelect/Content/Viewport/Content/BtnClass").GetComponent<Button>();
        this.entertainModeBtn = this.mObj.transform.Find("AnchorCenter/Panel_ModeSelect/Content/Viewport/Content/BtnEnjoying").GetComponent<Button>();
        this.marketBtn = this.mObj.transform.Find("AnchorCenterDown/Panel_Func/Content/BtnMarket").GetComponent<Button>();
        this.bagBtn = this.mObj.transform.Find("AnchorCenterDown/Panel_Func/Content/BtnBag").GetComponent<Button>();
        this.audioSettingBtn = this.mObj.transform.Find("AnchorCenterDown/Panel_Func/Content/BtnAudio").GetComponent<Button>();
        this.qualityBtn = this.mObj.transform.Find("AnchorCenterDown/Panel_Func/Content/BtnQuality").GetComponent<Button>();
        this.ruleBtn = this.mObj.transform.Find("AnchorCenterDown/Panel_Func/Content/BtnRule").GetComponent<Button>();
        this.aboutBtn = this.mObj.transform.Find("AnchorCenterDown/Panel_Func/Content/BtnAbout").GetComponent<Button>();

        this.classChessBtn.onClick.AddListener(ClassChessModeOnclick);
        this.entertainModeBtn.onClick.AddListener(EntertainModeOnclick);
        this.marketBtn.onClick.AddListener(MarketOnclick);
        this.bagBtn.onClick.AddListener(BagOnclick);
        this.audioSettingBtn.onClick.AddListener(AudioOnclick);
        this.qualityBtn.onClick.AddListener(QualityOnclick);
        this.aboutBtn.onClick.AddListener(AboutOnclick);
        this.ruleBtn.onClick.AddListener(RuleOnclick);
    }
    #region ��ť�¼�
    private void ClassChessModeOnclick()
    {
        LobbyBtnAction lobbyBtnAction = new LobbyBtnAction();
        lobbyBtnAction.btnAction = ELobbyBtnAction.classChessMode;
        GetArchitecture().SendEvent<LobbyBtnAction>(lobbyBtnAction);
    }
    private void EntertainModeOnclick()
    {
        LobbyBtnAction lobbyBtnAction = new LobbyBtnAction();
        lobbyBtnAction.btnAction = ELobbyBtnAction.entertainMode;
        GetArchitecture().SendEvent<LobbyBtnAction>(lobbyBtnAction);
    }
    private void MarketOnclick()
    {
        LobbyBtnAction lobbyBtnAction = new LobbyBtnAction();
        lobbyBtnAction.btnAction = ELobbyBtnAction.market;
        GetArchitecture().SendEvent<LobbyBtnAction>(lobbyBtnAction);
    }
    private void BagOnclick()
    {
        LobbyBtnAction lobbyBtnAction = new LobbyBtnAction();
        lobbyBtnAction.btnAction = ELobbyBtnAction.bag;
        GetArchitecture().SendEvent<LobbyBtnAction>(lobbyBtnAction);
    }
    private void AudioOnclick()
    {
        LobbyBtnAction lobbyBtnAction = new LobbyBtnAction();
        lobbyBtnAction.btnAction = ELobbyBtnAction.audioSetting;
        GetArchitecture().SendEvent<LobbyBtnAction>(lobbyBtnAction);
    }
    private void QualityOnclick()
    {
        LobbyBtnAction lobbyBtnAction = new LobbyBtnAction();
        lobbyBtnAction.btnAction = ELobbyBtnAction.quality;
        GetArchitecture().SendEvent<LobbyBtnAction>(lobbyBtnAction);
    }
    private void RuleOnclick()
    {
        LobbyBtnAction lobbyBtnAction = new LobbyBtnAction();
        lobbyBtnAction.btnAction = ELobbyBtnAction.rule;
        GetArchitecture().SendEvent<LobbyBtnAction>(lobbyBtnAction);
    }
    private void AboutOnclick()
    {
        LobbyBtnAction lobbyBtnAction = new LobbyBtnAction();
        lobbyBtnAction.btnAction = ELobbyBtnAction.about;
        GetArchitecture().SendEvent<LobbyBtnAction>(lobbyBtnAction);
    }

    #endregion
}
