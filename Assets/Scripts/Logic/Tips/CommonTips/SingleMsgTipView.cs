/*
--FileInfo:
--Author:
--CreateTime:2022-05-29-15:35:56
--Description:������Ϣ��ʾ
*/
using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SingleMsgTipView : GameView
{
    private Text content;
    public SingleMsgTipView(IArchitecture achiture) : base(achiture)
    {

    }
    private void Init()
    {
        LogTool.Print(this, "Init");
        content = this.mObj.transform.Find("Image/Text").GetComponent<Text>();
       
    }
    public override string PrefabPath()
    {
        string path = "";
        path = "Assets/GameData/CommonTips/Panel_SingleMsg.prefab";
        return path;
    }

    public override void Start()
    {
        // ��ȡ
        // mLoginModel = this.GetModel<LoginModel>(); // -+
        // UI���ʼ��
        Init();
    }
    public void ShowTip(string content)
    {
        this.content.text = content;
    }
}
