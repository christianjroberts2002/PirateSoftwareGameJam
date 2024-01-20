using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemyHealthScript : MonoBehaviour
{

    [SerializeField] UnityEngine.UI.Slider healthSlider;
    [SerializeField] float enemyHealth;


    [SerializeField] float enemyBulletSlowdown;
    [SerializeField] float enemyPaintCollisionSlowdown;

    public event EventHandler OnEnemyDeath;

    [SerializeField] private EnemyScript enemyScript;
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
            //Damage
            BulletDamage bullet = collision.GetComponent<BulletDamage>();
            float bulletdamage = bullet.GetBulletDamage();

            //Health
            enemyHealth -= bulletdamage;
            healthSlider.value = enemyHealth;

            //EnemySpeed
            float enemySpeed = enemyScript.GetEnemySpeed();
            if(enemySpeed > 0 + enemyBulletSlowdown)
            {
                float newEnemySpeed = enemySpeed * enemyBulletSlowdown;
                enemyScript.SetEnemySpeed(newEnemySpeed);
            }
            
            
            
            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
                OnEnemyDeath?.Invoke(this, EventArgs.Empty);
            }
        }

        
    }

    public void TakeDamager(float enemyHealth , float damage)
    {
        this.enemyHealth = enemyHealth - damage;
    }

    public float GetEnemyHealth()
    {
        return enemyHealth;
    }

    public void SetSliderValue(float sliderValue)
    {
        this.healthSlider.value = sliderValue;
    }

    public float GetEnemyPaintSlowdown()
    {
        return enemyPaintCollisionSlowdown;
    }
}
