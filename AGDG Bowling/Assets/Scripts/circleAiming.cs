using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleAiming: MonoBehaviour {

    private BallPrototype ball;
    private Transform target;

	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<BallPrototype>();
        target = transform.Find("AimTarget");
        
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseOver()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            target.position = hit.point;
        }

        ball.transform.LookAt(target);
    }
}
