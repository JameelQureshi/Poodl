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
     private void Awake()
     {
        gameObject.GetComponent<LeanTouch>().enabled = true;
        gameObject.GetComponent<LeanPinchScale>().enabled = true;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = true;
        TouchCounter.Instance.DeleteButton.SetActive(true);
        print("downloaded");
        GameObject[] objs;
         objs = GameObject.FindGameObjectsWithTag("Target");
         foreach (GameObject model in objs)
         {
            model.transform.GetChild(0).gameObject.SetActive(false);
        }
         ring.SetActive(false);
        //TouchCounter.Instance.AddButton.SetActive(true);
     }
    private void OnMouseUp()
    {

        gameObject.GetComponent<LeanTouch>().enabled = false;
        gameObject.GetComponent<LeanPinchScale>().enabled = false;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = false;
       // TouchCounter.Instance.DeleteButton.SetActive(false);
       // TouchCounter.Instance.AddButton.SetActive(true);
        ring.SetActive(false);

    }
    private void OnMouseDown()
    {
        gameObject.GetComponent<LeanTouch>().enabled = true;
        gameObject.GetComponent<LeanPinchScale>().enabled = true;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = true;
       // TouchCounter.Instance.DeleteButton.SetActive(true);
      //  TouchCounter.Instance.AddButton.SetActive(false);
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject model in objs)
        {
            model.transform.GetChild(0).gameObject.SetActive(false);
        }

        ring.SetActive(true);

    }


}

