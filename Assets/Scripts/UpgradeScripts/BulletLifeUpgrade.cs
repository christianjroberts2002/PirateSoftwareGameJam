using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletLifeUpgrade : MonoBehaviour, IUpgrade
{
    [SerializeField] float bulletLifeBonus;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private PlayerUpgradeScript playerUpgradeScript;

    [SerializeField] float maxUpgradeMultiplier = .3f;

    private GameObject[] guns;


    public void UpgradePlayer()
    {
        float shopUpgradeLevel = (float)playerUpgradeScript.GetShopLevel();
        float totalLevelOfShopLevels = (float)playerUpgradeScript.GetMaxShopLevel();

        bulletLifeBonus = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));
        Debug.Log(bulletLifeBonus);

        guns = PlayerGun.Instance.GetGuns();
        foreach (GameObject gun in guns)
        {
            IGun gunScript = gun.GetComponent<IGun>();
            gunScript.BulletLife += bulletLifeBonus;
        }
    }

    public float GetTotalBonus()
    {
        return bulletLifeBonus;
    }

    public void SetUpgradeText()
    {
        float shopUpgradeLevel = (float)playerUpgradeScript.GetShopLevel();
        float totalLevelOfShopLevels = (float)playerUpgradeScript.GetMaxShopLevel();

        bulletLifeBonus = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));

        titleText.text = "Bullet Life+";
        descriptionText.text = "";
        guns = PlayerGun.Instance.GetGuns();
        foreach (GameObject gun in guns)
        {
            IGun gunScript = gun.GetComponent<IGun>();
            gunScript.BulletSpeed += bulletLifeBonus;
            descriptionText.text += gun.gameObject.name + "'s Bullet Life will increase by " + bulletLifeBonus + "\n ";

        }

    }

}