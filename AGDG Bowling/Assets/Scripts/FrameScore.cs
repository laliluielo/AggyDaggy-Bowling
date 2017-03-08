using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrameScore : MonoBehaviour
{

    private List<TextMeshProUGUI> scores;

    // Use this for initialization
    void Start()
    {
        scores = new List<TextMeshProUGUI>(GetComponentsInChildren<TextMeshProUGUI>());
        //score [1] is the first shot, score[2] is the second, score[3] is the total
        clearFrames();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void setScore(string firstBall = " ", string secondBall= " ", string Total = " " , bool Tenth = false, string thirdBall = " ")
    {
        scores[0].text = firstBall;
        scores[1].text = secondBall;
        scores[2].text = Total;

        if (Tenth)
        {
            scores[2].text = thirdBall;
            scores[3].text = Total;
        }
    }

    public void clearFrames()
    {
        foreach (TextMeshProUGUI text in scores)
        {
            text.text = " ";
        }
    }
}
