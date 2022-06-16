/*
--FileInfo:
--Author:
--CreateTime:2022-05-29-16:05:55
--Description:Ϊģ���ṩ���mono���񣺱����ʱ
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ص�����
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
                // ���ע��Ļص������Ƿ�Լ��ʱ��
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
