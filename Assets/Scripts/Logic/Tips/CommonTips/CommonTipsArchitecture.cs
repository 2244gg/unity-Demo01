/*
--FileInfo:
--Author:
--CreateTime:2022-05-29-15:53:48
--Description:
*/
using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonTipsArchitecture : CommonArchitecture
{
    // Start is called before the first frame update
    CommonTipsController tipsController;
    protected override void Init()
    {
        base.Init();

        Register(new CommonTipsController(this));
    }

    public override void OnEnter()
    {
        base.OnEnter();
        monoObjController = Get<CommonTipsController>();
        if (monoObjController != null)
        {
            monoObjController.OnEnter();
            monoObjController.AddMonoHelper(GameNodes.Instance.moduleMonoHelpers, "CommonTipsMonoHelper");
        }
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}
