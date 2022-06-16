/*
--FileInfo:
--Author:
--CreateTime:2022-05-29-16:05:55
--Description:为模块提供相关mono服务：比如计时
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//回调函数
public class EventCallBack
{
    public Action func;
    public float endTime;
    public float startTime;
}
public class ModuleMonoHelper : MonoBehaviour
{
    private List<EventCallBack> eventCallBacks;
    // Start is called before the first frame update
    void Start()
    {
        this.eventCallBacks = new List<EventCallBack>();
    }
    public void AddEventCallBack(Action func,float callBackTime)
    {
        EventCallBack eventCallBack = new EventCallBack();
        eventCallBack.func = func;
        eventCallBack.startTime = Time.time;
        eventCallBack.endTime = Time.time + callBackTime;
        this.eventCallBacks.Add(eventCallBack);
    }
    public void RemoveEventCallBack(Action func)
    {
        this.eventCallBacks.RemoveAll(p => p.func == func);
    }

    // Update is called once per frame
    void Update()
    {

        if (this.eventCallBacks.Count > 0)
        {
            for (int i=this.eventCallBacks.Count-1;i>=0;i--)
            {
                EventCallBack item = this.eventCallBacks[i];
                // 检查注册的回调函数是否到约定时间
                if (Time.time>=item.endTime)
                {
                    if (item.func != null)
                    {
                        item.func();
                    }
                    this.eventCallBacks.RemoveAt(i);
                }
            }
        }
    }
}
