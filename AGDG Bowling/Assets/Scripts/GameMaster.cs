using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster: MonoBehaviour {


    //public List<int> shots = new List<int>();
    public int shotNumber = 0;

    private PinRack rack;
    private ScoreKeeper scorer;
    private BallPrototype ball;


    private int PinsActive = 10;
    private int pinFall;



    // Use this for initialization
    void Start () {
        rack = FindObjectOfType<PinRack>();
        scorer = FindObjectOfType<ScoreKeeper>();
        ball = FindObjectOfType<BallPrototype>();
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void ShotFinished()
    {
        rack.TidyPins();
        pinFall = PinsActive - rack.pinsStanding();



        scorer.Score(pinFall, shotNumber);
        if (pinFall == 10 && shotNumber%2 == 0)
        {
            shotNumber += 2;
            rack.ResetPins();
        }
        else
        {
            shotNumber += 1;
            PinsActive = 10 - pinFall;
        }
        if (shotNumber % 2 == 0)
        {
            rack.ResetPins();
            PinsActive = 10;
        }

        ball.BallReset();

    }
}
