using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLight: MonoBehaviour {

    public Material oneLit;
    public Material twoLit;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setLight(int light)
    {
        if (light == 0)
        {
            GetComponent<Renderer>().material = oneLit;
        }else
        {
            GetComponent<Renderer>().material = twoLit;
        }
    }
}
