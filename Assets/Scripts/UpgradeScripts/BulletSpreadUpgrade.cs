using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletSpreadUpgrade : MonoBehaviour, IUpgrade
{
    [SerializeField] float bulletSpreadBonus;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private PlayerUpgradeScript playerUpgradeScript;

    [SerializeField] float maxUpgradeMultiplier = .3f;

    private GameObject[] guns;


    public void UpgradePlayer()
    {
        float shopUpgradeLevel = (float)playerUpgradeScript.GetShopLevel();
        float totalLevelOfShopLevels = (float)playerUpgradeScript.GetMaxShopLevel();

        bulletSpreadBonus = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));
        Debug.Log(bulletSpreadBonus);

        guns = PlayerGun.Instance.GetGuns();
        //NotImplemented
        //foreach (GameObject gun in guns)
        //{
        //    IGun gunScript = gun.GetComponent<IGun>();
        //    gunScript.BulletLife += bulletSpreadBonus;
        //}
    }

    public float GetTotalBonus()
    {
        return bulletSpreadBonus;
    }

    public void SetUpgradeText()
    {
        float shopUpgradeLevel = (float)playerUpgradeScript.GetShopLevel();
        float totalLevelOfShopLevels = (float)playerUpgradeScript.GetMaxShopLevel();

        bulletSpreadBonus = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));

        titleText.text = "BulletSpread+";
        descriptionText.text = "";
        guns = PlayerGun.Instance.GetGuns();
        foreach (GameObject gun in guns)
        {
            IGun gunScript = gun.GetComponent<IGun>();
            gunScript.BulletSpeed += bulletSpreadBonus;
            descriptionText.text += gun.gameObject.name + "'s Bullet Spread will increase by " + bulletSpreadBonus + "\n ";

        }

    }

}
