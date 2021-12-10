using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitSelectionScene : MonoBehaviour
{
    [SerializeField] private Canvas Canvas;
    [SerializeField] private InventoryObject currentInventoryObject;
    private Transform currentInventoryTransform;

    public static UnitSelectionScene Instance;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        currentInventoryObject = GameManager.Instance.CurrentInventoryObject;
        currentInventoryTransform = Instantiate(currentInventoryObject.UI_InventoryPb, Canvas.transform).transform;
        currentInventoryTransform.SetAsFirstSibling();
        LoadUSToInventory();
    }


    public UnitSelectionSlot GetSlot(int _slotNumber)
    {
        UnitSelectionSlot childUSS;
        if (_slotNumber != 7)
        {
            childUSS = currentInventoryTransform.GetChild(0).GetChild(_slotNumber - 1).GetChild(0).GetComponent<UnitSelectionSlot>();
        }
        else
        {
            childUSS = currentInventoryTransform.GetChild(1).GetChild(0).GetComponent<UnitSelectionSlot>();
        }
        return childUSS;
    }

    public void LoadUSToInventory()
    {
        foreach (InventorySlot slot in currentInventoryObject.Container)
        {
            if (slot.slotNumber != 7)
            {
                GetSlot(slot.slotNumber).SetUnitStat(slot.stat);
            }
            else
            {
                GetSlot(slot.slotNumber).SetUnitStat(slot.stat);
            }
        }
    }

    public void SetUSToSlot(AllyStat _stat, int _slotNumber)
    {
        if (_slotNumber != 7)
        {
            GetSlot(_slotNumber).SetUnitStat(_stat);
            currentInventoryObject.AddSlot(_stat, _slotNumber);
        }
        else
        {
            GetSlot(_slotNumber).SetUnitStat(_stat);
            currentInventoryObject.AddSlot(_stat, _slotNumber);
        }
    }

    public void RemoveUSfromSlot(int _slotNumber)
    {
        if (_slotNumber != 7)
        {
            GetSlot(_slotNumber).Erase();
            currentInventoryObject.RemoveSlot(_slotNumber);
        }
        else
        {
            GetSlot(_slotNumber).Erase();
            currentInventoryObject.RemoveSlot(_slotNumber);
        }
    }
}
