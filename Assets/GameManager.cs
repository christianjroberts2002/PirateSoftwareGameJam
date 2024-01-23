using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float levelTimer;

    [SerializeField] private float timerMultiplier;

    private bool timerRunning;

    private int startingGameScene = 1;

    public static GameManager Instance;

    private int gameLevel = 1;





    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        levelTimer = 60 + (gameLevel * timerMultiplier);
    }

    private void Update()
    {
        if (timerRunning)
        {
            if (levelTimer > 0)
            {
                levelTimer -= Time.deltaTime;
            }
            else
            {
                levelTimer = 0;
            }

        }
    }

    public void StartGame()
    {
       
        SceneManager.LoadScene(startingGameScene);
    }

    private void OnLevelWasLoaded(int level)
    {
        StartTimer();
        levelTimer = 60 + (gameLevel * timerMultiplier);
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public int GetGameLevel()
    {
        return gameLevel;
    }

    public void SetGameLevel(int gameLevel)
    {
        this.gameLevel = gameLevel; 
    }

    public float GetLevelTimer()
    {
        return levelTimer;
    }

    public void SetLevelTimer(float levelTimer)
    {
        this.levelTimer = levelTimer;
    }

    

}
