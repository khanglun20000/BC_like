using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] int baseValue;
    [SerializeField] int level;
    public int GetValue()
    {
        int incrementValue = (int)(baseValue * 0.1f);
        int finalValue = baseValue + level * incrementValue;
        return finalValue;
    }

    public int GetLevel()
    {
        return level;
    }

}
