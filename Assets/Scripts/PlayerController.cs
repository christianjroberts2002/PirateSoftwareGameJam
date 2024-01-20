using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedDecreaserInEnemyPaint = .12f;
    [SerializeField] float speedIncreaseInFreindlyPaint = .12f;
    private Vector3 startingPosition;

    [SerializeField] private float playerSpeedX;
    [SerializeField] private float playerSpeedY;

    [SerializeField] private float speedBonus;
    [SerializeField] private float speedMultiplier;

    [SerializeField] private LayerMask friendlyPaint;
    [SerializeField] private LayerMask enemyPaint;

    [SerializeField] private float maxXPosition;
    [SerializeField] private float maxYPosition;

    private float cellSize;
    private float gridSize;

    private const float PLAYER_OFFSET = .25f;

    private Animator playerAnimator;

    private Rigidbody2D playerRB;

    private bool isWalking;

    public enum OnFootTile
    {
        Neutral,
        Friendly,
        Enemy
    }

    public OnFootTile onFootTile;

    public static PlayerController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        startingPosition = gameObject.transform.position;
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);

        cellSize = PaintGridSystem.Instance.GetCellSize();
        gridSize = PaintGridSystem.Instance.GetGridHeight();

        maxXPosition = (cellSize * gridSize);
        maxYPosition = (cellSize * gridSize);
    }

    private void OnLevelWasLoaded(int level)
    {
        //Put him in the center
        transform.position = new Vector3((gridSize * cellSize)/2, (gridSize * cellSize) / 2);
    }

    private void Update()
    {
        MovePlayer();
        
        DetectPaintWalkingOn();
    }

    private void LateUpdate()
    {
         
    }

    private void MovePlayer()
    {
        float ySpeed = playerSpeedY * Input.GetAxis("Vertical");
        float xSpeed = playerSpeedY * Input.GetAxis("Horizontal");
        float paintCoverage = PaintCoverageScript.Instance.GetPlayerPercentCovered();
        if(onFootTile == OnFootTile.Friendly)
        {
            float maxSpeedBonus = speedMultiplier * (paintCoverage / 100) + 1;
            if (speedBonus <= maxSpeedBonus)
            {
                speedBonus += speedIncreaseInFreindlyPaint;
            }
            
        }else if(onFootTile == OnFootTile.Enemy)
        {
            if(speedBonus >= 0)
            {
                speedBonus -= speedDecreaserInEnemyPaint;

            }
        }
        else
        {
            if(speedBonus >= 1)
            {
                speedBonus -= speedDecreaserInEnemyPaint;

            }
        }
        isWalking = false;
        
        //Up
        if (Input.GetAxis("Vertical") > 0 && transform.position.y < maxYPosition - PLAYER_OFFSET)
        {
            transform.position += Vector3.up * ySpeed * speedBonus * Time.deltaTime;
            isWalking = true;
        }

        //Down
        if (Input.GetAxis("Vertical") < 0 && transform.position.y > cellSize + PLAYER_OFFSET)
        {
            transform.position += Vector3.down * -ySpeed * speedBonus * Time.deltaTime;
            isWalking = true;
        }


        //Right
        if (Input.GetAxis("Horizontal") > 0 && transform.position.x < maxXPosition)
        {
            transform.position += Vector3.right * xSpeed * speedBonus * Time.deltaTime;
            isWalking = true;
        }

        //Left
        if (Input.GetAxis("Horizontal") < 0 && transform.position.x > cellSize)
        {
            transform.position += Vector3.left * -xSpeed * speedBonus * Time.deltaTime;
            isWalking = true;
        }

        playerAnimator.SetBool("IsWalking", isWalking);
    }


    public void SetSpeedMultiplier(float speedBonus)
    {
        this.speedBonus = speedBonus;
    }

    private void DetectPaintWalkingOn()
    {
        float feetOffset = -.6f;
        float feetMaxDistance = .12f;
        Vector3 feetposition = transform.position + new Vector3 (0, feetOffset, 0);
        Debug.DrawRay(feetposition, Vector3.down * feetMaxDistance, Color.black);
        if (Physics2D.Raycast(feetposition, Vector3.down, feetMaxDistance, enemyPaint))
        {
            onFootTile = OnFootTile.Enemy;
        }
        else if (Physics2D.Raycast(feetposition, Vector3.down, feetMaxDistance, friendlyPaint))
        {
            onFootTile = OnFootTile.Friendly;
        }
        else
        {
            onFootTile = OnFootTile.Neutral;
        }
    }

    public Transform GetPlayerTransform()
    {
        return gameObject.transform;  
    }
}
