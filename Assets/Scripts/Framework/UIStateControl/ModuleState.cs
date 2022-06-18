using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EModuleState
{
    None,
    Login,
    Lobby,
    Bag,
    Setting
}
public class ModuleState : SingletonTool<ModuleState>
{
    private List<EModuleState> mModulePath;
    private List<EModuleState> mSystemModulePath;
    private EModuleState curModuleState;
    public ModuleState()
    {
        mModulePath = new List<EModuleState>();
        mSystemModulePath = new List<EModuleState>();
    }
    //弹出
    public EModuleState PopMoudleState()
    {
        EModuleState moduleState = EModuleState.None;
        if (curModuleState != EModuleState.None)
        {
            //当前是系统级
            if (curModuleState == mSystemModulePath[mSystemModulePath.Count - 1])
            {
                moduleState = PopSystemModulePath();
            }
            else
            {
                moduleState = PopChildModulePath();
            }
        }
        return moduleState;
    }
    
    private void FreshState()
    {
        curModuleState = EModuleState.None;
        if(mModulePath!=null&& mModulePath.Count > 0)
        {
            curModuleState = mModulePath[mModulePath.Count - 1];
        }
    }

    #region 进出系统操作
    // 
    public void PushChildModule(EModuleState eModuleState)
    {
        FreshState();
        // 退出上一个孩子模块
        EModuleState curChildState = GetCurChildState();
        if (curModuleState != EModuleState.None)
        {
            CurStateOnExit(curChildState);
        }

        mModulePath.Add(eModuleState);

        //进入新的模块系统
        EModuleState curState = GetCurState();
        CurStateOnEnter(curState);
    }
    public void PushSystemModule(EModuleState eModuleState)
    {
        FreshState();
        // 退出上一个系统模块
        EModuleState curSystemState = GetCurSystemState();
        if (curModuleState != EModuleState.None)
        {
            CurStateOnExit(curSystemState);
        }
        mModulePath.Add(eModuleState);
        mSystemModulePath.Add(eModuleState);

        //进入新的模块系统
        EModuleState curState = GetCurState();
        CurStateOnEnter(curState);

    }
    // 弹出孩子级
    public EModuleState PopChildModulePath()
    {
        // 退出当前孩子模块
        EModuleState curChildState = GetCurChildState();
        if (curModuleState != EModuleState.None)
        {
            CurStateOnExit(curChildState);
        }

        EModuleState moduleState = EModuleState.None;
        if (mModulePath != null && mModulePath.Count > 0)
        {
            moduleState = mModulePath[mModulePath.Count - 1];
            mModulePath.RemoveAt(mModulePath.Count - 1);
            FreshState();
        }

        //进入新的模块系统
        EModuleState curState = GetCurState();
        CurStateOnEnter(curState);

        return moduleState;
    }
    // 弹出系统级
    public EModuleState PopSystemModulePath()
    {
        // 退出上一个系统模块
        EModuleState lastSystemState = GetCurSystemState();
        if (curModuleState != EModuleState.None)
        {
            CurStateOnExit(lastSystemState);
        }

        EModuleState moduleState = EModuleState.None;
        if (mModulePath != null && mModulePath.Count > 0 && mSystemModulePath != null && mSystemModulePath.Count > 0 && mModulePath[mModulePath.Count - 1] == mSystemModulePath[mSystemModulePath.Count - 1])
        {
            moduleState = mModulePath[mModulePath.Count - 1];
            mModulePath.RemoveAt(mModulePath.Count - 1);
            mSystemModulePath.RemoveAt(mSystemModulePath.Count - 1);
            FreshState();
        }

        // 进入上一个系统模块
        EModuleState curSystemState = GetCurSystemState();
        if (curModuleState != EModuleState.None)
        {
            CurStateOnEnter(curSystemState);
        }
        return moduleState;
    }
    #endregion

    private EModuleState GetCurState()
    {
        EModuleState moduleState = EModuleState.None;
        moduleState = mModulePath[mModulePath.Count - 1];
        return moduleState;
    }
    private EModuleState GetCurSystemState()
    {
        EModuleState moduleState = EModuleState.None;
        if (mSystemModulePath.Count > 0)
        {
            moduleState = mSystemModulePath[mSystemModulePath.Count - 1];
        }
        return moduleState;
    }
    private EModuleState GetCurChildState()
    {
        EModuleState moduleState = EModuleState.None;
        //最后一个模块是孩子模块,否则没有
        if(mModulePath[mModulePath.Count-1]!= mSystemModulePath[mSystemModulePath.Count - 1])
        {
            moduleState = mModulePath[mModulePath.Count - 1];
        }
        return moduleState;
    }

    #region 状态模块切换
    private void CurStateOnEnter(EModuleState moduleState)
    {
        CommonArchitecture architecture= DataModelService.Instance.GetArchitectureByState(moduleState);
        if (architecture != null)
        {
            architecture.OnEnter();
        }
    }
    private void CurStateOnExit(EModuleState moduleState)
    {
        IArchitecture architecture = DataModelService.Instance.GetArchitectureByState(moduleState);
        if (architecture != null)
        {
            architecture.OnExit();
        }
    }
    #endregion
}
