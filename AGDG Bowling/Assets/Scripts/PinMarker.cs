using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMarker : MonoBehaviour {

    public GameObject pinPrefab;


	// Use this for initialization
	void Start () {
        foreach (Transform child in transform)
        {
            Debug.Log(child.gameObject + "at " + child.transform.position);
            GameObject pin = Instantiate(pinPrefab, child);
            pin.transform.position = pin.transform.parent.position;
            pin.transform.rotation = Quaternion.Euler(Vector3.up);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
