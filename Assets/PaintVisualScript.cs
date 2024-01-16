using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintVisualScript : MonoBehaviour
{
    private Color green;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] paintSprites;

    [SerializeField] private int GRID_HEIGHT;
    [SerializeField] private int GRID_WIDTH;

    private float CELL_SIZE;

    private int gridValue;



    void Start()
    {
        green = Color.green;
        spriteRenderer = GetComponent<SpriteRenderer>();
        CELL_SIZE = PaintGridSystem.Instance.GetCellSize();
        GRID_HEIGHT = (int)(PaintGridSystem.Instance.GetGridHeight() - 1);
        GRID_WIDTH = (int)(PaintGridSystem.Instance.GetGridWidth() - 1);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FriendlyBullet")
        {
            spriteRenderer.color = green;
            Debug.Log("collision");
            gameObject.layer = 7;
        }
        
    }

    private void Update()
    {
        CheckGridNeighbors();
        SetPaintSprite();

    }

    private void CheckGridNeighbors()
    {
        if(gameObject.layer == 8)
        {
            return;
        }

        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        PaintGridSystem.GridPosition thisGridPosition = PaintGridSystem.Instance.GetGridPosition(pos);
        int xPos = (int)thisGridPosition.x;
        int yPos = (int)thisGridPosition.y;
        gridValue = 0;

        //Up
        if (yPos + 1 < GRID_HEIGHT)
        {
            if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos, yPos + 1))
                gridValue += 5;
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
                gridValue += 41;
            //Right
            if (xPos + 1 < GRID_WIDTH)
            {
                if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos + 1, yPos - 1))
                {
                    //gridValue += 43;
                }

            }

            //Left
            if (xPos - 1 >= 0)
            {
                if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos - 1, yPos - 1))
                {
                    //gridValue += 37;
                }

            }
        }

        //Left
        if (xPos - 1 >= 0)
        {
            if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos - 1, yPos))
                gridValue += 17;
        }


        //Right
        if (xPos + 1 < GRID_WIDTH)
        {
            if (PaintGridSystem.Instance.GetIsFriendlyPaint(xPos + 1, yPos))
                gridValue += 23;
        }
        Debug.Log(gridValue);
    }

    private void SetPaintSprite()
    {
        switch(gridValue)
        {
            //5 combinations
            case 5:
                spriteRenderer.sprite = paintSprites[0]; 
                break;
            case 22:
                spriteRenderer.sprite = paintSprites[1];
                break;
            case 28:
                spriteRenderer.sprite = paintSprites[2];//needsSprite
                break;
            case 46:
                spriteRenderer.sprite = paintSprites[3];
                break;
            case 45:
                spriteRenderer.sprite = paintSprites[4];//NeedsSprite
                break;
                //All Together
            case 86:
                spriteRenderer.sprite = paintSprites[5];
                break;
            //17
            case 17:
                spriteRenderer.sprite = paintSprites[6];
                break;
            case 40:
                spriteRenderer.sprite = paintSprites[7];//NeedsSprite 
                break;
            case 58:
                spriteRenderer.sprite = paintSprites[8];
                break;
            case 81:
                spriteRenderer.sprite = paintSprites[9];
                break;
            //23
            case 23: 
                spriteRenderer.sprite = paintSprites[10];
                break;
            case 64:
                spriteRenderer.sprite = paintSprites[11];
                break;
            //41
            case 41:
                spriteRenderer.sprite = paintSprites[12];   
                break;
            default:
                spriteRenderer.color = Color.red;
                break;



        }
    }

}
