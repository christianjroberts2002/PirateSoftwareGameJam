using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private Canvas shopCanvas;

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

        playerInfoCanvasGroup = playerInfoCanvas.GetComponent<CanvasGroup>();

        deathCanvasGroup = deathCanvas.gameObject.GetComponent<CanvasGroup>();
        deathCanvasGroup.alpha = 0;
        deathCanvas.enabled = false;
    }

    private void Update()
    {
        levelTimer = GameManager.Instance.GetLevelTimer();

        if (levelTimer == 0)
        {
            OnPlayerWonLevel?.Invoke(this, EventArgs.Empty);
            playerInfoCanvasGroup.alpha -= alphaEaseInNOut * Time.deltaTime;

        }

        if (isDead)
        {
            playerInfoCanvasGroup.alpha -= alphaEaseInNOut * Time.deltaTime;
            if (deathAnimationDone)
            {
                deathCanvasGroup.alpha += alphaEaseInNOut * Time.deltaTime;
            }

        }
    }
    private void PlayerHealthScript_OnPlayerDeath(object sender, EventArgs e)
    {
        StartCoroutine(WaitForDeathAnimation(deathAnimationTime));
        deathCanvas.enabled = true;
    }

    private IEnumerator WaitForDeathAnimation(float animationTime)
    {
        isDead = true;
        yield return new WaitForSeconds(animationTime);
        deathAnimationDone = true;
    }


    public void StartTimer()
    {
        timerRunning = true;
    }

}
