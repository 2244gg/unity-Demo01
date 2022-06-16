/*
--FileInfo:
--Author:xuying
--CreateTime:2022-05-01-15:36:00
--Description:´óÌü
*/
using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyArchitecture : CommonArchitecture
{
    protected override void Init()
    {
        base.Init();
        RegisterModel<AbstractModel>(new LobbyModel());
        Register(new LobbyController(this));
    }

    public override void OnEnter()
    {
        base.OnEnter();
        monoObjController = Get<LobbyController>();
        if (monoObjController != null)
        {
            monoObjController.OnEnter();
        }
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}
