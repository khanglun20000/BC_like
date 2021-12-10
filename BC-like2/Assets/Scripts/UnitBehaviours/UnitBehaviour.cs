using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBehaviour : MonoBehaviour
{
    [SerializeField] protected UnitStat unitStat;
    public void SetUnitStat(UnitStat unitStat) 
    {
        this.unitStat = unitStat;
    }

}


