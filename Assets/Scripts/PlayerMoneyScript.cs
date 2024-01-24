using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoneyScript : MonoBehaviour
{
    [SerializeField] private int playersCash;

    [SerializeField] private int maxPlayerCash;
    [SerializeField] private int baseMaxPlayerCash  = 100;

    [SerializeField] private float maxPlayerCashMulitplier = .05f;

    [SerializeField] private int minPlayerCash;





    public static PlayerMoneyScript Instance;

    private void Start()
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

    public int GetPlayersCash()
    {
        return playersCash;
    }

    public void GetPaymentFromPlayer(int totalCost)
    {
        playersCash -= totalCost;
    }

    public void PayPlayersCash()
    {

        maxPlayerCash = Mathf.RoundToInt(baseMaxPlayerCash * maxPlayerCashMulitplier);
        float playerJobDone = PaintCoverageScript.Instance.GetPlayerPercentCovered();
        playersCash = Mathf.RoundToInt(playerJobDone * maxPlayerCash);
    }
}
