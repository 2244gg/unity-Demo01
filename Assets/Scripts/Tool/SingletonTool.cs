/*
--FileInfo:
--Author:
--CreateTime:2022-04-10-16:44:06
--Description:
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTool<T> where  T:new()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}
