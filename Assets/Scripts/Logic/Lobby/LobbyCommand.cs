/*
--FileInfo:
--Author:
--CreateTime:2022-05-01-15:36:26
--Description:
*/
using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ÊÂ¼þ
public enum ELobbyBtnAction {none, classChessMode, entertainMode, market, bag, audioSetting, quality, rule, about }

public struct LobbyBtnAction
{
    public ELobbyBtnAction btnAction;
}
#endregion
public class LobbyBtnActionCommand : AbstractCommand
{
    private LobbyController mlobbyController;
    public LobbyBtnActionCommand( )
    {
    }
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        //int a = model.userGender.Value;
        LogTool.Print(this, "OnExecute");
    }
}
