using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSpeedUpgrade : MonoBehaviour, IUpgrade
{
    [SerializeField] float totalSpeedBonus;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private PlayerUpgradeScript playerUpgradeScript;

    [SerializeField] float maxUpgradeMultiplier = .05f;


    public void UpgradePlayer()
    {
        int shopUpgradeLevel = playerUpgradeScript.GetShopLevel();
        int totalLevelOfShopLevels = playerUpgradeScript.GetMaxShopLevel();

        totalSpeedBonus = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));
        Debug.Log(totalSpeedBonus);

        PlayerController.Instance.SetSpeedMultiplier(totalSpeedBonus);
    }

    public float GetTotalBonus()
    {
        return totalSpeedBonus;
    }

    public void SetUpgradeText()
    {
        int shopUpgradeLevel = playerUpgradeScript.GetShopLevel();
        int totalLevelOfShopLevels = playerUpgradeScript.GetMaxShopLevel();

        totalSpeedBonus = maxUpgradeMultiplier * ((shopUpgradeLevel / totalLevelOfShopLevels));

        titleText.text = "Player Speed->";

        descriptionText.text = "Player Speed will increase by " + totalSpeedBonus; 
    }
}
