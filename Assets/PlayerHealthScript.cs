using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    [SerializeField] UnityEngine.UI.Slider healthSlider;
    [SerializeField] float playerHealth;


    public static event EventHandler OnPlayerDeath;


    public static PlayerHealthScript Instance;

    private bool isDead = false;

    public void Awake()
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
        healthSlider.maxValue = playerHealth;
        healthSlider.value = playerHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            float enemyKnockback = 43f;
            Rigidbody2D enemyRB = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 enemyDirection = playerPosition - enemyRB.position;
            enemyRB.AddForce(-enemyDirection * enemyKnockback, ForceMode2D.Impulse);

            playerHealth--;
            healthSlider.value = playerHealth;
            if (playerHealth <= 0)
            {
                isDead = true;  
                OnPlayerDeath?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public bool GetIsDead()
    {
        return isDead;
    }
}
