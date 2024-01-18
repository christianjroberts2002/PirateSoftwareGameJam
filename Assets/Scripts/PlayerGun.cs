using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] public IGun currentGun;
    [SerializeField] private GameObject currentGunGO;

    [SerializeField] GameObject[] guns;

    [SerializeField] private float paintCoverageMultiplier;

    private bool isSwitching;
    


    private int gunCounter = 0;

    
    public static PlayerGun Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentGun = currentGunGO.GetComponent<IGun>();
    }

    // Update is called once per frame
    void Update()
    {
        SetGunSettings(currentGun);
        ShootGun();

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (gunCounter == 0)
            {
                gunCounter++;
                SwitchGun(gunCounter);


            }
            else
            {
                gunCounter--;
                SwitchGun(gunCounter);

            }

            currentGun.SetCanShoot(true);
        }
    }

    private void SetGunSettings(IGun gun)
    {
        float paintCoverage = (PaintCoverageScript.Instance.GetPlayerPercentCovered() / 100) + 1;
        float paintCoverageBoost = paintCoverage * paintCoverageMultiplier;
        float newBulletSpeed = 1 * paintCoverageBoost;
        gun.SetBulletSpeed(newBulletSpeed);
    }



    private void ShootGun()
    {
        if (Input.GetMouseButton(0))
        {
            currentGun.ShootGun();
        }
    }

    private void SwitchGun(int newGun)
    {

        GameObject oldGun = currentGunGO;

        oldGun.SetActive(false);

        currentGunGO = guns[newGun];
        
        currentGunGO.SetActive(true);
        currentGun = currentGunGO.GetComponent<IGun>();
        
        
    }

    private IEnumerator WaitToSwitchForXSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isSwitching = false;
    }

    public IGun GetCurrentGun()
    {
        return currentGun;
    }

   
}
