using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PiercingUpgrade : MonoBehaviour , IUpgrade
{
    [SerializeField] int penetrationIncrease;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private PlayerUpgradeScript playerUpgradeScript;

    [SerializeField] int maxUpgradeMultiplier = 1;

    private GameObject[] guns;


    public void UpgradePlayer()
    {
        int shopUpgradeLevel = playerUpgradeScript.GetShopLevel();
        int totalLevelOfShopLevels = playerUpgradeScript.GetMaxShopLevel();

        penetrationIncrease = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));
        Debug.Log(penetrationIncrease);

        guns = PlayerGun.Instance.GetGuns();
        foreach (GameObject gun in guns)
        {
            IGun gunScript = gun.GetComponent<IGun>();
            gunScript.BulletPenetration += penetrationIncrease;
        }
    }

    public float GetTotalBonus()
    {
        return penetrationIncrease;
    }

    public void SetUpgradeText()
    {
        int shopUpgradeLevel = playerUpgradeScript.GetShopLevel();
        int totalLevelOfShopLevels = playerUpgradeScript.GetMaxShopLevel();

        penetrationIncrease = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));
        Debug.Log(penetrationIncrease);
        titleText.text = "Piercing+";
        descriptionText.text = "";
        guns = PlayerGun.Instance.GetGuns();
        foreach (GameObject gun in guns)
        {
            IGun gunScript = gun.GetComponent<IGun>();
            gunScript.BulletSpeed += penetrationIncrease;
            descriptionText.text += gun.gameObject.name + "'s Bullet Piercing will increase by " + penetrationIncrease + "\n ";

        }

    }

}

