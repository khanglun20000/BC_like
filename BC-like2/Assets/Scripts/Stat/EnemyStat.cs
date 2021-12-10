using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyStat")]
public class EnemyStat : UnitStat
{
    public Trait trait;
    public int money;
}

public enum Trait
{
    Traitless,
    Red,
    Blue
}
