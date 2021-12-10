using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : UnitBehaviour
{
    public abstract IEnumerator DoAttack();
}

public class SingleAttack : Attack
{
    float attackAniLength;
    int mask;
    int dir;

    private void Start()
    {

        attackAniLength = unitStat.attackAnimationLength;

        mask = LayerMask.NameToLayer(unitStat.GetEnemyLayerMaskName());

        if(unitStat.unitType == UnitType.Ally)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
    }
    public override IEnumerator DoAttack()
    {
        // play attack ani
        print("play ani");

        yield return new WaitForSeconds(attackAniLength);

        Vector2 endPos = (Vector2)transform.position + Vector2.right * unitStat.attackRange.GetValue() * dir;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * dir, Vector2.Distance(endPos, transform.position), 1 << mask);

        if (hit.collider)
        {
            if (hit.collider.GetComponent<HealthSystem>())
            {
                hit.collider.gameObject.GetComponent<HealthSystem>().TakeDamage(unitStat.attackRating.GetValue());
            }
            else
            {
                hit.collider.gameObject.GetComponent<SummonerController>().TakeDamage(unitStat.attackRating.GetValue());
            }
        }
    }
}
