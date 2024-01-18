using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintGun : MonoBehaviour, IGun
{
    [SerializeField] GameObject bulletPrefabGO;

    [SerializeField] private Transform[] shootDirectionsList;

    private SpriteRenderer spriteRenderer;


    private bool canShoot;

    private void OnEnable()
    {
        for(int i = 0; i < shootDirectionsList.Length; i++)
        {
            shootDirections[i] = shootDirectionsList[i];
        }
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
            return new Transform[3];
        }
        set { shootDirections = value; }
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
        set
        {
            bulletSize = value;
        }
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
            return .5f;
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
        if (canShoot)
        {
            canShoot = false;
            foreach (Transform t in shootDirectionsList)
            {
                GameObject newBullet = Instantiate(bulletPrefab, t.position, t.transform.rotation);
                BulletMovement bulletMovement = newBullet.GetComponent<BulletMovement>();
                bulletMovement.SetBulletSpeed(bulletSpeed);
                Destroy(newBullet, bulletLife);
            }

            StartCoroutine(WaitForShootingSpeed(shootingSpeed));

        }

    }

    public void SetCanShoot(bool canShoot)
    {
        this.canShoot  = canShoot;
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
