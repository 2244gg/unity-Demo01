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
        //����AB�����ñ�
        AssetBundleManager.Instance.LoadAssetBundleConfig();
        // ģ������
        DataModelService.Instance.Init();
        //��¼ģ��ѹ��
        ModuleState.Instance.PushSystemModule(EModuleState.Login);
    }
    // ������������ĳ�ʼ��ʱ��
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
