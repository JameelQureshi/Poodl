using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        cube.AddComponent<LeanTouch>();
        cube.AddComponent<LeanPinchScale>();
        cube.AddComponent<LeanTwistRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        cube.GetComponent<LeanTouch>().enabled = false;
        cube.GetComponent<LeanPinchScale>().enabled = false;
        cube.GetComponent<LeanTwistRotate>().enabled = false;
        print("helo");
    }
    private void OnMouseUp()
    {
        cube.GetComponent<LeanTouch>().enabled = true;
        cube.GetComponent<LeanPinchScale>().enabled = true;
        cube.GetComponent<LeanTwistRotate>().enabled = true;
        print("up");       
    }
}
