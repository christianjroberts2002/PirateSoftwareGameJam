using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunVisual : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private int layerAboveGun = 5;
    private int layerBelowGun = 0;



    [SerializeField] SpriteRenderer playerGunSpriteRenderer;
    [SerializeField] Sprite currentGunPlayerSprite;

    private bool isLookingUp;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        Vector2 lookDir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.right = lookDir;

        SetGunLayer();

        SetGunVisualBasedOnMouseAngle();


    }

    private void SetGunLayer()
    {
        bool isLookingUp = PlayerVisual.Instance.GetIsLookingUp();
        IGun currentGun = PlayerGun.Instance.GetCurrentGun();
        if (isLookingUp)
        {
            currentGun.SetSpriteOrderInLayer(layerBelowGun);
        }
        else
        {
            currentGun.SetSpriteOrderInLayer(layerAboveGun);
        }
        

    }

    private void SetGunVisualBasedOnMouseAngle()
    {
        IGun currentGun = PlayerGun.Instance.GetCurrentGun();
        float inputAngle = PlayerVisual.Instance.GetPlayerToCharacterAngle();
        isLookingUp = false;
        SpriteRenderer spriteRenderer = currentGun.GetSpriteRenderer();
        //UP
        if (inputAngle > 315 || inputAngle < 45)
        {
            currentGunPlayerSprite = currentGun.GunSprites[0];
            isLookingUp = true;

        }
        //Down
        else if (inputAngle < 225 && inputAngle > 135)
        {
            currentGunPlayerSprite = currentGun.GunSprites[1];

        }
        //Left
        else if (inputAngle >= 225 && inputAngle <= 315)
        {
            currentGunPlayerSprite = currentGun.GunSprites[2];
            
        }
        //Right
        else if (inputAngle >= 45 && inputAngle <= 135)
        {
            currentGunPlayerSprite = currentGun.GunSprites[3];
            

        }

        if(inputAngle < 180)
        {
            spriteRenderer.flipY = false ;
        }
        else
        {
            spriteRenderer.flipY = true;
        }

        currentGun.SetSpriteInSpriteRenderer(currentGunPlayerSprite);

    }
}
