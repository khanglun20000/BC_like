using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UnitCarouselElement : MonoBehaviour
{
    [SerializeField] Image unitAvatar;
    [SerializeField] TMP_Text unitCost;

    private AllyStat unitStat;

    public bool Focused
    {
        get
        {
            if (gameObject.activeInHierarchy)
            {
                return GetComponent<DragFunctionUE>().enabled;
            }
            else
            {
                return false;
            }
        }
    }

    private void OnDisable()
    {
        if(unitStat.slotNumber != 0)
            UnitSelectionScene.Instance.GetSlot(unitStat.slotNumber).SetBGToColor(Color.white);
    }

    public bool Equipped 
    {
        get => unitStat.equipped;
        set 
        {
            unitStat.equipped = value;
        } 
    }

    private void DisplayUI()
    {
        unitAvatar.sprite = unitStat.avatar;
        unitCost.text = unitStat.cost.ToString();
    }

    public void SetUnitStat(UnitStat unitStat)
    {
        this.unitStat = unitStat as AllyStat;
        DisplayUI();
    }

    public AllyStat GetUnitStat()
    {
        return unitStat;
    }
}
