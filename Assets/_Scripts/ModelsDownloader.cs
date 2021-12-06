using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ModelsDownloader : MonoBehaviour
{
    private string serverURL = "https://poodlapi.xlmoose.com/api/nft/catalog/1";
    private DownloadResult downloadResult;
    
    void Start()
    {
        StartCoroutine(DownloadModelDetails());
    }

    IEnumerator DownloadModelDetails()
    {
        UnityWebRequest www = UnityWebRequest.Get(serverURL);
        StartCoroutine(WaitForResponse(www));
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
           // Debug.Log(www.downloadHandler.text);
            downloadResult = JsonUtility.FromJson<DownloadResult>(www.downloadHandler.text);
            Debug.Log(downloadResult.assets.Count);
            SelectionButtonCreator.Instance.CreateButtons(downloadResult);
        }
    }

    IEnumerator WaitForResponse(UnityWebRequest request)
    {
        while (!request.isDone)
        {
            //loadingProgress.text = "" + (request.downloadProgress * 100).ToString("F0") + "%";
            //print(loadingProgress);
            yield return null;
        }
    }
}
