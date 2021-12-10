using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UnitStat")]
public class UnitStat : ScriptableObject
{
    public int ID;

    public string unitName;

    public Sprite avatar;

    public Vector2 colliderSize;

    public Vector2 colliderOffset;

    public UnitType unitType;

    public UnitType enemyType;

    public AnimatorOverrideController animator;

    [TextArea(5,5)]
    public string description;

    public string[] BehaviourNames;

    public float attackAnimationLength;
    
    public Stat maxHealth;

    public Stat attackRating;

    public Stat attackRange;

    public Stat movementSpeed;

    public Stat timeBtwAttacks;

    public string GetLayerMaskName()
    {
        return unitType.ToString();
    }

    public string GetEnemyLayerMaskName()
    {
        return enemyType.ToString();
    }

}

public enum Rarity
{
    N,
    R,
    SR,
    UR
}

public enum UnitType
{
    Ally,
    Enemy
}

