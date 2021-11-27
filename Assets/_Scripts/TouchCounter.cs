using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchCounter : MonoBehaviour
{
    private int check;
    public GameObject AddButton;
    public GameObject DeleteButton;
    public GameObject ArPanel;

    public GameObject selectedObject;

    // Start is called before the first frame update
    public static TouchCounter Instance = null;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        check = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
          
            if (check != 1)
            {
                Debug.Log("Mouse Button Pressed!");
                AddButton.SetActive(true);
                check = 1;
            }
        }
    }
    public void add()
    {
        ArPanel.SetActive(true);
    }

    public void Delete()
    {
        if (selectedObject!=null)
        {
            Destroy(selectedObject);
        }
    }
}
