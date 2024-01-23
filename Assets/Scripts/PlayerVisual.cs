using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerVisual : MonoBehaviour
{
    Vector3 mousePos;

    private float angleCFloat;


    [SerializeField] private Sprite[] playerSprites;

    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] Sprite currentPlayerSprite;

    private Animator playerAnimator;

    private bool isLookingUp;

    private bool isDead;

    [SerializeField] private Light2D deathLight;
    [SerializeField] private Light2D globalLight;

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
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>(); 
        currentPlayerSprite = playerSprites[0];
        PlayerHealthScript.OnPlayerDeath += PlayerHealthScript_OnPlayerDeath;
        isDead = false;

        globalLight.intensity = 1;
        deathLight.enabled = isDead;

        playerAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            SetVisualBasedOnMouseAngle();
        }
        else
        {
            playerAnimator.SetBool("IsDead", isDead);
            deathLight.enabled = isDead;
            globalLight.intensity = 0;
        }
        
    }


    private void PlayerHealthScript_OnPlayerDeath(object sender, EventArgs e)
    {
        isDead = true;
    }

    private float GetAngleFromProjectionTriangle()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        Vector3 mouseDir = (transform.position - mousePos);

        //Debug.Log(mouseDir);


        Vector2 rightTriangleVector = transform.position + Vector3.up;
        float distancefromRighttoMouse = Vector3.Distance(rightTriangleVector, mouseDir);

        float sideA = Vector2.Distance(transform.position, rightTriangleVector);
        float sideB = Vector2.Distance(transform.position, mousePos);
        float sideC = Vector2.Distance(mousePos, rightTriangleVector);




        float cosC = (Mathf.Pow(sideA, 2) + Mathf.Pow(sideB, 2) - Mathf.Pow(sideC, 2)) / (2 * sideA * sideB);
        angleCFloat = Mathf.Acos(cosC) * 180 / Mathf.PI;
        //Debug.Log(angleCFloat);


        if (mouseDir.x < 0)
        {

        }
        else
        {
            angleCFloat = 180 + (Mathf.Abs(180 - angleCFloat));
        }

        return angleCFloat;

    }

    private void SetVisualBasedOnMouseAngle()
    {
        IGun currentGun = PlayerGun.Instance.GetCurrentGun();
        float inputAngle = GetAngleFromProjectionTriangle();
        int directionInt = 0;
        isLookingUp = false;
        //UP
        if (inputAngle > 315 || inputAngle < 45)
        {
            directionInt = 0;
            currentPlayerSprite = playerSprites[directionInt];
            isLookingUp = true;

        }
        //Down
        else if (inputAngle < 225 && inputAngle > 135)
        {
            directionInt = 1;
            currentPlayerSprite = playerSprites[directionInt];
            

        }
        //Left
        else if (inputAngle >= 225 && inputAngle <= 315)
        {
            directionInt = 2;
            currentPlayerSprite = playerSprites[directionInt];
        }
        //Right
        else if (inputAngle >= 45 && inputAngle <= 135)
        {
            directionInt = 3;
            currentPlayerSprite = playerSprites[directionInt];
           
        }

        playerAnimator.SetInteger("WalkingDirection", directionInt);
        playerSpriteRenderer.sprite = currentPlayerSprite;

    }

    public bool GetIsLookingUp()
    {
        return isLookingUp;
    }

    public float GetPlayerToCharacterAngle()
    {
        return angleCFloat;
    }

    
}

