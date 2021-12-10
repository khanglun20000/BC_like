using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Destroy : UnitBehaviour
{
    public abstract void DoDestroy();
}


public class EnemyDestroy : Destroy
{
    EnemyStat enemyStat;
    public override void DoDestroy()
    {
        enemyStat = unitStat as EnemyStat;
        MoneySystem.Instance.IncreaseMoney(enemyStat.money);
        Destroy(gameObject);
    }
}

public class AllyDestroy : Destroy
{
    public override void DoDestroy()
    {
        Destroy(gameObject);
    }
}
