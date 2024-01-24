using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] private float levelTimer;

    [SerializeField] private float timerMultiplier;

    private bool timerRunning;

    public static event EventHandler OnPlayerWonLevel;

    [SerializeField] private Canvas playerInfoCanvas;
    [SerializeField] private CanvasGroup playerInfoCanvasGroup;

    [SerializeField] private Canvas deathCanvas;
    [SerializeField] private CanvasGroup deathCanvasGroup;

    private int gameLevel = 1;

    private float deathAnimationTime = 1.5f;

    [SerializeField] private Canvas nextLevelCanvas;
    [SerializeField] private CanvasGroup nextLevelCanvasGroup;

    [SerializeField] private Canvas shopCanvas;
    [SerializeField] private CanvasGroup shopCanvasGroup;  

    private float alphaEaseInNOut = 3f;

    private bool isDead;
    private bool deathAnimationDone;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartTimer();
        levelTimer = GameManager.Instance.GetLevelTimer();

        PlayerHealthScript.OnPlayerDeath += PlayerHealthScript_OnPlayerDeath;
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;

        deathCanvasGroup.alpha = 0;
        deathCanvas.enabled = false;

        
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        playerInfoCanvasGroup.alpha = 1;
        deathCanvasGroup.alpha = 0;
        nextLevelCanvasGroup.alpha = 0;
        shopCanvasGroup.alpha = 0;
    }

    private void OnLevelWasLoaded(int level)
    {
        playerInfoCanvasGroup.alpha = 1;
        deathCanvasGroup.alpha = 0;
        nextLevelCanvasGroup.alpha = 0;
        shopCanvasGroup.alpha = 0;
    }

    private void Update()
    {
        levelTimer = GameManager.Instance.GetLevelTimer();

        if (levelTimer == 0)
        {
            OnPlayerWonLevel?.Invoke(this, EventArgs.Empty);
            playerInfoCanvasGroup.alpha -= alphaEaseInNOut * Time.unscaledDeltaTime;

        }

        if (isDead)
        {
            playerInfoCanvasGroup.alpha -= alphaEaseInNOut * Time.unscaledDeltaTime;
            if (deathAnimationDone)
            {
                deathCanvasGroup.alpha += alphaEaseInNOut * Time.unscaledDeltaTime;
            }

        }
    }
    private void PlayerHealthScript_OnPlayerDeath(object sender, EventArgs e)
    {
        Time.timeScale = 0;
        StartCoroutine(WaitForDeathAnimation(deathAnimationTime));
        deathCanvas.enabled = true;
    }

    private IEnumerator WaitForDeathAnimation(float animationTime)
    {
        isDead = true;
        yield return new WaitForSecondsRealtime(animationTime);
        deathAnimationDone = true;
    }


    public void StartTimer()
    {
        timerRunning = true;
    }

    public void OnDestroy()
    {
        PlayerHealthScript.OnPlayerDeath -= PlayerHealthScript_OnPlayerDeath;
        SceneManager.activeSceneChanged -= SceneManager_activeSceneChanged;
    }

}
