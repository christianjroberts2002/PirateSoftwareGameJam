using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int startingGameScene = 1;

    public static GameManager Instance;

    private int gameLevel;

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
    }

    public void StartGame()
    {
       
        SceneManager.LoadScene(1);
    }

    public int GetGameLevel()
    {
        return gameLevel;
    }

    public void SetGameLever(int gameLevel)
    {
        this.gameLevel = gameLevel; 
    }

}
