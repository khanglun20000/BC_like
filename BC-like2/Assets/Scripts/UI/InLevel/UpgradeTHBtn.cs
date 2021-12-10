using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeTHBtn : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] int amount;
    [SerializeField] int money;
    private void OnEnable()
    {
        button.onClick.AddListener(() => MoneySystem.Instance.UpgradeThreshold(amount, money));
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }

}
