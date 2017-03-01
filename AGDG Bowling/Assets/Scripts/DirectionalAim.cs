using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalAim: MonoBehaviour {

    public float scalingFactor;
    private BallPrototype ball;
    private Vector3 startPosition;
    private Quaternion startRotation;

	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<BallPrototype>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        //Debug.Log("Clicked!");
        startPosition = Input.mousePosition;
        startRotation = ball.transform.rotation;

        StartCoroutine("BallAim");
    }

    IEnumerator BallAim()
    {

        while (Input.GetMouseButton(0))
        {
            //Debug.Log("in while!");
            Vector3 currentMousePos = Input.mousePosition;
            float Xoffset = (currentMousePos.x - startPosition.x) / scalingFactor;
            transform.RotateAround(ball.transform.position, Vector3.up, Xoffset);
            ball.transform.Rotate(Vector3.up, Xoffset);
            //Debug.Log("exiting while");
            yield return null;
        }

    }
}
