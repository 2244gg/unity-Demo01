using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoObjController
{
    private LoginModel model;
    private LoginPanelView loginPanelView;
    public LoginController(IArchitecture achiture) : base(achiture)
    {

    }
    public override IArchitecture GetArchitecture() // -+
    {
        return base.GetArchitecture();
    }
    public override void OnEnter()
    {
        base.OnEnter();
        model = (LoginModel)this.GetModel<ILoginModel>();
        model.NetLoginRes += LoginRes;
        model.NetRegisterRes += RegisterRes;
        loginPanelView = new LoginPanelView(this.mAchiture);
        this.CreateObj<LoginPanelView>(loginPanelView, GameNodes.Instance.canvas);
        this.monoObjs.Add(loginPanelView);
        loginPanelView.Start();

        EventInit();
    }
    public override void OnExit()
    {
        base.OnExit();
        GetArchitecture().UnRegisterEvent<S_LoginBtnAction>(BtnActionHandle);
    }
    #region 事件
    private void EventInit()
    {
        GetArchitecture().RegisterEvent<S_LoginBtnAction>(BtnActionHandle);
    }
    private void BtnActionHandle(S_LoginBtnAction btnAction)
    {
        switch (btnAction.btnAction)
        {
            case ELoginBtnAction.None:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            case ELoginBtnAction.Login:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            case ELoginBtnAction.Register:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            case ELoginBtnAction.Visitor:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    //登录模块压入
                    ModuleState.Instance.PushSystemModule(EModuleState.Lobby);
                    break;
                }
            case ELoginBtnAction.Exit:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            case ELoginBtnAction.EnterGame:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            default:
                break;

        }
    }
    #endregion

    #region 网络
    private void  LoginRes(int resCode)
    {
        if(resCode==1)
        {
            Debug.Log("登录成功！");
        } else
        {
            loginPanelView.LoginPanelReset();
        }
    }
    private void RegisterRes(int resCode)
    {
        if (resCode == 1)
        {
            Debug.Log("注册成功！");
        }
        else
        {
            loginPanelView.RegisterPanelReset();
        }
    }
    #endregion

    /*private LoginModel mLoginModel;

    private Button btnEnterGame;
    private Button btnRegister;
    private Button btnLogin;
    private Button btnVisitorLogin;
    private Button btnExit;
    private Transform panelLogin;
    private Transform panelRegister;
    public LoginController(IArchitecture achiture):base(achiture)
    {
        
    }
    private void Init()
    {
        LogTool.Print(this, "Init");
        btnEnterGame = this.mObj.transform.Find("BtnEnterGame").GetComponent<Button>();
        btnRegister = this.mObj.transform.Find("BtnRegister").GetComponent<Button>();
        btnLogin = this.mObj.transform.Find("BtnLogin").GetComponent<Button>();
        btnVisitorLogin = this.mObj.transform.Find("BtnVisitorLogin").GetComponent<Button>();
        btnExit = this.mObj.transform.Find("BtnExit").GetComponent<Button>();
        panelLogin = this.mObj.transform.Find("Panel_Login");
        panelRegister = this.mObj.transform.Find("Panel_Register");

        btnEnterGame.onClick.AddListener(BtnEnterGameOnclick);
        btnRegister.onClick.AddListener(BtnRegisterOnclick);
        btnLogin.onClick.AddListener(BtnLoginOnclick);
        btnVisitorLogin.onClick.AddListener(BtnVisitorOnclik);
        btnExit.onClick.AddListener(BtnExitOnclick);

        LoginInfoInit();
        RegisterInfoInit();
    }
    public override string PrefabPath()
    {
        string path = "";
        path = "Assets/GameData/Prefabs/Login.prefab";
        return path;
    }

    public override void Start()
    {
        // 获取
        mLoginModel = this.GetModel<LoginModel>(); // -+
        // UI层初始化
        Init();
*//*        // 注册
        mLoginModel.userName.OnValueChanged += OnCountChanged;

        transform.Find("BtnAdd").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                    // 交互逻辑
                    this.SendCommand<AddCountCommand>(); // -+
                });

        transform.Find("BtnSub").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                    // 交互逻辑
                    this.SendCommand<SubCountCommand>(); // -+
                });

        OnCountChanged(mLoginModel.Count.Value);*//*
    }

    // 表现逻辑
    private void OnCountChanged(int newValue)
    {
        LogTool.Print(this, "OnCountChanged");
        this.mObj.transform.Find("CountText").GetComponent<Text>().text = newValue.ToString();
    }
    
    void BtnLoginOnclick()
    {
        LogTool.Print(this, "BtnLoginOnclick");
        panelLogin.gameObject.SetActive(true);
    }
    void BtnRegisterOnclick()
    {
        LogTool.Print(this, "BtnRegisterOnclick");
        panelRegister.gameObject.SetActive(true);
    }
    void BtnVisitorOnclik()
    {
        LogTool.Print(this, "BtnVisitorOnclik");
    }
    void BtnExitOnclick()
    {
        LogTool.Print(this, "BtnExitOnclick");
    }
    void BtnEnterGameOnclick()
    {
        LogTool.Print(this, "BtnEnterGameOnclick");
    }
    #region LoginPanel
    private InputField loginUserNameInput; 
    private InputField loginUserPassWordInput;
    private Button btnResetLoginInfo;
    private Button btnLoginInfo;
    private Button closeLoginPanel;
    void BtnRestLoginInfo()
    {
        LogTool.Print(this, "BtnRestLoginInfo");
        LoginPanelReset();
    }
    void BtnLoginInfo()
    {
        LogTool.Print(this, "BtnLoginInfo");
    }
    void LoginPanelReset()
    {
        LogTool.Print(this, "LoginPanelReset");
        loginUserNameInput.text = "";
        loginUserPassWordInput.text = "";
    }
    void BtnCloseLoginPanel()
    {
        LogTool.Print(this, "BtnCloseLoginPanel");
        LoginPanelReset();
        panelLogin.gameObject.SetActive(false);
    }
    void LoginInfoInit()
    {
        LogTool.Print(this, "LoginInfoInit");
        loginUserNameInput = this.mObj.transform.Find("Panel_Login/Panel_Login/Panel_Name/InputField").GetComponent<InputField>();
        loginUserPassWordInput = this.mObj.transform.Find("Panel_Login/Panel_Login/Panel_Psd/InputField").GetComponent<InputField>();
        btnResetLoginInfo = this.mObj.transform.Find("Panel_Login/BtnReset").GetComponent<Button>();
        btnLoginInfo = this.mObj.transform.Find("Panel_Login/BtnLogin").GetComponent<Button>();
        closeLoginPanel = this.mObj.transform.Find("Panel_Login/BtnBack").GetComponent<Button>();
        btnResetLoginInfo.onClick.AddListener(BtnRestLoginInfo);
        btnLoginInfo.onClick.AddListener(BtnLoginInfo);
        closeLoginPanel.onClick.AddListener(BtnCloseLoginPanel);
    }
    #endregion

    #region RegisterPanel
    private InputField RegisterUserNameInput;
    private InputField RegisterUserPassWordInput;
    private InputField RegisterReUserPassWordInput;
    private InputField RegisterEMailInput;
    private ToggleGroup RegisterGenderToggle;
    private Toggle RegisterBoyToggle;
    private Button btnResetRegisterInfo;
    private Button btnRegisterInfo;
    private Button closeRegisterPanel;
    void BtnRestRegisterInfo()//重置
    {
        LogTool.Print(this, "BtnRestRegisterInfo");
        RegisterPanelReset();
    }
    void BtnRegisterInfo()//注册
    {
        LogTool.Print(this, "BtnRegisterInfo");
        string userName = RegisterUserNameInput.text;
        string userPsw = RegisterUserPassWordInput.text;
        string userMail = RegisterEMailInput.text;
        bool gender = RegisterBoyToggle.isOn;
        // 交互逻辑
        this.SendCommand<LoginSetInfoCommand>(new LoginSetInfoCommand(userName,userPsw,userMail,gender)); // -+
    }    
    void BtnCloseRegisterPanel()//关闭
    {
        LogTool.Print(this, "BtnCloseRegisterPanel");
        RegisterPanelReset();
        panelRegister.gameObject.SetActive(false);
    }
    void RegisterPanelReset()
    {
        LogTool.Print(this, "RegisterPanelReset");
        RegisterUserNameInput.text = "";
        RegisterUserPassWordInput.text = "";
        RegisterReUserPassWordInput.text = "";
        RegisterEMailInput.text = "";
        RegisterBoyToggle.isOn = true;
    }
    void RegisterInfoInit()
    {
        LogTool.Print(this, "RegisterInfoInit");
        RegisterUserNameInput = this.mObj.transform.Find("Panel_Register/Panel_RegisterInfo/Panel_Name/InputField").GetComponent<InputField>();
        RegisterUserPassWordInput = this.mObj.transform.Find("Panel_Register/Panel_RegisterInfo/Panel_Psd/InputField").GetComponent<InputField>();
        RegisterReUserPassWordInput = this.mObj.transform.Find("Panel_Register/Panel_RegisterInfo/Panel_RePsd/InputField").GetComponent<InputField>();
        RegisterEMailInput = this.mObj.transform.Find("Panel_Register/Panel_RegisterInfo/Panel_Mail/InputField").GetComponent<InputField>();
        RegisterBoyToggle = this.mObj.transform.Find("Panel_Register/Panel_RegisterInfo/Panel_Sex/Panel/boy").GetComponent<Toggle>();

        btnResetRegisterInfo = this.mObj.transform.Find("Panel_Register/BtnReset").GetComponent<Button>();
        btnRegisterInfo = this.mObj.transform.Find("Panel_Register/BtnRegister").GetComponent<Button>();
        closeRegisterPanel = this.mObj.transform.Find("Panel_Register/BtnBack").GetComponent<Button>();

        btnResetRegisterInfo.onClick.AddListener(BtnRestRegisterInfo);
        btnRegisterInfo.onClick.AddListener(BtnRegisterInfo);
        closeRegisterPanel.onClick.AddListener(BtnCloseRegisterPanel);
    }
    #endregion
    private void OnDestroy()
    {
        // 注销
       // mLoginModel.Count.OnValueChanged -= OnCountChanged;

        mLoginModel = null;
    }

    public override IArchitecture GetArchitecture() // -+
    {
        return base.GetArchitecture();
    }*/
}
