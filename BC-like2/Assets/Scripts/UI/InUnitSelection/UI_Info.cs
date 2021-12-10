using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Info : MonoBehaviour
{
    [SerializeField] private AllyStat allyStat;

    public static UI_Info Instance;

    [SerializeField] TMP_Text health, attack, range, speed, atkspd, cost, recharge, unitName, level;
    [SerializeField] TMP_Text healthLV, attackLV, rangeLV, speedLV, atkspdLV, costLV, rechargeLV;
    [SerializeField] TMP_Text description;

    private void Awake()
    {
        allyStat = null;
        Close_UI_Info();
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void DisplayStat()
    {
        unitName.text = allyStat.unitName;
        level.text =  allyStat.level.ToString();
        description.text = allyStat.description;
        health.text = allyStat.maxHealth.GetValue().ToString();
        attack.text = allyStat.attackRating.GetValue().ToString();
        range.text = allyStat.attackRange.GetValue().ToString();
        speed.text = allyStat.movementSpeed.GetValue().ToString();
        atkspd.text = (1f / allyStat.timeBtwAttacks.GetValue()).ToString("0.00");
        cost.text = allyStat.cost.GetValue().ToString();
        recharge.text = allyStat.rechargeTime.GetValue().ToString();

        healthLV.text = allyStat.maxHealth.GetLevel().ToString();
        attackLV.text = allyStat.attackRating.GetLevel().ToString();
        rangeLV.text = allyStat.attackRange.GetLevel().ToString();
        speedLV.text = allyStat.movementSpeed.GetLevel().ToString();
        atkspdLV.text =  allyStat.timeBtwAttacks.GetLevel().ToString();
        costLV.text = allyStat.cost.GetLevel().ToString();
        rechargeLV.text = allyStat.rechargeTime.GetLevel().ToString();
    }
    public void SetAllyStat(AllyStat stat)
    {
        allyStat = stat;
        DisplayStat();
    }
    public void Open_UI_Info()
    {
        gameObject.SetActive(true);
    }
    public void Close_UI_Info()
    {
        gameObject.SetActive(false);
    }
}
