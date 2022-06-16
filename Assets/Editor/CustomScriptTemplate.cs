using UnityEngine;
using System.IO;

public class CustomScriptTemplate : UnityEditor.AssetModificationProcessor
{
    /// <summary>  
    /// �˺�����asset�������꣬�ļ��Ѿ����ɵ������ϣ�����û������.meta�ļ���import֮ǰ������  
    /// </summary>  
    /// <param name="newFileMeta">newfilemeta ���ɴ����ļ���path����.meta��ɵ�</param>  
    public static void OnWillCreateAsset(string newFileMeta)
    {
        string newFilePath = newFileMeta.Replace(".meta", "");
        string fileExt = Path.GetExtension(newFilePath);
        if (fileExt != ".cs")
        {
            return;
        }
        //ע�⣬Application.datapath�����ʹ��ƽ̨��ͬ����ͬ  
        string realPath = Application.dataPath.Replace("Assets", "") + newFilePath;
        string scriptContent = File.ReadAllText(realPath);

        //����ʵ���Զ����һЩ����  
        scriptContent = scriptContent.Replace("#CreateTime#", System.DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss"));

        File.WriteAllText(realPath, scriptContent);
    }
}