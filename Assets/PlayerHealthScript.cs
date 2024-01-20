using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    [SerializeField] UnityEngine.UI.Slider healthSlider;
    [SerializeField] float playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = playerHealth;
        healthSlider.value = playerHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            float enemyKnockback = 43f;
            Rigidbody2D enemyRB = collision.GetComponent<Rigidbody2D>();
            Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 enemyDirection = playerPosition - enemyRB.position;
            enemyRB.AddForce(-enemyDirection * enemyKnockback, ForceMode2D.Impulse);

            playerHealth--;
            healthSlider.value = playerHealth;
            if (playerHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
