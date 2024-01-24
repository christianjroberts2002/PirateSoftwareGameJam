using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerHealthScript.OnPlayerDeath += PlayerHealthScript_OnPlayerDeath;
    }


    private void Update()
    {
        Vector3 playerpos = PlayerController.Instance.transform.position;   

        if(transform.position.x > playerpos.x) //player on the left
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
    private void PlayerHealthScript_OnPlayerDeath(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PlayerHealthScript.OnPlayerDeath -= PlayerHealthScript_OnPlayerDeath;
    }
}
