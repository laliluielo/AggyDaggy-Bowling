using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class powerToMPH: MonoBehaviour {

    public Slider powerSlider;
    public TextMeshProUGUI text;


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

	}

    public void UpdateMPHdisplay()
    {
        float speed = powerSlider.value;
        float toMPH = speed * 2.24f;
        toMPH *= 10f;
        toMPH = Mathf.Round(toMPH);
        toMPH /= 10f;

        text.text = toMPH.ToString() + " MPH";
    }
}
