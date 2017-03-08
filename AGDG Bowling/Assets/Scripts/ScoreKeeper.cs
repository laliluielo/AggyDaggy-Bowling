using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper: MonoBehaviour {

    private FrameScore[] frames = new FrameScore[10];

    public bool tenthAwarded = false;


	// Use this for initialization
	void Start () {
        frames = GetComponentsInChildren<FrameScore>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Score(int[] shots)
        //Processes the array of shots from the GameMaster class to update the ScoreCard

    {
        List<string> scores = FormatShots(shots);
        int[] totalScore = new int[10];
        int runningTotal = 0;

        //for (int i = 0; i < scores.Count; i++)
        //{
        //    print(scores[i]);
        //}

        for (int i = 0; i < 18; i += 2)           //Frames 1-9, 2 shots per frame
        {
            if (scores[i] == "X")
            {
                if (shots[i + 2] == 10)     //Double Strike
                {
                    if (shots[i + 4] != -1) //All scores for i are there
                    {
                        totalScore[i / 2] = 10 + shots[i + 2] + shots[i + 4] + runningTotal;
                        runningTotal = totalScore[i / 2];
                        frames[i / 2].setScore(scores[i], " ", totalScore[i / 2].ToString());
                    }
                }
                else if (shots[i + 2] != -1 && shots[i + 3] != -1)          //Check if count can be calculated
                {
                    totalScore[i / 2] = 10 + shots[i + 2] + shots[i + 3] + runningTotal;
                    runningTotal = totalScore[i / 2];
                    frames[i / 2].setScore(scores[i], " ", totalScore[i / 2].ToString());
                }
                else
                {

                    frames[i / 2].setScore(scores[i], " "); //Update only the frame
                }

            }
            else
            {
                string ball1 = scores[i];           //Non-strike shots
                string ball2 = scores[i + 1];
                if (ball2 == "/")
                {
                    if (shots[i + 2] != -1) //Checking that the next shot has a valid value
                    {
                        totalScore[i / 2] = 10 + shots[i + 2] + runningTotal;
                        runningTotal = totalScore[i / 2];
                        frames[i / 2].setScore(ball1, ball2, totalScore[i / 2].ToString());
                    }
                    else
                    {

                        frames[i / 2].setScore(ball1, ball2);
                    }
                }
                else if (scores[i + 1] != " ") //Check the next shot has a valid value
                {
                    totalScore[i / 2] = shots[i] + shots[i + 1] + runningTotal;
                    runningTotal = totalScore[i / 2];
                    frames[i / 2].setScore(ball1, ball2, totalScore[i / 2].ToString());
                }
                else
                {
                    frames[i / 2].setScore(ball1); //Update only frame
                }
            }
        }
            string tenOne = scores[18];
            string tenTwo = scores[19];
            string tenThree = scores[20];       //Tenth frame special handling

            if (tenOne == "X" || tenTwo == "X" || tenTwo == "/") //Mark in the tenth to get the third ball
            {
                tenthAwarded = true;
            }
            if (tenthAwarded)
            {
                if (tenThree != " ") //Calculate the entire frame value
                {
                    totalScore[9] = shots[18] + shots[19] + shots[20] + runningTotal;

                    frames[9].setScore(tenOne, tenTwo, totalScore[9].ToString(), true, tenThree);
                }
                else if (tenTwo != " ")
                {
                    frames[9].setScore(tenOne, tenTwo, " ", true);
                }else
                {
                    frames[9].setScore(tenOne);
                }

            }
            else
            {
                if (tenOne != " ")
                {
                    if (tenTwo != " ")
                    {
                        totalScore[9] = shots[18] + shots[19] + runningTotal;
                        frames[9].setScore(tenOne, tenTwo, totalScore[9].ToString(), true);
                    }
                    else
                    {
                        frames[9].setScore(tenOne);
                    }
                }
            }
    }

    private List<string> FormatShots(int[] shots)
    {
        List<string> FormattedScores = new List<string>();

        for (int i = 0; i < 21; i++)    //process the ints to strings
        {
            if (i == 19 && shots[i-1] == 10 && shots[i] == 10)
            {
                FormattedScores.Add("X");
            }
            else if (shots[i] == 10 && i % 2 != 1)
            {
                FormattedScores.Add("X");
            }
            else if (shots[i] == 0)
            {
                FormattedScores.Add("-");
            }
            else if (shots[i] == -1)
            {
                FormattedScores.Add(" ");
            }
            else if (i % 2 == 1)
            {
                if (shots[i] + shots[i-1] == 10)
                {
                    FormattedScores.Add("/");
                }
                else
                {
                    FormattedScores.Add(shots[i].ToString());
                }
            }else
            {
                FormattedScores.Add(shots[i].ToString());
            }
        }
        return FormattedScores;
    }

    public void clearFrames()
    {
        foreach (FrameScore frame in frames)
        {
            frame.clearFrames();
        }
    }
}
