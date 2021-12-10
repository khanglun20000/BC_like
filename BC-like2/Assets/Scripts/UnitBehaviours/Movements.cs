using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Movement : UnitBehaviour
{
    public abstract void DoMove();
}

public class LeftMove : Movement
{
    public override void DoMove()
    {
        transform.position += -transform.right * unitStat.movementSpeed.GetValue() * Time.deltaTime;
    }
}

public class RightMove : Movement
{
    public override void DoMove()
    {
        transform.position += transform.right * unitStat.movementSpeed.GetValue() * Time.deltaTime;
    }
}


