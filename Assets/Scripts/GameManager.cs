using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float levelTimer;

    [SerializeField] private float timerMultiplier;

    private bool timerRunning;

    private int startingGameScene = 1;

    public static GameManager Instance;

    [SerializeField] private int gameLevel = 1;


    [SerializeField] private float defaultLevelTime;





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
        DontDestroyOnLoad(gameObject);
        PlayerHealthScript.OnPlayerDeath += PlayerHealthScript_OnPlayerDeath;
        levelTimer = defaultLevelTime + (gameLevel * timerMultiplier);
    }

    private void PlayerHealthScript_OnPlayerDeath(object sender, EventArgs e)
    {
        Time.timeScale = 0;
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

                LevelManagerScript.Instance.LoadNextLevelInfinite();
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
        levelTimer = defaultLevelTime + (gameLevel * timerMultiplier);
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
