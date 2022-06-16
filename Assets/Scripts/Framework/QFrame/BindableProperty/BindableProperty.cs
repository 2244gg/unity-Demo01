using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindableProperty<T> where T :  IEquatable<T> 
{
    private T mValue;

    public T Value
    {
        get => mValue;
        set
        { 
            if(mValue==null)
            {
                mValue = value;
            }
            
            if (mValue!=null&&!mValue.Equals(value))
            {
                mValue = value;
                OnValueChanged?.Invoke(value);
            }
        }
    }

    public Action<T> OnValueChanged;
}
public class BindablePropertyClass<T> where T : class, IEquatable<T>
{
    private T mValue;

    public T Value
    {
        get
        {
           /* if (mValue == null)
            {
                mValue = Value;
            }*/
            return mValue;
        }
        set
        {
            if (mValue == null)
            {
                mValue = Value;
            }
            if (!mValue.Equals(value))
            {
                mValue = value;
                OnValueChanged?.Invoke(value);
            }
        }
    }
 /*   public BindablePropertyClass(){
        if(mValue==null)
        {
            mValue = Value;
        }
    }*/

    public Action<T> OnValueChanged;
}