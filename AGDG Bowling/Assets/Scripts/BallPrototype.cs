using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallPrototype: MonoBehaviour {

    public bool launch = false;
    public Slider strSlider;
    public Slider hookSlider;
    
    public float initialSpeed; // m/s
    public float initialRevs; // rad/s
    public float hookStrength;
    public float mass; //  kg
    public float currentSpeed;

    public bool inPlay = false;


    private Rigidbody rgbdy;
    private ShotSelection sSelection;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private GameMaster gameMaster;



	// Use this for initialization
	void Start () {
        rgbdy = GetComponent<Rigidbody>();
        rgbdy.maxAngularVelocity = 400f;
        rgbdy.useGravity = false;
        sSelection = FindObjectOfType<ShotSelection>();
        gameMaster = FindObjectOfType<GameMaster>();
        mass = rgbdy.mass;



	}
	
	// Update is called once per frame
	void Update () {
        if (!inPlay && (Input.GetButtonDown("Jump") || launch))
        {
            Launch();
        }


        currentSpeed = rgbdy.velocity.magnitude;
    }

    private void Launch()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        //float initialKE = (1 / 2 * mass * Mathf.Pow(initialSpeed, 2.0f));
        rgbdy.AddRelativeForce(Vector3.forward * initialSpeed, ForceMode.VelocityChange);
        
        rgbdy.AddRelativeTorque(Vector3.forward * initialRevs, ForceMode.VelocityChange);
        rgbdy.useGravity = true;
        launch = false;
        inPlay = true;
        sSelection.BallLaunched();
    }

    //void FixedUpdate()
    //{
    //    if (inPlay)
    //    {
    //        Vector3 hook = rgbdy.angularVelocity * hookStrength;
    //        //Debug.Log("Rotation vector: " + rgbdy.angularVelocity + ", hook vector :" + hook);
    //        rgbdy.AddForce(-hook.z, 0, 0);
    //    }
    //}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pinset" )
        {
            inPlay = false;
            rgbdy.angularDrag = 1f;
            rgbdy.velocity = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TripSensor")
        {
            gameMaster.Invoke("ShotFinished", 4f);
        }
    }

    public void SetStrength()
    {
        initialSpeed = strSlider.value;
    }

    public void SetHook()
    {
        initialRevs = hookSlider.value;
    }

    public void BallReset()
    {
        rgbdy.useGravity = false;
        rgbdy.velocity = Vector3.zero;
        rgbdy.angularVelocity = Vector3.zero;

        transform.position = startPosition;
        transform.rotation = startRotation;
        sSelection.NewShot();
        inPlay = false;

          
    }


}
