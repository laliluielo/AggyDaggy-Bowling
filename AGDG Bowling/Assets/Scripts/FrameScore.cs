using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrameScore: MonoBehaviour {

    private List<TextMeshProUGUI> scores;

    // Use this for initialization
    void Start()
    {
        scores = new List<TextMeshProUGUI>(GetComponentsInChildren<TextMeshProUGUI>());
        //score [1] is the first shot, score[2] is the second, score[3] is the total
        //The 10th frame is an exception, and has 3 shots. score [4] is the total
        foreach (TextMeshProUGUI text in scores)
        {
            text.text = " ";
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int pinfall, int shotNumber)
    {
        if (shotNumber == 0)        //first ball
        {
            scores[0].text = pinfall.ToString();
        }
        else
        {
            scores[1].text = pinfall.ToString();
        }
    }
}
