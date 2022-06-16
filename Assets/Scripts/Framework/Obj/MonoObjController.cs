/*
--FileInfo:
--Author:
--CreateTime:2022-05-01-15:44:17
--Description:对unity OBJ对象的管理
*/
using FrameworkDesign;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonoObjController :/* MonoBehaviour,*/ IController
{
    protected GameObject monoHelper;
    protected List<GameView> monoObjs = new List<GameView>();
    /// <summary>
    /// 创建对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objGameView"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject CreateObj<T>(T objGameView, Transform parent) where T : GameView
    {
        GameObject obj = null;
        if (objGameView != null)
        {
            obj = objGameView.CreateObj(parent);
        }
        return obj;
    }
    /// <summary>
    /// 删除最后一个
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    public void DestorySingleObj<T>(GameView obj)
    {
        if (this.monoObjs != null)
        {

            for (int i = this.monoObjs.Count - 1; i >= 0; i--)
            {
                if (this.monoObjs[i] == obj)
                {
                    this.monoObjs[i].Destroy();
                    monoObjs.RemoveAt(i);
                }
            }
        }
    }
    public MonoObjController(IArchitecture achiture)
    {
        this.mAchiture = achiture;
    }
    protected IArchitecture mAchiture;
    public virtual IArchitecture GetArchitecture()
    {

        // return LoginArchitecture.Interface;
        return mAchiture;
    }
    public virtual void OnEnter()
    {
        // OnEnter();
    }
    public virtual void OnExit()
    {
        if (monoObjs != null)
        {
            for (int i = monoObjs.Count - 1; i >= 0; i--)
            {
                IGameView controller = monoObjs[i];
                if (controller != null)
                {
                    controller.Destroy();
                }
                monoObjs.RemoveAt(i);
            }
        }
        // OnExit();
    }
    public void AddMonoHelper(Transform parent,string name="monoHeleper")
    {
        if(monoHelper==null)
        {
            monoHelper = new GameObject(name);
            monoHelper.transform.SetParent(parent,false);
            monoHelper.AddComponent<ModuleMonoHelper>();
        }
    }
    public void AddFuncCallBack(Action func,float time)
    {
        if(this.monoHelper!=null)
        {
            this.monoHelper.GetComponent<ModuleMonoHelper>().AddEventCallBack(func, time);
        }
    }
    public void RemoveFuncCallBack(Action func)
    {
        if (this.monoHelper != null)
        {
            this.monoHelper.GetComponent<ModuleMonoHelper>().RemoveEventCallBack(func);
        }
    }

    /*public MonoObjController(IArchitecture achiture)
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
    }*/
}