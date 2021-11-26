using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPanelAnimationEvents : MonoBehaviour
{
    public bool isOpened = false;

    public void OnPanelOpened()
    {
        isOpened = true;
    }
    public void OnPanelClose()
    {
        isOpened = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
