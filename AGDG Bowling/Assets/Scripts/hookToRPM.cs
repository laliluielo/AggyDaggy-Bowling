using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class hookToRPM: MonoBehaviour {

    public Slider hookSlider;
    public TextMeshProUGUI text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateHookDisplay()
    {
        float angularSpeed = hookSlider.value;
        float toRPM = angularSpeed * 0.159f * 60f; // 1 r/s to ~0.159 Hz. 60 RPM is 1 Hz.
        toRPM = Mathf.Round(toRPM);
        toRPM = Mathf.Abs(toRPM);

        text.text = toRPM.ToString() + " RPM";
    }
}
