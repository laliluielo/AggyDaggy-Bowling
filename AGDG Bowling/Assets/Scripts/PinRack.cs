using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinRack: MonoBehaviour {




    private Pin[] pins;

	// Use this for initialization
	void Start () {

        pins = GetComponentsInChildren<Pin>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void ResetPins()
    {
        foreach (Pin pin in pins)
        {
            pin.GetComponent<Rigidbody>().isKinematic = true;
            pin.gameObject.SetActive(true);
            pin.Reset();
        }
    }

    public void TidyPins()
    {

        foreach (Pin pin in pins)
        {
            pin.Tidy();
        }
    }

    public int pinsStanding()
    {
        int count = 0;
        foreach (Pin pin in pins)
        {
            if (pin.isActiveAndEnabled)
            {
                count++;
            }
        }
        return (count);
    }
}
