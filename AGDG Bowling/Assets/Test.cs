using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MouseHeld();
        MouseDown();
        
	}

    public void MouseHeld()
    {
        if (Input.GetMouseButton(1))
        {
            Debug.Log("Mouse Held");
        }
    }

    public void MouseDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse Down");
        }
    }
}
