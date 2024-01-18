using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemyHealthScript : MonoBehaviour
{

    [SerializeField] UnityEngine.UI.Slider healthSlider;
    [SerializeField] float enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = enemyHealth;
        healthSlider.value = enemyHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FriendlyBullet")
        {
            enemyHealth--;
            healthSlider.value = enemyHealth;
            Destroy(collision.gameObject);
            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
