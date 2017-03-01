using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper: MonoBehaviour {

    private FrameScore[] frames = new FrameScore[10];

	// Use this for initialization
	void Start () {
        frames = GetComponentsInChildren<FrameScore>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Score(int pinFall, int shot)
    {
        frames[shot / 2].AddScore(pinFall, shot % 2);
    }
}
