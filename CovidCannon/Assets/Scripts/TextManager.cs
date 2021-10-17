using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static GameObject scoreText;
    public static GameObject timerText;
    public static GameObject maskBombText;
    public static GameObject disinfectBombText;
    public static GameObject isolationBombText;
    public static GameObject soundBombText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreText");
        timerText = GameObject.Find("TimerText");
        maskBombText = GameObject.Find("MaskCounterText");
        disinfectBombText = GameObject.Find("DisinfectCounterText");
        isolationBombText = GameObject.Find("IsolationCounterText");
        soundBombText = GameObject.Find("SoundCounterText");

        updateScore();
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer();
        updateBombInventory();
    }

    public static void updateScore() 
    {
        scoreText.GetComponent<Text>().text = "Score: "+GameManager.getScore();
    }
    
    public static void updateTimer() 
    {
        timerText.GetComponent<Text>().text = "Time: "+Math.Round(GameManager.getRemainingTime(), 2);
    }
    public static void updateBombInventory() 
    {
        maskBombText.GetComponent<Text>().text = ""+GameManager.getNumBombs(0);
        disinfectBombText.GetComponent<Text>().text = "" + GameManager.getNumBombs(1);
        isolationBombText.GetComponent<Text>().text = "" + GameManager.getNumBombs(2);
        soundBombText.GetComponent<Text>().text = "" + GameManager.getNumBombs(3);
    }
}
