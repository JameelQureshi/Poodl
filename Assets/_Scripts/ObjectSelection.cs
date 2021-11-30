using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation.Samples;

public class ObjectSelection : MonoBehaviour
{

    public GameObject ring;
    bool check = true;
    private bool isSelected = false;
     private void Awake()
     {
        DeselectObject();
        //TouchCounter.Instance.DeleteButton.SetActive(true);
        print("downloaded");
   
     }
    private void OnMouseUp()
    {

        gameObject.GetComponent<LeanTouch>().enabled = false;
        gameObject.GetComponent<LeanPinchScale>().enabled = false;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = false;
       
    }
    private void OnMouseDown()
    {
        if (isSelected)
        {
            SelectObject();
            return;
        }
        GameObject[] models = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject model in models)
        {
            model.GetComponent<ObjectSelection>().DeselectObject();
        }
        
        SelectObject();
    }

    private void SelectObject()
    {
        isSelected = true;
        TouchCounter.Instance.selectedObject = gameObject;
        if (!BottomPanelAnimationEvents.Instance.isOpened)
        {
            TouchCounter.Instance.DeleteButton.SetActive(true);
        }
        
        gameObject.GetComponent<LeanTouch>().enabled = true;
        gameObject.GetComponent<LeanPinchScale>().enabled = true;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = true;
       //ring.SetActive(true);
    }
    private void DeselectObject()
    {
        isSelected = false;
        gameObject.GetComponent<LeanTouch>().enabled = false;
        gameObject.GetComponent<LeanPinchScale>().enabled = false;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = false;
       ring.SetActive(false);
    }


}

