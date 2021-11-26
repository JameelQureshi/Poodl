using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;
using System;
using UnityEngine.XR.ARFoundation.Samples;


public class ModelLoader : MonoBehaviour
{
    private string filepath;
    public ModelDownloader ModelDownloader;
    public GameObject result;
    public GameObject refObj;
    public PlaceOnPlane placeOnPlane;
    public GameObject LoadButon;
    public GameObject Loading;

    public static ModelLoader Instance = null;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }
    private void ImportGLTF()
    {

        result = Importer.LoadFromFile(filepath);
        Destroy(result.GetComponentInChildren<Camera>().gameObject);
        GameObject finalResult = Instantiate(refObj, Vector3.zero, transform.rotation);  
        result.transform.localScale = new Vector3(5, 5, 5);
        result.transform.parent = finalResult.transform;
        result.transform.localPosition = Vector3.zero;
        finalResult.SetActive(false);
        placeOnPlane.Prefabs[0] = finalResult;
    }

    
    // Update is called once per frame
    void Update()
    {

        
    }
    public void LoadModel()
    {
        {
            Loading.SetActive(true);
            filepath = ModelDownloader.localURL;
            ImportGLTF();
            LoadButon.SetActive(false);
            
        }
    }

}
