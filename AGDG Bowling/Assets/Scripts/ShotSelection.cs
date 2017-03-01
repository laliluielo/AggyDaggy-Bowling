using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSelection: MonoBehaviour {

    public BallPrototype ball;
    public float scalingFactor = 100f;


    private Vector3 startPosition;
    private Vector3 startTransform;
    private DirectionalAim directionalAim;

	// Use this for initialization
    void Start()
    {
        directionalAim = FindObjectOfType<DirectionalAim>();
    }

    void Update()
    {
        if (ball.inPlay == false && Input.GetMouseButtonDown(1))
        {
            startPosition = Input.mousePosition;
            startTransform = ball.transform.position;
            //Debug.Log("mouse position:" + Input.mousePosition);

            StartCoroutine("BallControl");

        }

    }

    IEnumerator BallControl()
    {

        while (Input.GetMouseButton(1))
        {

            Vector3 currentMousePos = Input.mousePosition;
            float Xoffset = (currentMousePos.x - startPosition.x) / scalingFactor;

            ball.transform.position = new Vector3 (Mathf.Clamp(startTransform.x + Xoffset, -.6f, .6f), startTransform.y, startTransform.z);


            yield return null;
        }

    }

    public void BallLaunched()
    {
        directionalAim.gameObject.SetActive(false);
    }

    public void NewShot()
    {
        directionalAim.gameObject.SetActive(true);
    }
}
