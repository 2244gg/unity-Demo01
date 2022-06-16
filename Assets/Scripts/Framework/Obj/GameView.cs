/*
--FileInfo:
--Author:
--CreateTime:2022-04-23-17:13:37
--Description:MVC View层，关注视图上的事
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
    /// 资源回收
    /// </summary>
    public virtual void Recycle()
    {
        ObjectManager.Instance.ReleaseObject(mObj, 0, true);
    }
    /// <summary>
    /// 创建对象
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
