using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private int score;
    private int highscore;
    public GameObject coin;
    public Text scoreText;
    public Text highscoreText;
    public Text timerText;
    public Button restartBtn;
    [HideInInspector] public float timer;

    private void Awake()
    {
        LoadScore();
    }

    private void Start()
    {
        timer = 15f;
        restartBtn.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Destroy(GameObject.Find("Player"));
            restartBtn.gameObject.SetActive(true);
        }
        else
        {
            timerText.text = "Количество топлива: " + (int)timer;
        }
    }

    public void SpawnCoin(float minX, float maxX, float minY, float maxY)
    {
        Vector2 posXposY = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(coin, posXposY, Quaternion.identity);
    }

    public void ChangeScore()
    {
        score++;
        scoreText.text = "Счет: " + score;
        if(score >= highscore)
        {
            highscore = score;
            highscoreText.text = "Рекорд: " + highscore;
            SaveScore();
        }
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("highscore", highscore);
        PlayerPrefs.Save();
    }

    private void LoadScore()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "Рекорд: " + highscore.ToString();
        scoreText.text = "Счет: " + 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
