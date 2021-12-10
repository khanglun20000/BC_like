using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory")]
public class InventoryObject : ScriptableObject
{
    public GameObject UI_InventoryPb;

    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddSlot(AllyStat _stat, int _slotNumber)
    {
        bool hasStat = false;
        for(int i = 0; i < Container.Count; i++)
        {
            if(Container[i].slotNumber == _slotNumber)
            {
                Container[i].stat = _stat;
                hasStat = true;
                break;
            }
        }
        if (!hasStat)
        {
            Container.Add(new InventorySlot(_stat, _slotNumber));
        }
    }

    public void RemoveSlot(int _slotNumber)
    {
        for(int i = 0; i < Container.Count; i++)
        {
            if(Container[i].slotNumber == _slotNumber)
            {
                Container.RemoveAt(i);
                break;
            }
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public AllyStat stat;
    public int slotNumber;

    public InventorySlot(AllyStat _stat, int _slotNumber)
    {
        stat = _stat;
        slotNumber = _slotNumber;
    }
}
