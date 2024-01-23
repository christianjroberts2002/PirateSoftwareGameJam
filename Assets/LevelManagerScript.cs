using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    private int level;

    [SerializeField] private GameObject[] goToDestroyOnLoadOfMainMenu;

    public static LevelManagerScript Instance;

    


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
    public void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void LoadMainMenu()
    {
        foreach(GameObject go in goToDestroyOnLoadOfMainMenu)
        {
            Destroy(go);
        }
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
    }

   public void LoadNextLevel()
    {
        level = GameManager.Instance.GetGameLevel();
        level++;
        GameManager.Instance.SetGameLevel(level);
        SceneManager.LoadScene(level);
    }


    public void LoadNextLevelInfinite()
    {
        level = GameManager.Instance.GetGameLevel();
        level++;
        GameManager.Instance.SetGameLevel(level);
        SceneManager.LoadScene(2);
    }
}
