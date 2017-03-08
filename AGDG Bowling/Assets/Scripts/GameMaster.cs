using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster: MonoBehaviour {


    public int[] shots;
    public int shotNumber = 0;

    public GameObject gameOver;

    private PinRack rack;
    private ScoreKeeper scorer;
    private BallPrototype ball;
    private BallLight shotLight;
    private hidePanel helpPanel;


    private int PinsActive = 10;
    private int pinFall;



    // Use this for initialization
    void Start () {
        rack = FindObjectOfType<PinRack>();
        scorer = FindObjectOfType<ScoreKeeper>();
        ball = FindObjectOfType<BallPrototype>();
        shotLight = FindObjectOfType<BallLight>();
        helpPanel = FindObjectOfType<hidePanel>();
        shots = new int[21];
        for (int i = 0; i < 21; i++)
        {
            shots[i] = -1;
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("manualReset") && !IsInvoking("ShotFinished")) //User reset
        {
            ball.inPlay = false;
            ball.BallReset();
        }

        if (Input.GetButtonDown("manualNewGame"))
        {
            if (IsInvoking("ShotFinished"))
            {
                CancelInvoke();
                NewGame();

            }else
            {
                NewGame();
            }
        }

        if (Input.GetButtonDown("toggleHelp"))
        {
            if (helpPanel.isActive)
            {
                helpPanel.isActive = false;
                helpPanel.gameObject.SetActive(false);
            }else
            {
                helpPanel.isActive = true;
                helpPanel.gameObject.SetActive(true);
            }
        }
        
    }

    public void ShotFinished()
    {
        rack.TidyPins();
        pinFall = PinsActive - rack.pinsStanding();
        shots[shotNumber] = pinFall;
        scorer.Score(shots);

        if (shotNumber > 17)
        {
            TenFrameHandling(pinFall);
            return;
        }

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

        shotLight.setLight(shotNumber % 2);
        ball.BallReset();

    }

    void TenFrameHandling(int pinfall)
    {
        if (shotNumber > 17)       
        {
            if (pinFall == 10)
            {
                shotNumber += 1;
                rack.ResetPins();

                ball.BallReset();
            }else
            {
                shotNumber += 1;
                PinsActive = 10 - pinFall;
                ball.BallReset();
            }
        }
        if (shotNumber == 20)
        {
            if (!scorer.tenthAwarded)
            {
                EndGame();
            }else if (shots[19] == 10)
            {   }else
            {
                PinsActive = 10;
                rack.ResetPins();
            }
        }

        if (shotNumber > 20)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameOver.gameObject.SetActive(true);
        ball.inPlay = true;
    }

    public void NewGame()
    {
        for (int i = 0; i < 21; i++)
        {
            shots[i] = -1;
            shotNumber = 0;
        }
        rack.ResetPins();
        ball.BallReset();
        PinsActive = 10;
        scorer.clearFrames();
        gameOver.gameObject.SetActive(false);
    }

}
