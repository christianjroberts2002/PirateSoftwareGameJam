using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DefaultGun : MonoBehaviour, IGun
{
    [SerializeField] GameObject bulletPrefabGO;

    [SerializeField] private Transform bulletSpawnPoint;

    private SpriteRenderer spriteRenderer;



    private bool canShoot;

    private void OnEnable()
    {
        bulletSpawnPoint = GameObject.Find("BulletSpawn").transform;
        
    }

    private void Start()
    {
        canShoot = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public Transform[] shootDirections
    {
        get
        {
            return new Transform[1];
        }
        set
        {
            { shootDirections = value; };
        }
    }

    public float bulletSpeed
    {
        get
        {
            return 15f;
        }
    }

    public float bulletSize
    {
        get
        {
            return 1f;
        }
        set { bulletSize = value; }
    }

    public float bulletLife
    {
        get
        {
            return 1.5f;
        }
        set
        {
            bulletLife = value;
        }
    }

    public float shootingSpeed
    {
        get
        {
            return .05f;
        }
        set
        {
            shootingSpeed = value;
        }
    }

    public GameObject bulletPrefab
    {
        get
        {
            return bulletPrefabGO;
        }
        set
        {
            bulletPrefab = value;
        }
    }


    bool IGun.canShoot
    {
        get
        {
            return canShoot;

        }
        set
        {
            canShoot = value;
        }
    }


    public void ShootGun()
    {
        if(canShoot)
        {
            canShoot = false;
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.transform.rotation);
            BulletMovement bulletMovement = newBullet.GetComponent<BulletMovement>();
            bulletMovement.SetBulletSpeed(bulletSpeed);
            StartCoroutine(WaitForShootingSpeed(shootingSpeed));
            Destroy(newBullet, bulletLife);
        }

    }

    public void SetCanShoot(bool canShoot)
    {
        this.canShoot = canShoot;
    }

    public IEnumerator WaitForShootingSpeed(float shootWaitTime)
    {
        
        yield return new WaitForSeconds(shootWaitTime);
        canShoot = true;
    }

    public void SetSpriteOrderInLayer(int layer)
    {
        spriteRenderer.sortingOrder = layer;
    }

    public void SetBulletSpeed(float bulletSpeed)
    {
        
    }
}
