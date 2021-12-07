using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;
using System;
using UnityEngine.XR.ARFoundation.Samples;


public class ModelLoader : MonoBehaviour
{
    private string filepath;
    public GameObject result;
    public GameObject refObj;
    

    public static ModelLoader Instance = null;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }
    private void ImportGLTF(int id)
    {

        result = Importer.LoadFromFile(filepath);
        Destroy(result.GetComponentInChildren<Camera>().gameObject);
        GameObject finalResult = Instantiate(refObj, Vector3.zero, transform.rotation);  
        result.transform.localScale = new Vector3(5, 5, 5);
        result.transform.parent = finalResult.transform;
        result.transform.localPosition = Vector3.zero;

        finalResult.GetComponent<ObjectSelection>().id = id;
        finalResult.SetActive(false);
        PlaceOnPlane.instance.AddItemToList(finalResult,id);
        PlaceOnPlane.instance.SelectModel(id);
        LoadingManager.instance.HideLoading();
    }

    
    // Update is called once per frame
    void Update()
    {

        
    }
    public void LoadModel(string path,int id)
    {
        
        filepath = path;
        if (PlaceOnPlane.instance.IsModelLoaded(id))
        {
            PlaceOnPlane.instance.SelectModel(id);
        }
        else
        {
            LoadingManager.instance.ShowLoading();
            LoadingManager.instance.progress.text = "";
            ImportGLTF(id);
        }

    }

}
