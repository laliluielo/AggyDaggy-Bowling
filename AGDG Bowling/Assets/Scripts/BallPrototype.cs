using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPrototype: MonoBehaviour {

    public bool launch = false;
    
    public float strength;
    public float revs;
    public float hookStrength;

    private bool inPlay = false;
    private Rigidbody rgbdy;



	// Use this for initialization
	void Start () {
        rgbdy = GetComponent<Rigidbody>();
        rgbdy.maxAngularVelocity = 400f;
	}
	
	// Update is called once per frame
	void Update () {
        if (launch)
        {
            rgbdy.AddRelativeForce(Vector3.forward * strength);
            rgbdy.AddRelativeTorque(Vector3.forward * revs);
            launch = false;
            inPlay = true;
        }
		
	}

    void FixedUpdate()
    {
        if (inPlay)
        {
            Vector3 hook = rgbdy.angularVelocity * hookStrength;
            //Debug.Log("Rotation vector: " + rgbdy.angularVelocity + ", hook vector :" + hook);
            rgbdy.AddForce(-hook.z, 0, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pinset" )
        {
            inPlay = false;
            rgbdy.angularDrag = 1f;
        }
    }
}
