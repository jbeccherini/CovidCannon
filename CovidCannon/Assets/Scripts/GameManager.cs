using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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

    public GameObject gameOverScreen;
    public static int numStartingBombs = 5;
    private static int[] numBombs = new int[4];

    public GameObject[] spawnable;

    private Transform startMarker;
    private Transform endMarker;

    public float spawnTime = 10;

    public int minSpawnY = 8;
    public int maxSpawnY = 13;
    public float minSpawnTime = 1.5f;
    public float maxSpawnTime = 3.5f;

    private int randPerson;

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

        startMarker = GameObject.Find("SpawnPoint1").transform;
        endMarker = GameObject.Find("EndPoint1").transform;

        StartCoroutine(Spawner());

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
        Debug.Log("You have a score of : " + score);
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

    private void gameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;



    }

    public IEnumerator Spawner()
    {
        while (true) 
        {
            float yPos = Random.Range(minSpawnY, maxSpawnY);
            float randSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            int randPerson = Random.Range(0,3);

            yield return new WaitForSeconds(randSpawnTime);

            GameObject person = Instantiate(spawnable[randPerson], new Vector3(-35f, yPos, 0f), Quaternion.identity);
        }
        

    }

}
