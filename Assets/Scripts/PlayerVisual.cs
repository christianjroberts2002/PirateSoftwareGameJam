using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    Vector3 mousePos;

    [SerializeField] private GameObject rightVisual;

    [SerializeField] private Sprite[] playerSprites;

    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] Sprite currentPlayerSprite;



    private bool isLookingUp;

    public static PlayerVisual Instance;

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
        playerSpriteRenderer = GetComponent<SpriteRenderer>(); 
        currentPlayerSprite = playerSprites[0];
        
    }

    // Update is called once per frame
    void Update()
    {

        SetVisualBasedOnMouseAngle();
    }

    private float GetAngleFromProjectionTriangle()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 mouseDir = (transform.position - mousePos);

        //Debug.Log(mouseDir);


        Vector2 rightTriangleVector = transform.position + Vector3.up;
        rightVisual.transform.position = rightTriangleVector;
        float distancefromRighttoMouse = Vector3.Distance(rightTriangleVector, mouseDir);

        float sideA = Vector2.Distance(transform.position, rightTriangleVector);
        float sideB = Vector2.Distance(transform.position, mousePos);
        float sideC = Vector2.Distance(mousePos, rightTriangleVector);




        float cosC = (Mathf.Pow(sideA, 2) + Mathf.Pow(sideB, 2) - Mathf.Pow(sideC, 2)) / (2 * sideA * sideB);
        float angleCFloat = Mathf.Acos(cosC) * 180 / Mathf.PI;
        //Debug.Log(angleCFloat);


        if (mouseDir.x < 0)
        {

        }
        else
        {
            angleCFloat = 180 + (Mathf.Abs(180 - angleCFloat));
        }

        Debug.Log(angleCFloat);
        return angleCFloat;

    }

    private void SetVisualBasedOnMouseAngle()
    {
        IGun currentGun = PlayerGun.Instance.GetCurrentGun();
        float inputAngle = GetAngleFromProjectionTriangle();
        isLookingUp = false;
        //UP
        if (inputAngle > 315 || inputAngle < 45)
        {
            currentPlayerSprite = playerSprites[0];
            isLookingUp = true;

        }
        //Down
        else if (inputAngle < 225 && inputAngle > 135)
        {
            currentPlayerSprite = playerSprites[1];
            

        }
        //Left
        else if (inputAngle >= 225 && inputAngle <= 315)
        {
            currentPlayerSprite = playerSprites[2];
        }
        //Right
        else if (inputAngle >= 45 && inputAngle <= 135)
        {
            currentPlayerSprite = playerSprites[3];
           
        }

        playerSpriteRenderer.sprite = currentPlayerSprite;

    }

    public bool GetIsLookingUp()
    {
        return isLookingUp;
    }

    
}

