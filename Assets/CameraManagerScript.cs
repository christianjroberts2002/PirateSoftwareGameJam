using Cinemachine;
using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerScript : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera lowerLeft;
    [SerializeField] private CinemachineVirtualCamera lowerRight;
    [SerializeField] private CinemachineVirtualCamera upperLeft;
    [SerializeField] private CinemachineVirtualCamera upperRight;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [SerializeField] private CinemachineFramingTransposer virtualCameraTransposer;


    [SerializeField] private float maxCameraX;
    [SerializeField] private float maxCameraY;


    private float gridSize;

    private Vector3 playerPosition;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        virtualCameraTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        float screenXResolution = Screen.width;
        float screenYResolution = Screen.height;

        gridSize = PaintGridSystem.Instance.GetGridHeight();
        maxCameraX = screenXResolution / gridSize;
        maxCameraY = screenYResolution / gridSize;

        lowerLeft.transform.position = new Vector3(maxCameraX, maxCameraY);
        lowerRight.transform.position = new Vector3(gridSize - maxCameraX, maxCameraY);
        upperLeft.transform.position = new Vector3(maxCameraX, gridSize - maxCameraY);
        upperRight.transform.position = new Vector3(gridSize - maxCameraX, gridSize - maxCameraY);
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = PlayerController.Instance.GetPlayerTransform();
        playerPosition = playerTransform.position;
        if (playerPosition.x < maxCameraX)
        {
            virtualCameraTransposer.m_TrackedObjectOffset.x = maxCameraX- virtualCamera.transform.position.x;
            virtualCameraTransposer.m_DeadZoneWidth = 2f;
            virtualCameraTransposer.m_SoftZoneWidth = 2f;

        }
        else
        {
            virtualCameraTransposer.m_DeadZoneWidth = .2f;
            virtualCameraTransposer.m_SoftZoneWidth = .8f;
        }
        
    }
}
