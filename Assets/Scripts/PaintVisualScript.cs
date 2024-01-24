using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PaintVisualScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] paintSprites;
    [SerializeField] private Sprite[] randomPaintSpotchSprites;
    [SerializeField] private Sprite[] randomEnemyPaintSpotchSprites;

    [SerializeField] private int GRID_HEIGHT;
    [SerializeField] private int GRID_WIDTH;

    private float CELL_SIZE;

    [SerializeField] private int gridValue;


    [SerializeField] private float repeatRate;

    






    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CELL_SIZE = PaintGridSystem.Instance.GetCellSize();
        GRID_HEIGHT = (int)(PaintGridSystem.Instance.GetGridHeight() - 1);
        GRID_WIDTH = (int)(PaintGridSystem.Instance.GetGridWidth() - 1);

        

    }


    private void Update()
    {
        //CheckGridNeighbors();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FriendlyBullet")
        {

            gameObject.layer = 7;

            
            PaintGridSystem.GridPosition gridPosition = PaintGridSystem.Instance.GetGridPosition(new Vector2(1, 1));

            if (gameObject.tag != "Obstacle")
            {
                AssignRandomPaintSpotch();
            }
            

        }

        if (collision.tag == "Enemy" || collision.tag == "EnemyBullet")
        {
            if(gameObject.layer == 7)
            {
                EnemyHealthScript enemyHealthScript = collision.GetComponent<EnemyHealthScript>();
                float enemyHealth = enemyHealthScript.GetEnemyHealth();
                enemyHealthScript.TakeDamager(enemyHealth, 1f);
                enemyHealthScript.SetSliderValue(enemyHealth);

                //EnemySpeed
                EnemyScript enemyScript = collision.GetComponent<EnemyScript>();
                float enemySpeed = enemyScript.GetEnemySpeed();

                float enemyPaintCollisionSlowdown = enemyHealthScript.GetEnemyPaintSlowdown();
                if (enemySpeed > 0 + enemyPaintCollisionSlowdown)
                {
                    float newEnemySpeed = enemySpeed * enemyPaintCollisionSlowdown;
                    enemyScript.SetEnemySpeed(newEnemySpeed);
                }
                if (enemyHealth <= 0)
                {
                    Destroy(collision.gameObject);
                }
            }

            gameObject.layer = 8;
            
            
            if(gameObject.tag != "Obstacle")
            {
                AssignRandomEnemyPaintSpotch();
            }
            
        }

    }


    private void AssignRandomPaintSpotch()
    {

        int randomSprite = UnityEngine.Random.Range(0, randomPaintSpotchSprites.Length);
        spriteRenderer.sprite = randomPaintSpotchSprites[randomSprite];
    }

    private void AssignRandomEnemyPaintSpotch()
    {
        int randomSprite = UnityEngine.Random.Range(0, randomPaintSpotchSprites.Length);
        spriteRenderer.sprite = randomEnemyPaintSpotchSprites[0];
    }

    private void CheckGridNeighbors()
    {
        if (gameObject.layer == 8)
        {
            return;
        }

        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        PaintGridSystem.GridPosition thisGridPosition = PaintGridSystem.Instance.GetGridPosition(pos);
        int xPos = (int)thisGridPosition.x;
        int yPos = (int)thisGridPosition.y;

        //Up
        if (yPos + 1 < GRID_HEIGHT)
        {
            if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos, yPos + 1))
            {

            }
            //Right
            if (xPos + 1 < GRID_WIDTH)
            {
                if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos + 1, yPos + 1))
                {
                    //gridValue += 7;
                }

            }

            //Left

            if (xPos - 1 >= 0)
            {
                if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos - 1, yPos + 1))
                {
                    //gridValue += 3;
                }

            }
        }


        //Down

        if (yPos - 1 >= 0)
        {
            if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos, yPos - 1))
            {

            }
            //Right
            if (xPos + 1 < GRID_WIDTH)
            {
                if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos + 1, yPos - 1))
                {
                    
                }

            }

            //Left
            if (xPos - 1 >= 0)
            {
                if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos - 1, yPos - 1))
                {
                    
                    
                }

            }
        }

        //Left
        if (xPos - 1 >= 0)
        {
            if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos - 1, yPos))
            {

            }
                
        }


        //Right
        if (xPos + 1 < GRID_WIDTH)
        {
            if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos + 1, yPos))
            {

            }
                
        }
        
    }

    private void SetPaintSprite()
    {
       
    }

}