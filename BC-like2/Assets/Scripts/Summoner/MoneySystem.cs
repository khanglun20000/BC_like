using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneySystem : MonoBehaviour
{
    public static MoneySystem Instance { get; private set; }

    [SerializeField] int currentMoney;
    [SerializeField] int moneyThreshold;
    [SerializeField] float moneyPerSecond;

    [SerializeField] TMP_Text T_currentMoney;
    [SerializeField] TMP_Text T_moneyThreshold;

    float increasingRate;
    int upgradeCapacity = 4;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentMoney = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ProduceMoney();
        UpdateMoneyUI();
    }

    
    void ProduceMoney()
    {
        if(currentMoney < moneyThreshold)
        {
            increasingRate += Time.deltaTime * moneyPerSecond;
            if (increasingRate >= 1)
            {
                int floor = Mathf.FloorToInt(increasingRate);
                currentMoney += floor;
                increasingRate -= floor;
            }

        }
        else
        {
            currentMoney = moneyThreshold;
        }
    }

    private void UpdateMoneyUI()
    {
        T_currentMoney.text = currentMoney.ToString();
        T_moneyThreshold.text = moneyThreshold.ToString();
    }

    public void UpgradeThreshold(int amount, int money)
    {
        if(upgradeCapacity > 0 && currentMoney >= money)
        {
            moneyThreshold += amount;
            DecreaseMoney(money);
            upgradeCapacity--;
        }
       
    }

    public void DecreaseMoney(int amount)
    {
        currentMoney -= amount;
    }

    public void IncreaseMoney(int amount)
    {
        currentMoney += amount;
    }

    public int GetCurrentMoney()
    {
        return currentMoney;
    }
}
