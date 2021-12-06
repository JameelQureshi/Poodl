using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonClasses : MonoBehaviour
{
    
}

[Serializable]
public class Asset
{
    public string name;
    public string id;
    public string thumbnailUrl;
    public string modelUrl;
    public string contractAddress;
    public string ownerAddress;
}
[Serializable]
public class DownloadResult
{
    public List<Asset> assets;
}

