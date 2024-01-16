using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DefaultGun : MonoBehaviour, IGun
{
    [SerializeField] GameObject bulletPrefabGO;

    [SerializeField] private Transform bulletSpawnPoint;

    

    private bool canShoot;

    private void OnEnable()
    {
        bulletSpawnPoint = GameObject.Find("BulletSpawn").transform;
        
    }

    private void Start()
    {
        canShoot = true;
    }
    public Vector3[] shootDirections
    {
        get
        {
            return new Vector3[0];
        }
    }

    public float bulletSpeed
    {
        get
        {
            return 35f;
        }
    }

    public float bulletSize
    {
        get
        {
            return 1f;
        }
    }

    public float bulletLife
    {
        get
        {
            return 8f;
        }
    }

    public float shootingSpeed
    {
        get
        {
            return .05f;
        }
    }

    public GameObject bulletPrefab
    {
        get
        {
            return bulletPrefabGO;
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

    public IEnumerator WaitForShootingSpeed(float shootWaitTime)
    {
        
        yield return new WaitForSeconds(shootWaitTime);
        canShoot = true;
    }

}
