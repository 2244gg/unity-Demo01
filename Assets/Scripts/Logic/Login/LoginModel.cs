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
    //����ش�
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


    #region ����
   /* public void LoginReq()
    {
        if (curLoginData != null)
        {
            // AudioCtrl.instance.PlayAudioTip(ClipStyle.buttonClick);
            //�жϷǿ���ֵ�������������ַ�
            if (!string.IsNullOrEmpty(curLoginData.uerName))
            {
                if (!string.IsNullOrEmpty(curLoginData.passWord))
                {
                    //������֤��ֹ�û�����
                    AccountDTO account = new AccountDTO(curLoginData.uerName, curLoginData.passWord);
                    *//*account.uid = userName;
                    account.upwd = userPsd;*//*
                    NetIO.Instance.Write(Protocol.Accaount, 1, AccountProtocol.Login_CREQ, account);

                    return;

                }
                //��ʾ��������
                // FindObjectOfType<MsgBox>().ShowSingleMsg(transform, "����������", 1);
                return;
            }
            //��ʾ��������
            // FindObjectOfType<MsgBox>().ShowSingleMsg(transform, "����������", 1);
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
                    if (curRegisterData.uerGender)//Ů
                        sexId = 1;

                    //������鿴�û����Ƿ�������,��ֹ�û�����
                    AccountDTO account = new AccountDTO(curRegisterData.uerName, curRegisterData.passWord, sexId, curRegisterData.userMail);
                    NetIO.Instance.Write(Protocol.Accaount, 1, AccountProtocol.Reg_CREQ, account);
                    return;
                    //ע��ɹ�����ת��¼ҳ��

                }
                //��ʾ�����ʽ����
                //FindObjectOfType<MsgBox>().ShowSingleMsg(transform, "�����ʽ����", 1);

            }
            //��ʾ����������
            //FindObjectOfType<MsgBox>().ShowSingleMsg(transform, "����������", 1);
            return;
        }
        //��ʾ�������û���
        // FindObjectOfType<MsgBox>().ShowSingleMsg(transform, "�������û���", 1);
    }
    //��¼�����ж�--���շ�������¼���
    void LoginRes(SocketModel i)
    {
        int resCode = 1;
        //����
        if (i.message.GetType() == typeof(int))
        {
             resCode = i.GetMessage<int>();
            switch (resCode)
            {
                case -1:
                    {
                        Debug.Log("��½ʧ�ܣ�");
                        break;
                    }
                case -2:
                    {
                        Debug.Log("û�д��˺ţ�");
                        break;
                    }
                case -3:
                    {
                        Debug.Log("�������");
                        break;
                    }
                case -4:
                    {
                        Debug.Log("�˺��ѵ�¼��");
                        break;
                    }
            }
        }
        else
        {
            Debug.Log("��¼�ɹ���");
            resCode = 1;
        }
        NetLoginRes(resCode);
    }
    //ע�������ж�--���շ�����ע����
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
                        Debug.Log("�˻������볤�Ȳ�����");
                        break;
                    }
                case -2:
                    {
                        Debug.Log("ע��ʧ�ܣ�");
                        break;
                    }
            }
        }
        else
        {
            Debug.Log("ע��ɹ���");
            resCode = 1;
        }
        NetRegisterRes(resCode);
    }*/
    #endregion

}