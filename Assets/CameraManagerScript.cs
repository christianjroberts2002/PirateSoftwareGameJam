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
    void Update()
    {
        //float screenXResolution = Screen.width;
        //float screenYResolution = Screen.height;

        
        //cellSize = PaintGridSystem.Instance.GetCellSize();
        //gridSize = PaintGridSystem.Instance.GetGridHeight();
        //maxCameraX = screenXResolution/(gridSize);
        //maxCameraY = screenYResolution/(gridSize);


        //polygonCollider = GetComponent<PolygonCollider2D>();

        //Vector2[] polygonPoints = new Vector2[]
        //{
        //    new Vector2(gridSize - maxCameraX, maxCameraY), //BottomRight
        //    new Vector2(gridSize - maxCameraX, gridSize - maxCameraY), //TopRight
        //    new Vector2(maxCameraX, gridSize - maxCameraY), //TopLeft
        //    new Vector2(maxCameraX, maxCameraY)//BottomLeft
        //};

        //polygonCollider.points = polygonPoints;

        
    }

}
