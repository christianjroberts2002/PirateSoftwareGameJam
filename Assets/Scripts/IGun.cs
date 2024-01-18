using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerGun;

public interface IGun
{
    GameObject bulletPrefab { get; set; }
    Transform[] shootDirections { get; set; }
    float bulletSpeed { get;}
    float bulletSize { get; set; }
    float bulletLife { get; set; }
    float shootingSpeed { get; set; }


    bool canShoot { get; set; }

    void ShootGun();

    void SetCanShoot(bool canShoot);

    IEnumerator WaitForShootingSpeed(float shootingSpeed);

    void SetSpriteOrderInLayer(int layer);

    void SetBulletSpeed(float speed);

}
