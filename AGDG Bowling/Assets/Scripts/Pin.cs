using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
    public float standingThreshold = .5f;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool OnLane;

    // Use this for initialization
    void Start()
        {
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, .123f, 0); //set pin CoM
        startPosition = transform.position;
        startRotation = transform.rotation;

        }

    // Update is called once per frame
    void Update()
        {

        }

    public bool IsStanding()                //Checks that pin is standing & on the lane
        {
        if (Vector3.Dot(Vector3.up, transform.up) < standingThreshold)
            {    return false;    }
        if (!OnLane)
            {    return false;    }
        return true;
        }

    public void Tidy()
        {
        if (!IsStanding())
            {    gameObject.SetActive(false);   }
        }

    public void Reset()
        {
        transform.position = startPosition;
        transform.rotation = startRotation;
        GetComponent<Rigidbody>().isKinematic = false;
        }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lane" )
        {
            //print("touching the lane!");
            OnLane = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Lane")
        {
            //print("not touching the lane!");
            OnLane = false;
        }
    }

}