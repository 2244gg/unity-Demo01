using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[System.Serializable]
public class AssetBundleConfig
{
    [XmlElement("ABList")]
    public List<ABBase> ABList { get; set; }
}

[System.Serializable]
public class ABBase
{
    [XmlAttribute("Path")]
    public string Path{ get; set; }// 全路径
    [XmlAttribute("Crc")]
    public uint Crc { get; set; }// 文件的唯一标识（）类似MD5，MD%更加精确
    [XmlAttribute("ABName")]
    public string ABName { get; set; }
    [XmlAttribute("AssetName")]
    public string AssetName { get; set; }// AB中具体的资源名
    [XmlElement("ABDependce")]
    public List<string> ABDependce { get; set; }
}
