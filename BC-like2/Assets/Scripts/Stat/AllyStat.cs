using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New AllyStat")]
public class AllyStat : UnitStat
{
    public Stat cost;
    public Stat rechargeTime;
    public int level;
    public Rarity rarity;

    public bool unlocked;
    public bool equipped;
    public int slotNumber;
}