using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DefaultGun : MonoBehaviour, IGun
{
    //Default
    GameObject defaultBulletPrefabGO;

    private Transform[] defaultShootDirectionsList;

    private float defaultBulletSpeed;

    private float defaultBulletSize;

    private float defaultBulletLife;

    private float defaultShootingSpeed;

    private SpriteRenderer defaultSpriteRenderer;


    private bool defaultCanShoot;

    private Sprite[] defaultGunSprites;

    //Modified
    [SerializeField] GameObject bulletPrefabGO;

    [SerializeField] private Transform[] shootDirectionsList;

    [SerializeField] private float bulletSpeed;

    [SerializeField] private float bulletSize;

    [SerializeField] private float bulletLife;

    [SerializeField] private float shootingSpeed;

    [SerializeField] private SpriteRenderer spriteRenderer;


    [SerializeField] private bool canShoot;

    [SerializeField] private Sprite[] gunSprites;

    [SerializeField] private float gunBoost;
    [SerializeField] private float gunBoostMultiplier;

    [SerializeField] private float bulletDamage;
    [SerializeField] private int bulletPenetration;

    private void OnEnable()
    {
        for (int i = 0; i < shootDirectionsList.Length; i++)
        {
            ShootDirections[i] = shootDirectionsList[i];
        }
    }

    private void Start()
    {
        canShoot = true;
        spriteRenderer = GetComponent<SpriteRenderer>();

        defaultBulletPrefabGO = bulletPrefabGO;
        defaultShootDirectionsList = shootDirectionsList;
        defaultBulletSpeed = bulletSpeed;
        defaultBulletSize = bulletSize;
        defaultBulletLife = bulletLife;
        defaultShootingSpeed = shootingSpeed;
        defaultSpriteRenderer = spriteRenderer;
        defaultCanShoot = canShoot;
        defaultGunSprites = gunSprites; 
    }
    public Transform[] ShootDirections
    {
        get
        {
            return shootDirectionsList;
        }
        set { shootDirectionsList = value; }
    }

    public float BulletSpeed
    {
        get
        {
            return bulletSpeed;
        }
        set
        {
            bulletSpeed = value;
        }
    }

    public float BulletSize
    {
        get
        {
            return bulletSize;
        }
        set
        {
            bulletSize = value;
        }
    }

    public float BulletLife
    {
        get
        {
            return bulletLife;
        }
        set
        {
            bulletLife = value;
        }
    }

    public float ShootingSpeed
    {
        get
        {
            return shootingSpeed;
        }
        set
        {
            shootingSpeed = value;
        }
    }

    public GameObject BulletPrefab
    {
        get
        {
            return bulletPrefabGO;
        }
        set
        {
            bulletPrefabGO = value;
        }
    }

    bool IGun.CanShoot
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
    public Sprite[] GunSprites
    {
        get
        {
            return gunSprites;
        }
        set
        {
            gunSprites = value;
        }
    }

    public float GunBoost
    {
        get
        {
            return gunBoost;
        }
        set
        {
            gunBoost = value;
        }
    }

    public float GunBoostMultiplier
    {
        get
        {
            return gunBoostMultiplier;
        }
        set
        {
            gunBoostMultiplier = value;
        }
    }

    public float BulletDamage
    {
        get
        {
            return BulletDamage;
        }
        set
        {
            BulletDamage = value;
        }
    }
    public int BulletPenetration
    {
        get
        {
            return bulletPenetration;
        }
        set
        {
            bulletPenetration = value;
        }
    }



    public void ShootGun()
    {
        if(canShoot)
        {
            SetGunBoosts();
            canShoot = false;
            GameObject newBullet = Instantiate(BulletPrefab, shootDirectionsList[0].position, shootDirectionsList[0].transform.rotation);

            BulletDamage bulletDamage = newBullet.GetComponent<BulletDamage>();
            bulletDamage.SetBulletDamage(BulletDamage);
            bulletDamage.SetBulletPenetration(BulletPenetration);

            StartCoroutine(WaitForShootingSpeed(ShootingSpeed));
            Destroy(newBullet, BulletLife);
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

    public void SetSpriteInSpriteRenderer(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }

    public void SetGunBoosts()
    {
        //BoostMultiplier
        float paintCoverage = PaintCoverageScript.Instance.GetPlayerPercentCovered() / 100;
        gunBoost = (paintCoverage * gunBoostMultiplier) + 1;
        //////////
        //////////

        //ShootDirection -- stretch goal

        //bulletSpeed
        float newbulletSpeed = defaultBulletSpeed * gunBoost;
        this.bulletSpeed = newbulletSpeed;

        //bulletSize
        float newBulletSize = defaultBulletSize * gunBoost;
        this.bulletSize = newBulletSize;
        bulletPrefabGO.transform.localScale = Vector3.one * this.bulletSize;

        //bulletLife
        float newBulletLife = defaultBulletLife * gunBoost;
        this.bulletLife = newBulletLife;


        //ShootingSpeed
        //float newShootingSpeed = defaultShootingSpeed / gunBoost;
        //shootingSpeed = newShootingSpeed;

    }

}
