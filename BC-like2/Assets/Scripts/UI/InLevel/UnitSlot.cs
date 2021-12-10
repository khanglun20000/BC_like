using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitSlot : MonoBehaviour
{
    AllyStat unit;
    Button button;

    int coolDownTime;
    float coolDownTimer;
    bool isCoolDown = false;
    [SerializeField] Image coolDownFill;
    [SerializeField] GameObject coolDownBar;

    [SerializeField] TMP_Text costText;
    [SerializeField] GameObject costBG;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }
    private void Start()
    {
        coolDownFill.fillAmount = 1;
        if (unit)
        {
            coolDownTime = unit.rechargeTime.GetValue();
            costText.text = unit.cost.ToString();
        }
    }

    private void Update()
    {
        ApplyCoolDown();
        if (!button.isActiveAndEnabled)
        {
            costBG.SetActive(false);
        }
        else if(unit)
        {
            costBG.SetActive(true);
        }
    }
    public void SetUnit(AllyStat unit)
    {
        this.unit = unit;
    }
    void TaskOnClick()
    {
        if (unit && !isCoolDown) 
        {
            if (MoneySystem.Instance.GetCurrentMoney() >= unit.cost.GetValue())
            {
                MoneySystem.Instance.DecreaseMoney(unit.cost.GetValue());
                GameScene.Instance.SummonUnit(unit);
                coolDownTimer = coolDownTime;
                isCoolDown = true;
            }
            
        }
    }
    void ApplyCoolDown()
    {
        if (isCoolDown)
        {
            coolDownTimer -= Time.deltaTime;
            coolDownBar.SetActive(true);

            if(coolDownTimer <= 0)
            {
                isCoolDown = false;
                coolDownFill.fillAmount = 1;
                coolDownBar.SetActive(false);
            }
            else
            {
                coolDownFill.fillAmount = 1 - coolDownTimer / coolDownTime;
            }
        }
    }
}
