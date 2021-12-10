using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ISummonUnit
{
    public void DoSummon(UnitStat unitStat, Transform transform);
}

public class NormalSummon : ISummonUnit
{
    public void DoSummon(UnitStat unitStat, Transform transform)
    {
        GameObject newUnitObject = new GameObject(unitStat.unitName, typeof(Unit), typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(Animator));
        newUnitObject.transform.position = transform.position;
        newUnitObject.GetComponent<Unit>().unitStat = unitStat;

        foreach (string behaviour in unitStat.BehaviourNames)
        {
            UnitBehaviour newBehaviour = newUnitObject.AddComponent(Type.GetType(behaviour)) as UnitBehaviour;
            newBehaviour.SetUnitStat(unitStat);
        }
    }
}
