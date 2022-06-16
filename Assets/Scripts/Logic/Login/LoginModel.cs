using FrameworkDesign;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoginModel : IModel
{
    BindableProperty<string> Id { get; }
}
public class RegisterData {
    public string uerName = "";
    public string passWord = "";
    public string userMail = "";
    public bool uerGender = false;
    public RegisterData()
    {

    }
    public RegisterData(string uerName, string passWord, string userMail, bool uerGender)
    {
        this.uerName = uerName;
        this.passWord = passWord;
        this.userMail = userMail;
        this.uerGender = uerGender;
    }

    public void Reset()
    {
          uerName = "";
      passWord = "";
      userMail = "";
      uerGender = false;
    }
}
public class LoginData
{
    public string uerName = "";
    public string passWord = "";
    public LoginData(){}
    public LoginData(string uerName, string passWord) {
        this.uerName = uerName;
        this.passWord = passWord;
    }
    public void Reset()
    {
        uerName = "";
        passWord = "";
    }
}
public class LoginModel : AbstractModel, ILoginModel
{

    private RegisterData curRegisterData;

    private LoginData curLoginData;
    //网络回传
    //AccountHandler userHandler;
    public Action<int> NetLoginRes;
    public Action<int> NetRegisterRes;
    public BindableProperty<string> Id { get; } = new BindableProperty<string> { Value="000000" };
    public BindableProperty<int> userDefeat { get; } = new BindableProperty<int> { Value = 0 };
    public LoginModel()
    {
        
    }


    protected override void OnInit()
    {
        /*userHandler = (AccountHandler)NetService.Instance.netMessages.account;
        userHandler.UserLogin += LoginRes;
        userHandler.UserRegister += RegisterRes;*/
        curRegisterData = new RegisterData();
        curLoginData = new LoginData();
    }

    public void SetRegisterInfo(RegisterData registerData)
    {
        this.curRegisterData = registerData;
    }
    public void SetLoginInfo(LoginData loginData)
    {
        this.curLoginData = loginData;
    }


    #region 网络
   /* public void LoginReq()
    {
        if (curLoginData != null)
        {
            // AudioCtrl.instance.PlayAudioTip(ClipStyle.buttonClick);
            //判断非空有值且无其它特殊字符
            if (!string.IsNullOrEmpty(curLoginData.uerName))
            {
                if (!string.IsNullOrEmpty(curLoginData.passWord))
                {
                    //联网验证禁止用户操作
                    AccountDTO account = new AccountDTO(curLoginData.uerName, curLoginData.passWord);
                    *//*account.uid = userName;
                    account.upwd = userPsd;*//*
                    NetIO.Instance.Write(Protocol.Accaount, 1, AccountProtocol.Login_CREQ, account);

                    return;

                }
                //提示输入密码
                // FindObjectOfType<MsgBox>().ShowSingleMsg(transform, "请输入密码", 1);
                return;
            }
            //提示输入名字
            // FindObjectOfType<MsgBox>().ShowSingleMsg(transform, "请输入名字", 1);
        }
    }
    public void RegisterReq()
    {
        // AudioCtrl.instance.PlayAudioTip(ClipStyle.buttonClick);
        if (!string.IsNullOrEmpty(curRegisterData.uerName))
        {
            if (!string.IsNullOrEmpty(curRegisterData.passWord))
            {
                if (!string.IsNullOrEmpty(curRegisterData.userMail) && curRegisterData.userMail.Contains(".com") && curRegisterData.userMail.Contains("@"))
                {
                    int sexId = 0;
                    if (curRegisterData.uerGender)//女
                        sexId = 1;

                    //联网检查看用户名是否重名等,禁止用户操作
                    AccountDTO account = new AccountDTO(curRegisterData.uerName, curRegisterData.passWord, sexId, curRegisterData.userMail);
                    NetIO.Instance.Write(Protocol.Accaount, 1, AccountProtocol.Reg_CREQ, account);
                    return;
                    //注册成功，跳转登录页面

                }
                //提示邮箱格式错误
                //FindObjectOfType<MsgBox>().ShowSingleMsg(transform, "邮箱格式错误", 1);

            }
            //提示请输入密码
            //FindObjectOfType<MsgBox>().ShowSingleMsg(transform, "请输入密码", 1);
            return;
        }
        //提示请输入用户名
        // FindObjectOfType<MsgBox>().ShowSingleMsg(transform, "请输入用户名", 1);
    }
    //登录网络判断--接收服务器登录结果
    void LoginRes(SocketModel i)
    {
        int resCode = 1;
        //错误
        if (i.message.GetType() == typeof(int))
        {
             resCode = i.GetMessage<int>();
            switch (resCode)
            {
                case -1:
                    {
                        Debug.Log("登陆失败！");
                        break;
                    }
                case -2:
                    {
                        Debug.Log("没有此账号！");
                        break;
                    }
                case -3:
                    {
                        Debug.Log("密码错误！");
                        break;
                    }
                case -4:
                    {
                        Debug.Log("账号已登录！");
                        break;
                    }
            }
        }
        else
        {
            Debug.Log("登录成功！");
            resCode = 1;
        }
        NetLoginRes(resCode);
    }
    //注册网络判断--接收服务器注册结果
    void RegisterRes(SocketModel i)
    {
        int resCode = 1;
        if (i.message.GetType() == typeof(int))
        {
            resCode = i.GetMessage<int>();
            switch (resCode)
            {
                case -1:
                    {
                        Debug.Log("账户或密码长度不够！");
                        break;
                    }
                case -2:
                    {
                        Debug.Log("注册失败！");
                        break;
                    }
            }
        }
        else
        {
            Debug.Log("注册成功！");
            resCode = 1;
        }
        NetRegisterRes(resCode);
    }*/
    #endregion

}