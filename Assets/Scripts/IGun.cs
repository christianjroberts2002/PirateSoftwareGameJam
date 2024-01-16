using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerGun;
using static UnityEngine.RuleTile.TilingRuleOutput;

public interface IGun
{
    GameObject bulletPrefab { get; }
    Vector3[] shootDirections { get; }
    float bulletSpeed { get; }
    float bulletSize { get; }
    float bulletLife { get; }
    float shootingSpeed { get; }

    void ShootGun();

    IEnumerator WaitForShootingSpeed(float shootingSpeed);
}
