using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class BulletSpeedUpgrade : MonoBehaviour, IUpgrade
{
    [SerializeField] float bulletSpeedBonus;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private PlayerUpgradeScript playerUpgradeScript;

    [SerializeField] float maxUpgradeMultiplier = .5f;

    private GameObject[] guns;


    public void UpgradePlayer()
    {
        float shopUpgradeLevel = (float)playerUpgradeScript.GetShopLevel();
        float totalLevelOfShopLevels = (float)playerUpgradeScript.GetMaxShopLevel();

        bulletSpeedBonus = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));
        Debug.Log(bulletSpeedBonus);

        guns = PlayerGun.Instance.GetGuns();
        foreach (GameObject gun in guns)
        {
            IGun gunScript = gun.GetComponent<IGun>();
            gunScript.BulletSpeed += bulletSpeedBonus;
        }
    }

    public float GetTotalBonus()
    {
        return bulletSpeedBonus;
    }

    public void SetUpgradeText()
    {
        float shopUpgradeLevel = (float)playerUpgradeScript.GetShopLevel();
        float totalLevelOfShopLevels = (float)playerUpgradeScript.GetMaxShopLevel();
        
        bulletSpeedBonus = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));

        titleText.text = "BulletSpeed+";
        descriptionText.text = "";
        guns = PlayerGun.Instance.GetGuns();
        foreach (GameObject gun in guns)
        {
            IGun gunScript = gun.GetComponent<IGun>();
            gunScript.BulletSpeed += bulletSpeedBonus;
            descriptionText.text += gun.gameObject.name + "'s Bullet Speed will increase by " + bulletSpeedBonus + "\n ";

        }
        
    }

}
