using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    private void Start()
    {
        PlayerHealthScript.OnPlayerDeath += PlayerHealthScript_OnPlayerDeath;
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
