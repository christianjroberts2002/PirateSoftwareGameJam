using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class PaintCoverageScript : MonoBehaviour
{

    private int GRID_HEIGHT;
    private int GRID_WIDTH;
    private int GRID_SIZE;

    [SerializeField] private float friendlyTiles;
    [SerializeField] private float enemyTiles;

    [SerializeField] private float playerPercentCovered;
    [SerializeField] private float enemyPercentCovered;

    public static PaintCoverageScript Instance;

    private void Awake()
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
    void Start()
    {
        GRID_HEIGHT = PaintGridSystem.Instance.GetGridHeight();
        GRID_WIDTH = PaintGridSystem.Instance.GetGridWidth();
        GRID_SIZE = GRID_WIDTH * GRID_HEIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        GetNumberOfFreindlyTiles();

        CheckTilePercentCovered();


    }

    private void GetNumberOfFreindlyTiles()
    {
        friendlyTiles = 0;
        enemyTiles = 0;

        for (int x = 0; x < GRID_WIDTH; x++)
        {
            for (int y = 0; y < GRID_HEIGHT; y++)
            {
                if (PaintGridSystem.Instance.GetIsFriendlyPaint(x, y))
                {
                    friendlyTiles++;
                }
                else
                {
                    enemyTiles++;
                }
                
            }
        }
    }

    private void CheckTilePercentCovered()
    {
        playerPercentCovered = (friendlyTiles / GRID_SIZE) * 100;
        enemyPercentCovered = (enemyTiles / GRID_SIZE) * 100;
    }

    public float GetPlayerPercentCovered()
    {
        return playerPercentCovered;
    }

    public float GetEnemyPercentCovered()
    {
        return enemyPercentCovered;
    }
}
