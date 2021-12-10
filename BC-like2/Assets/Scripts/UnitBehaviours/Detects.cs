using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Detect : UnitBehaviour
{
    public abstract bool DoDetect();
}

public class NormalDetect : Detect
{
    public override bool DoDetect()
    {
        int dir;
        if (unitStat.unitType == UnitType.Ally)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }

        int mask = LayerMask.NameToLayer(unitStat.GetEnemyLayerMaskName());

        Vector2 endPos = (Vector2)transform.position + Vector2.right * unitStat.attackRange.GetValue() * dir;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * dir, Vector2.Distance(endPos,transform.position) , 1 << mask);
       
        Debug.DrawLine(transform.position, endPos, Color.red);
        
        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
