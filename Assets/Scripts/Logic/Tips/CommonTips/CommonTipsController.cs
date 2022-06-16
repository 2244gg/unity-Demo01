/*
--FileInfo:
--Author:
--CreateTime:2022-05-29-15:54:45
--Description:
*/
using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 此处服务类不好处理
public class CommonTipsSevice: Singleton<CommonTipsSevice>
{
    public CommonArchitecture commonArchitecture = new CommonTipsArchitecture();
    public void ShowSingleMsg(string content)
    {
    }
}
public class CommonTipsController : MonoObjController
{
    private SingleMsgTipView singleMsgTip;
    public CommonTipsController(IArchitecture achiture) : base(achiture)
    {

    }
    public override IArchitecture GetArchitecture() // -+
    {
        return base.GetArchitecture();
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
    public override void OnExit()
    {
        base.OnExit();
    }

    #region 弹窗弹出
    public void ShowSingleMsg(string content,float duration)
    {
        singleMsgTip = new SingleMsgTipView(this.mAchiture);
        this.CreateObj<SingleMsgTipView>(singleMsgTip, GameNodes.Instance.canvas.Find("PanelTips"));
        this.monoObjs.Add(singleMsgTip);
        singleMsgTip.Start();
        singleMsgTip.ShowTip(content);
        //0.5后回调关闭tip方法
        this.AddFuncCallBack(this.CloseSingleMsg, 0.5f);
    }
    public void CloseSingleMsg()
    {
        if (singleMsgTip != null)
        {
            base.DestorySingleObj<SingleMsgTipView>(singleMsgTip);
        }
    }
    #endregion
}
