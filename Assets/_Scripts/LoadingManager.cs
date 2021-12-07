using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance;
    public Text progress;
    public GameObject loading;

    void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        HideLoading();
    }

    public void ShowLoading()
    {
        loading.SetActive(true);
        progress.gameObject.SetActive(true);
    }
    public void HideLoading()
    {
        loading.SetActive(false);
        progress.gameObject.SetActive(false);
    }

}
