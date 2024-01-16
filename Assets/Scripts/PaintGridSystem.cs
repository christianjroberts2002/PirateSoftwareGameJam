using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PaintGridSystem : MonoBehaviour
{
    //Needs to be all positive numbers

    [SerializeField] GameObject gridSystemVisualPrefab;

    //The height of the Grid
    //The width of the Grid
    [SerializeField] private float GRID_HEIGHT;
    [SerializeField] private float GRID_WIDTH;



    //Height of each CELL
    //Width of each CELL

    [SerializeField] private float CELL_HEIGHT;
    [SerializeField] private float CELL_WIDTH;

    [SerializeField] private Vector2 startingPos;

    public struct GridPosition
    {
        public float x, y;
        public GameObject gameObject;
    }

    public GridPosition[,] gridPositions;
    public int gridPositionsInt = 0;

    public static PaintGridSystem Instance;

    //create grid
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
        gridPositions = new GridPosition[(int)GRID_HEIGHT, (int)GRID_WIDTH];
        CreateGrid();
    }

    private void Start()
    {
    }

    private void CreateGrid()
    {
        for(int x = 0; x < GRID_HEIGHT; x++)
        {
            for (int y = 0; y < GRID_WIDTH; y++)
            {
                
                float xPos = CELL_HEIGHT * x + startingPos.x;
                float yPos = CELL_HEIGHT * y + startingPos.y;
                Vector3 cellPosition = new Vector3(xPos, yPos, 0);
                GameObject newCell = Instantiate(gridSystemVisualPrefab, cellPosition, Quaternion.identity);
                gridPositions[x,y].x = x;
                gridPositions[x,y].y = y;
                gridPositions[x,y].gameObject = newCell;
                gridPositionsInt++;

            }
        }
    }


    public GridPosition GetGridPosition(Vector2 worldVector2)
    {
        return gridPositions[(int)(worldVector2.x * (1/CELL_WIDTH)), (int)(worldVector2.y * (1/CELL_HEIGHT))];
    }

    public bool GetIsFriendlyPaint(int x, int y)
    {
        if(gridPositions[x,y].gameObject.layer == 7)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetGridHeight()
    {
        return (int)(GRID_HEIGHT);
        
    }

    public int GetGridWidth()
    {
        return (int)(GRID_WIDTH);
        
    }

    public float GetCellSize()
    {
        return CELL_HEIGHT;
    }



}
