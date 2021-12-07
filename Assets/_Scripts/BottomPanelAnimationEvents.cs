using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPanelAnimationEvents : MonoBehaviour
{
    public bool isOpened = false;

    public static BottomPanelAnimationEvents Instance = null;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    public void OnPanelOpened()
    {
        TouchCounter.Instance.DeleteButton.SetActive(false);
        isOpened = true;
    }
    public void OnPanelClose()
    {

        isOpened = false;
    }
   
}
