using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System;

public class GameControl : MonoBehaviour
{

    public static GameControl instance;
    public GameObject GameOverText;
    public Text scoreText;
    public bool GameOver = false;
    public float scrollSpeed = -1.5f;

    private int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void BirdScored()
    {
        if (GameOver)
        {
            return;
        }

        score++;
        scoreText.text = "Score" + score.ToString();
    }
    public void BirdDied()
    {
        GameOverText.SetActive(true);
        GameOver = true;
    }
}

 
