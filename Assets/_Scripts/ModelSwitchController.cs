using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwitchController : MonoBehaviour
{
    public GameObject[] models;
    

    private void Start()
    {
        SelectModel(0);
    }

    public void SelectModel(int index)
    {
        foreach (GameObject model in models)
        {
            model.SetActive(false);
        }
        Debug.Log("index = " + index);
        models[index].SetActive(true);
        PlayerPrefs.SetInt("CurrentIndex", index);
       
    }
}
