using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text scoreText;
    public Text highscoreText;
    public Text levelText;
    public GameObject startMenu;
    public GameObject lastScore;

    public GameObject player;

    public static int score;
    public static int destroyCounter;

    public static bool gameStart;

    private int highscore;
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        //highscore = 0; //reset highscore
        level = 1;
        SpawnEnemys.spawnFactor = level;
        BgScript.moveSpeed = -level;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text=("Score: " + score);
        highscoreText.text=("Highscore: " + highscore);
        SetLevel();
        if (score>highscore)
        {
            highscore = score;
        }

    }

    public void StartGame()
    {
        gameStart = true;
        score = 0;
        level = 1;
        startMenu.GetComponent<CanvasGroup>().alpha = 0;
        scoreText.gameObject.SetActive(true);
        lastScore.SetActive(false);
        levelText.gameObject.SetActive(true);
        ClearScene();
        Instantiate(player, transform.position, Quaternion.Euler(0,0,90));
        GameObject.Find("AstroText").GetComponent<CanvasGroup>().alpha = 0;
    }


    public void EndGame()
    {
        gameStart = false;
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
        scoreText.gameObject.SetActive(false);
        lastScore.SetActive(true);
        if (score>=highscore)
        {
            lastScore.GetComponent<Text>().text = ("!!! NEW HIGHSCORE !!! \n" + score);
        }
        else
        {
        lastScore.GetComponent<Text>().text = ("Your Score: \n" + score);
        }
        PlayerPrefs.SetInt("highscore", highscore);
    }

    private void ClearScene()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(item);
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("EnemySpaceShip"))
        {
            Destroy(item);
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Astro"))
        {
            Destroy(item);
        }
    }

    private void SetLevel()
    {
        if (destroyCounter>=10)
        {
            level++;
            destroyCounter = 0;
        }
            SpawnEnemys.spawnFactor = level;
            BgScript.moveSpeed = -level;
        levelText.text = ("Level: " + level);

    }
}
