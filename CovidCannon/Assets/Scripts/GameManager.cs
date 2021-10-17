using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int score = 0;
    public float timeLimit = 30;
    public static int numMaskBombs;
    public static int numDisinfectBombs;
    public static int numIsolationBombs;
    public static int numSoundBombs;
    public static float timeRemaining;

    public static bool isGameOver = false;

    public int gameOverScore = -5;

    public static GameObject gameOverScreen;
    public static int numStartingBombs = 5;
    private static int[] numBombs = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeLimit;
        dispayScore();

        for (int i = 0; i < numBombs.Length; i++)
        {
            numBombs[i] = numStartingBombs;
        }

        gameOverScreen = GameObject.Find("GameOverScreen");

        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) 
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                score--;
                TextManager.updateScore();
                timeRemaining = timeLimit;
            }

            if (score <= gameOverScore)
            {
                gameOver();
            }
        }
    }

    public static void changeScore(int num) 
    {
        score += num;
        dispayScore();
        TextManager.updateScore();
    }

    public static int getScore() 
    {
        return score;
    }

    public static void dispayScore() 
    {
        Debug.Log("You have a score of : "+score);
    }

    public static float getRemainingTime() 
    {
        return timeRemaining;
    }

    public static void changeNumBombs(int index, int num)
    {
        numBombs[index] += num;
    }

    public static int getNumBombs(int index) 
    {
        return numBombs[index];
    }

    private static void gameOver() 
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;



    }

}
