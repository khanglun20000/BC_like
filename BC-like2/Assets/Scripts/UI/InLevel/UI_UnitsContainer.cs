using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UnitsContainer : MonoBehaviour
{
    [SerializeField] private InventoryObject inventoryObject;

    [SerializeField] private Button[] unitSlots;
    [SerializeField] Canvas[] slotLists;
    [SerializeField] Button[] unitSlots1;
    [SerializeField] Button[] unitSlots2;
    [SerializeField] private Button specialSlot;

    bool activeList = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SwapCanvasesOrder(); 

            if (!activeList)
            {
                EnableButtons(unitSlots2);
                DisableButtons (unitSlots1);
                activeList = true;
            }
            else
            {
                EnableButtons(unitSlots1);
                DisableButtons(unitSlots2);
                activeList = false;
            }
        }
    }
    public void SetInventoryObject(InventoryObject _inventoryObject)
    {
        inventoryObject = _inventoryObject;
        RefreshUC();
        unitSlots1 = GetHalfList(0, unitSlots); // set buttons 0-2 from unitSlots to unitSlot1
        unitSlots2 = GetHalfList(3, unitSlots); // set buttons 3-5 from unitSlots to unitSlot1
        DisableButtons(unitSlots2);
    }
    void RefreshUC()
    {
        foreach (InventorySlot slot in inventoryObject.Container)
        {
            if (slot.slotNumber != 7)
            {
                unitSlots[slot.slotNumber - 1].image.sprite = slot.stat.avatar;
                unitSlots[slot.slotNumber - 1].GetComponent<UnitSlot>().SetUnit(slot.stat);
            }
            else
            {
                specialSlot.image.sprite = slot.stat.avatar;
                specialSlot.GetComponent<UnitSlot>().SetUnit(slot.stat);
            }
        }
    }
   
    void EnableButtons(Button[] btnList)
    {
        foreach(Button button in btnList)
        {
            button.enabled = true;
            button.image.color *= 2;
            button.gameObject.transform.parent.GetComponent<Image>().color *= 2;
        }
    }

    void DisableButtons(Button[] btnList)  
    {
        foreach (Button button in btnList)
        {
            button.enabled = false;
            var tempColor = button.image.color;
            tempColor /= 2;
            tempColor.a = 1f;
            button.gameObject.transform.parent.GetComponent<Image>().color = tempColor; 
            button.image.color = tempColor;
        }
    }
    private Button[] GetHalfList(int firstEle, Button[] btnList)
    {
        Button[] halfList = new Button[3];
        for(int i = 0; i < 3; i++)
        {
            halfList[i] = btnList[i + firstEle];
        }
        return halfList;
    }

    void SwapCanvasesOrder()
    {
        var temp = slotLists[0].sortingOrder;
        slotLists[0].sortingOrder = slotLists[1].sortingOrder;
        slotLists[1].sortingOrder = temp;
    }
}
