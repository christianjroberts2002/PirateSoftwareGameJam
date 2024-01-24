using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageUpgrade : MonoBehaviour, IUpgrade
{
    [SerializeField] float damageIncrease;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private PlayerUpgradeScript playerUpgradeScript;

    [SerializeField] float maxUpgradeMultiplier = .3f;

    private GameObject[] guns;


    public void UpgradePlayer()
    {
        float shopUpgradeLevel = (float)playerUpgradeScript.GetShopLevel();
        float totalLevelOfShopLevels = (float)playerUpgradeScript.GetMaxShopLevel();

        damageIncrease = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));
        Debug.Log(damageIncrease);

        guns = PlayerGun.Instance.GetGuns();
        foreach (GameObject gun in guns)
        {
            IGun gunScript = gun.GetComponent<IGun>();
            gunScript.BulletDamage += damageIncrease;
        }
    }

    public float GetTotalBonus()
    {
        return damageIncrease;
    }

    public void SetUpgradeText()
    {
        float shopUpgradeLevel = (float)playerUpgradeScript.GetShopLevel();
        float totalLevelOfShopLevels = (float)playerUpgradeScript.GetMaxShopLevel();

        damageIncrease = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));

        titleText.text = "Bullet Damage+";
        descriptionText.text = "";
        guns = PlayerGun.Instance.GetGuns();
        foreach (GameObject gun in guns)
        {
            IGun gunScript = gun.GetComponent<IGun>();
            gunScript.BulletSpeed += damageIncrease;
            descriptionText.text += gun.gameObject.name + "'s Bullet Damage will increase by " + damageIncrease + "\n ";

        }

    }

}
