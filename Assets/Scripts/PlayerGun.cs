using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] IGun currentGun;
    [SerializeField] GameObject currentGunGO;
    public struct Gun
    {
        public int gunShootDirections;
        public float gunBulletSpeed;
        public float gunBulletSize;
        public float gunBulletLife;

    }

    private Gun DefaultGun = new Gun();
    
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        DefaultGun.gunShootDirections = 3;
        DefaultGun.gunBulletSpeed = 2;
        DefaultGun.gunBulletSpeed = 2;
        DefaultGun.gunBulletLife = 3f;
        currentGun = currentGunGO.GetComponent<IGun>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            currentGun.ShootGun();
        }
    }

   
}
