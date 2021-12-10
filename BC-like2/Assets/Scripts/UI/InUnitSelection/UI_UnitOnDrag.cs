using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_UnitOnDrag : MonoBehaviour
{
    [SerializeField] private Image unitAvatar;
    [SerializeField] private TMP_Text unitCost;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    
    public void DisplayUnitOnDrag(AllyStat unitStat)
    {
        unitAvatar.sprite = unitStat.avatar;
        unitCost.text = unitStat.cost.ToString();
    }
}
