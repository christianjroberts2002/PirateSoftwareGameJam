using Cinemachine;
using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerScript : MonoBehaviour
{

    [SerializeField] private float maxCameraX;
    [SerializeField] private float maxCameraY;


    private float gridSize;
    private float cellSize;

    private PolygonCollider2D polygonCollider;

    // Start is called before the first frame update
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        float screenXResolution = Screen.width;
        float screenYResolution = Screen.height;


        cellSize = PaintGridSystem.Instance.GetCellSize();
        gridSize = PaintGridSystem.Instance.GetGridHeight();
        maxCameraX = screenXResolution / (gridSize);
        maxCameraY = screenYResolution / (gridSize);


        polygonCollider = GetComponent<PolygonCollider2D>();

        Vector2[] polygonPoints = new Vector2[]
        {
            new Vector2(gridSize, 0), //BottomRight
            new Vector2(gridSize, gridSize), //TopRight
            new Vector2(0, gridSize), //TopLeft
            new Vector2(0, 0)//BottomLeft
        };

        polygonCollider.points = polygonPoints;
    }

}
