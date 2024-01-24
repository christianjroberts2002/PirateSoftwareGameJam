using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUpgradeScript : MonoBehaviour
{
    [SerializeField] private GameObject[] upgradeObjects;

    [SerializeField] private float upgradeCost;

    [SerializeField] private IUpgrade currentUpgradeScript;
    [SerializeField] private GameObject currentUpgradeScriptGO;

    public int shopUpgradeLevel;

    

    

    public enum PlayerUpgradeType
    {
        PlayerSpeed,
        BulletSpeed,
        BulletLife,
        BulletAOE,
        BulletSpread,
        ShootingSpeed,
        Damage,
        Piercing,
        BulletSize
    }

    [SerializeField] private PlayerUpgradeType upgradeType;
    [SerializeField] private int upgradeTypeAsInt;

    private int totalLevelOfShopLevels = 3;

    private void Awake()
    {
        upgradeType = (PlayerUpgradeType)Random.Range(0, System.Enum.GetValues(typeof(PlayerUpgradeType)).Length);
    }


    private void Start()
    {
        SetUpgradeInt();
        SetUpgradeCanvas();
        currentUpgradeScript.SetUpgradeText();
        UpgradePlayerOnClick();
        
    }

    private void Update()
    {
        
        
    }


    private void SetUpgradeInt()
    {
        if(upgradeType == PlayerUpgradeType.PlayerSpeed)
            upgradeTypeAsInt = 0;

        if (upgradeType == PlayerUpgradeType.BulletSpeed)
            upgradeTypeAsInt = 1;

        if (upgradeType == PlayerUpgradeType.BulletLife)
            upgradeTypeAsInt = 2;

        if (upgradeType == PlayerUpgradeType.BulletAOE)
            upgradeTypeAsInt = 3;

        if (upgradeType == PlayerUpgradeType.BulletSpread)
            upgradeTypeAsInt = 4;

        if (upgradeType == PlayerUpgradeType.ShootingSpeed)
            upgradeTypeAsInt = 5;

        if (upgradeType == PlayerUpgradeType.Damage)
            upgradeTypeAsInt = 6;

        if (upgradeType == PlayerUpgradeType.Piercing)
            upgradeTypeAsInt = 7;

        if (upgradeType == PlayerUpgradeType.BulletSize)
            upgradeTypeAsInt = 8;



    }
    private void SetUpgradeCanvas()
    {
        for (int i = 0; i < upgradeObjects.Length; i++)
        {
            if(i == upgradeTypeAsInt)
            {
                upgradeObjects[i].SetActive(true);
                currentUpgradeScriptGO = upgradeObjects[i];
                currentUpgradeScript = currentUpgradeScriptGO.GetComponent<IUpgrade>();
            }
            else
            {
                upgradeObjects[i].SetActive(false);
                
            }
        }
    }

    public void UpgradePlayerOnClick()
    {
        currentUpgradeScript.UpgradePlayer();
    }


    public void SubtractMoneyFromPlayer()
    {
        PlayerMoneyScript.Instance.GetPaymentFromPlayer(Mathf.RoundToInt(upgradeCost));
    }

    public int GetShopLevel()
    {
        return shopUpgradeLevel;
    }

    public int GetMaxShopLevel()
    {
        return totalLevelOfShopLevels;
    }
}
