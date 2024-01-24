using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentCashTextScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cashText;

    private void Start()
    {
        SetCashText();
    }

    private void SetCashText()
    {
        cashText.text = PlayerMoneyScript.Instance.GetPlayersCash().ToString();
    }
}
