using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPrototype: MonoBehaviour {

    public bool launch = false;
    public float strength;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (launch)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * strength);
            launch = false;
        }
		
	}


}
