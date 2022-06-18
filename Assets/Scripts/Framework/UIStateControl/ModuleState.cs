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
    //����
    public EModuleState PopMoudleState()
    {
        EModuleState moduleState = EModuleState.None;
        if (curModuleState != EModuleState.None)
        {
            //��ǰ��ϵͳ��
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

    #region ����ϵͳ����
    // 
    public void PushChildModule(EModuleState eModuleState)
    {
        FreshState();
        // �˳���һ������ģ��
        EModuleState curChildState = GetCurChildState();
        if (curModuleState != EModuleState.None)
        {
            CurStateOnExit(curChildState);
        }

        mModulePath.Add(eModuleState);

        //�����µ�ģ��ϵͳ
        EModuleState curState = GetCurState();
        CurStateOnEnter(curState);
    }
    public void PushSystemModule(EModuleState eModuleState)
    {
        FreshState();
        // �˳���һ��ϵͳģ��
        EModuleState curSystemState = GetCurSystemState();
        if (curModuleState != EModuleState.None)
        {
            CurStateOnExit(curSystemState);
        }
        mModulePath.Add(eModuleState);
        mSystemModulePath.Add(eModuleState);

        //�����µ�ģ��ϵͳ
        EModuleState curState = GetCurState();
        CurStateOnEnter(curState);

    }
    // �������Ӽ�
    public EModuleState PopChildModulePath()
    {
        // �˳���ǰ����ģ��
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

        //�����µ�ģ��ϵͳ
        EModuleState curState = GetCurState();
        CurStateOnEnter(curState);

        return moduleState;
    }
    // ����ϵͳ��
    public EModuleState PopSystemModulePath()
    {
        // �˳���һ��ϵͳģ��
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

        // ������һ��ϵͳģ��
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
        //���һ��ģ���Ǻ���ģ��,����û��
        if(mModulePath[mModulePath.Count-1]!= mSystemModulePath[mSystemModulePath.Count - 1])
        {
            moduleState = mModulePath[mModulePath.Count - 1];
        }
        return moduleState;
    }

    #region ״̬ģ���л�
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
