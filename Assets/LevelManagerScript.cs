using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    private int level;


    public void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

   public void LoadNextLevel()
    {
        level = GameManager.Instance.GetGameLevel();
        level++;
        GameManager.Instance.SetGameLevel(level);
        SceneManager.LoadScene(level);
    }
}
