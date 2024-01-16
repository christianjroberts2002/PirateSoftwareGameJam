using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintGridSystem : MonoBehaviour
{
    [SerializeField] GameObject gridSystemVisualPrefab;

    //The height of the Grid
    //The width of the Grid
    [SerializeField] private float GRID_HEIGHT;
    [SerializeField] private float GRID_WIDTH;



    //Height of each CELL
    //Width of each CELL

    [SerializeField] private float CELL_HEIGHT;
    [SerializeField] private float CELL_WIDTH;

    //create grid
    private void Awake()
    {
        CreatGrid();
    }

    private void CreatGrid()
    {
        for(int x = 0; x < GRID_HEIGHT; x++)
        {
            for (int y = 0; y <= GRID_WIDTH; y++)
            {
                float xPos = CELL_HEIGHT * x;
                float yPos = CELL_HEIGHT * y;
                Vector3 cellPosition = new Vector3(xPos, yPos, 0);
                GameObject newCell = Instantiate(gridSystemVisualPrefab, cellPosition, Quaternion.identity);
            }
        }
    }
    //greategameobject 
    //for x
    //for y
    //create gameobject prefab


}
