using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerGun;

public interface IGun
{
    GameObject BulletPrefab { get; set; }
    Transform[] ShootDirections { get; set; }
    float BulletSpeed { get; set; }
    float BulletSize { get; set; }
    float BulletLife { get; set; }
    float ShootingSpeed { get; set; }

    Sprite[] GunSprites { get; set; }


    bool CanShoot { get; set; }

    float GunBoost { get; set; }
    float GunBoostMultiplier { get; set; }

    void ShootGun();

    void SetCanShoot(bool canShoot);

    IEnumerator WaitForShootingSpeed(float shootingSpeed);

    void SetSpriteOrderInLayer(int layer);
    void SetSpriteInSpriteRenderer(Sprite sprite);

    SpriteRenderer GetSpriteRenderer();

    void SetGunBoosts();



}
