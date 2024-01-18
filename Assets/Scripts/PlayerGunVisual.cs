using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunVisual : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private int layerAboveGun = 5;
    private int layerBelowGun = 0;


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
}
