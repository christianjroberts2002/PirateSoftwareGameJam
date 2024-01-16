using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunVisual : MonoBehaviour
{
    private Rigidbody2D playerRB;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        Vector2 lookDir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.right = lookDir;
        
    }
}
