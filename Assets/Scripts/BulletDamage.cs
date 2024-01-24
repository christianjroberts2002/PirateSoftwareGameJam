using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private float bulletDamage;
    [SerializeField] private int bulletPenetration;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            bulletPenetration--;
            if (bulletPenetration <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void SetBulletDamage(float bulletDamage)
    {
        this.bulletDamage = bulletDamage;
    }

    public float GetBulletDamage()
    {
        return bulletDamage;
    }

    public void SetBulletPenetration(int bulletPenetration)
    {
        this.bulletPenetration = bulletPenetration;
    }

    public int GetBulletPenetration()
    {
        return bulletPenetration;
    }
}
