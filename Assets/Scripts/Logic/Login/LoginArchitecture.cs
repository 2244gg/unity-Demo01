using FrameworkDesign;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginArchitecture : CommonArchitecture
{
    ILoginModel loginModel;
    protected override void Init()
    {
        base.Init();
         loginModel= new LoginModel();
        RegisterModel<ILoginModel>(loginModel);

        Register(new LoginController(this));
    }

    public override void OnEnter()
    {
        base.OnEnter();
        loginModel.Init();
        monoObjController = Get<LoginController>();
        if (monoObjController != null)
        {
            monoObjController.OnEnter();
        }
    }
    public override void OnExit()
    {
        base.OnExit();
    }
    /*public override void OnEnter()
    {
        base.OnEnter();
        LoginController loginController = new LoginController(this);
        this.CreateObj<LoginController>(loginController, GameNodes.Instance.canvas);
        loginController.Start();
    }
    public override void OnExit()
    {
        base.OnExit();
        if (controllers != null)
        {
            for(int i= controllers.Count-1;i>=0;i--)
            {
                IController controller = controllers[i];
                controller.Destroy();
                controllers.RemoveAt(i);
            }
        }
    }*/
}