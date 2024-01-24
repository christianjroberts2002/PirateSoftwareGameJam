using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    private int startingGameScene = 1;
    public void StartGameButton()
    {

        SceneManager.LoadScene(startingGameScene);
    }
}
