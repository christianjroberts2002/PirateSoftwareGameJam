using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PaintCoverageVisualizerScript : MonoBehaviour
{
    [SerializeField] private float friendlyPaintCoverage;
    [SerializeField] private float enemyPaintCoverage;

    [SerializeField] private UnityEngine.UI.Slider friendlySlider;
    [SerializeField] private UnityEngine.UI.Slider enemySlider;

    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private float maxTiles;

    [SerializeField] TextMeshProUGUI levelText;

    private float levelTime;
    void Start()
    {
        maxTiles = PaintGridSystem.Instance.GetGridHeight() * PaintGridSystem.Instance.GetGridWidth();


        friendlySlider.maxValue = maxTiles;
        enemySlider.maxValue = maxTiles;

        DontDestroyOnLoad(this);
        
    }


    // Update is called once per frame
    void Update()
    {
        friendlySlider.value = PaintCoverageScript.Instance.GetFriendlyTiles();
        enemySlider.value = PaintCoverageScript.Instance.GetFriendlyTiles() + PaintCoverageScript.Instance.GetEnemyTiles();
        SetTimerText();
    }

    private void SetTimerText()
    {
        levelTime = GameManager.Instance.GetLevelTimer();

        int minutes = Mathf.FloorToInt(levelTime / 60);
        int seconds = Mathf.RoundToInt((int)levelTime % 60);    

        string levelTimeString = minutes + ":" + seconds;
        timerText.text = levelTimeString;
    }

    private void OnLevelWasLoaded(int level)
    {
        SetLevelText();
    }
    private void SetLevelText()
    {
        int level = GameManager.Instance.GetGameLevel();
        levelText.text = "Level " + level;
    }
}
