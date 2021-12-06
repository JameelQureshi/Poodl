using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionButtonCreator : MonoBehaviour
{
    public static SelectionButtonCreator Instance ;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }
    public GameObject scroll;
    public GameObject buttonRef;

    public void CreateButtons(DownloadResult downloadResult)
    {
        for (int i = 0; i<downloadResult.assets.Count; i++ )
        {
            GameObject button = Instantiate(buttonRef,scroll.transform);
        }
    }
}
