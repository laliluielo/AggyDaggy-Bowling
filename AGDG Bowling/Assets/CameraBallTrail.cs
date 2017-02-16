using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBallTrail: MonoBehaviour {

    public GameObject ball;

    //private Camera trailCam;
    private float offset;

	// Use this for initialization
	void Start () {
        //trailCam = GetComponent<Camera>();
        offset = transform.position.z - ball.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        
        float zValue = Mathf.Clamp(ball.transform.position.z + offset, 0, 18f);
        transform.position = new Vector3(transform.position.x, transform.position.y, zValue);
        transform.LookAt(ball.transform);

    }


}
