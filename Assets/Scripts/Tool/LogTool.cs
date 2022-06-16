using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogTool 
{
    public static void Print( System.Object mclassType,string func)
    {
        Debug.LogWarning("Enter " + mclassType.ToString()+"---" + func);
    }
}
