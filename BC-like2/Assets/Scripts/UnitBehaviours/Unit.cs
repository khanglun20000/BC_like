using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool canMove = true;

    public UnitStat unitStat;

    Movement movementType;
    Attack attackType;
    Detect detectType;
    Animator animator;

    float timeBtwAttacks;

    [SerializeField] bool attacking;

    private void Start()
    {
        GetAppearance();
        SetCollider();
        SetLayer();

        movementType = gameObject.GetComponent<Movement>();
        attackType = gameObject.GetComponent<Attack>();
        detectType = gameObject.GetComponent<Detect>();

        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = unitStat.animator;
    }

    private void Update()
    {
        if (DetectEnemy() && !attacking)
        {
            canMove = false;
            animator.SetBool("isMoving", false);

            if (timeBtwAttacks <= 0)
            {
                animator.SetBool("isWaitingAttack", false);
                StartCoroutine(PerformAttack());
                timeBtwAttacks = unitStat.timeBtwAttacks.GetValue();
            }
            else
            {
                timeBtwAttacks -= Time.deltaTime;
                animator.SetBool("isWaitingAttack", true);
            }
        }
        else if(!DetectEnemy() && !attacking)
        {
            canMove = true;
            animator.SetBool("isWaitingAttack", false);
            // reset timeBtwAttack
            if (timeBtwAttacks >= 0)
            {
                timeBtwAttacks = 0;
            }
        }
        PerformMove();
    }
    public void PerformMove()
    {
        if (canMove)
        {
            animator.SetBool("isMoving", true);
            movementType.DoMove();
        }
    }

    public IEnumerator PerformAttack()
    {
        animator.SetBool("isAttacking",true);
        attacking = true;
        yield return StartCoroutine(attackType.DoAttack());
        attacking = false;
        animator.SetBool("isAttacking", false);
    }

    public bool DetectEnemy()
    {
        return detectType.DoDetect();
    }


    public void GetAppearance()
    {
        GetComponent<SpriteRenderer>().sprite = unitStat.avatar;
    }

    public void SetLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(unitStat.GetLayerMaskName());
    }


    public UnitStat SetUnitStat(UnitStat unitStat)
    {
        this.unitStat = unitStat;
        return this.unitStat;
    }

    public void SetCollider()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        col.size = unitStat.colliderSize;
        col.offset = unitStat.colliderOffset;
    }
}
