/*
--FileInfo:
--Author:
--CreateTime:2022-05-01-15:35:24
--Description:´óÌü
*/
using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoObjController
{
    private UILobbyView lobbyView;
    // private ITypeEventSystem mTypeEventSystem = null;
    public LobbyController(IArchitecture achiture) : base(achiture)
    {

    }
    public override IArchitecture GetArchitecture() // -+
    {
        return base.GetArchitecture();
    }
    public override void OnEnter()
    {
        base.OnEnter();
        lobbyView = new UILobbyView(this.mAchiture);
        this.CreateObj<UILobbyView>(lobbyView, GameNodes.Instance.canvas);
        this.monoObjs.Add(lobbyView);
        lobbyView.Start();
        EventInit();


    }

    public override void OnExit()
    {
        base.OnExit();
        GetArchitecture().UnRegisterEvent<LobbyBtnAction>(BtnActionHandle);
    }
    #region ÊÂ¼þ
    private void EventInit()
    {
        GetArchitecture().RegisterEvent<LobbyBtnAction>(BtnActionHandle);
    }
    private void BtnActionHandle(LobbyBtnAction btnAction)
    {
        switch(btnAction.btnAction)
        {
            case ELobbyBtnAction.none:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            case ELobbyBtnAction.about:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            case ELobbyBtnAction.audioSetting:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            case ELobbyBtnAction.bag:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            case ELobbyBtnAction.classChessMode:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            case ELobbyBtnAction.entertainMode:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            case ELobbyBtnAction.market:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            case ELobbyBtnAction.quality:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }
            case ELobbyBtnAction.rule:
                {
                    Debug.Log(btnAction.btnAction.ToString());
                    break;
                }

        }
    }
    #endregion
}
