using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private void OnEnable()
    {
        
    }

    private void Update()
    {
        //constantForce.relativeForce = new Vector2(bulletSpeed, 0);
        transform.position += transform.right * bulletSpeed * Time.deltaTime;

    }

    public void SetBulletSpeed(float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
