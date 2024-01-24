using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletSizeUpgrade : MonoBehaviour, IUpgrade
{
    [SerializeField] float bulletSizeIncrease;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private PlayerUpgradeScript playerUpgradeScript;

    [SerializeField] float maxUpgradeMultiplier = .3f;

    private GameObject[] guns;


    public void UpgradePlayer()
    {
        float shopUpgradeLevel = (float)playerUpgradeScript.GetShopLevel();
        float totalLevelOfShopLevels = (float)playerUpgradeScript.GetMaxShopLevel();

        bulletSizeIncrease = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));
        Debug.Log(bulletSizeIncrease);

        guns = PlayerGun.Instance.GetGuns();
        foreach (GameObject gun in guns)
        {
            IGun gunScript = gun.GetComponent<IGun>();
            gunScript.BulletDamage += bulletSizeIncrease;
        }
    }

    public float GetTotalBonus()
    {
        return bulletSizeIncrease;
    }

    public void SetUpgradeText()
    {
        float shopUpgradeLevel = (float)playerUpgradeScript.GetShopLevel();
        float totalLevelOfShopLevels = (float)playerUpgradeScript.GetMaxShopLevel();

        bulletSizeIncrease = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));

        titleText.text = "Bullet Size+";
        descriptionText.text = "";
        guns = PlayerGun.Instance.GetGuns();
        foreach (GameObject gun in guns)
        {
            IGun gunScript = gun.GetComponent<IGun>();
            gunScript.BulletSpeed += bulletSizeIncrease;
            descriptionText.text += gun.gameObject.name + "'s Bullet Size will increase by " + bulletSizeIncrease + "\n ";

        }

    }

}


