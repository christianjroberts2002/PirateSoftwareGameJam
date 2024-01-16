using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DefaultGun : MonoBehaviour, IGun
{
    [SerializeField] GameObject bulletPrefabGO;

    private bool canShoot;

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
            return 3f;
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
            return 3f;
        }
    }

    public float shootingSpeed
    {
        get
        {
            return .75f;
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
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            StartCoroutine(WaitForShootingSpeed(shootingSpeed));
        }

    }

    public IEnumerator WaitForShootingSpeed(float shootWaitTime)
    {
        
        yield return new WaitForSeconds(shootWaitTime);
        canShoot = true;
    }

}
