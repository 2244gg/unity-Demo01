/*
--FileInfo:
--Author:
--CreateTime:2022-04-23-17:13:37
--Description:MVC View�㣬��ע��ͼ�ϵ���
*/
using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : IGameView
{
    public GameView(IArchitecture achiture)
    {
        this.mAchiture = achiture;
    }
    protected IArchitecture mAchiture;
    protected GameObject mObj;
    public virtual void Start()
    {

    }
    public virtual IArchitecture GetArchitecture()
    {

        // return LoginArchitecture.Interface;
        return mAchiture;
    }
    public virtual string PrefabPath()
    {
        string path = "";
        return path;
    }
    public virtual void Destroy()
    {
        Recycle();
    }
    /// <summary>
    /// ��Դ����
    /// </summary>
    public virtual void Recycle()
    {
        ObjectManager.Instance.ReleaseObject(mObj, 0, true);
    }
    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject CreateObj(Transform parent)
    {
        string path = PrefabPath();
        GameObject obj = ObjectManager.Instance.InstantiateObject(path);
        if (obj != null)
        {
            this.mObj = obj;
            obj.transform.SetParent(parent, false);
        }
        return obj;
    }
}
