/*
--FileInfo:
--Author:
--CreateTime:2022-04-10-16:23:04
--Description:
*/
using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public Transform RecycleNodes;
    public Transform SceneNodes;
    public Canvas canvas;
    DataModelService modelService;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        ServiceInit();
        //
        ObjectManager.Instance.Init(RecycleNodes, SceneNodes);
#if UNITY_EDITOR
        ResourceManager.Instance.m_LoadFormAssetBundle = false;
#endif
        //加载AB包配置表
        AssetBundleManager.Instance.LoadAssetBundleConfig();
        // 模块启动
        DataModelService.Instance.Init();
        //登录模块压入
        ModuleState.Instance.PushSystemModule(EModuleState.Login);
    }
    // 处理单例服务类的初始化时序
    void ServiceInit()
    {
        var t1=DataModelService.Instance;
        var t2= ModuleState.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
