using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgrade
{
    public void UpgradePlayer();

    public float GetTotalBonus();

    public void SetUpgradeText();
}
