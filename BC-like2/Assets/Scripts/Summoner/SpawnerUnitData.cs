using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnerUnitData
{
    public EnemyStat unitToSpawn;
    public bool hasInfiniteWave;

    public int Waves;
    public int UnitsEachWave;
    public float TBW_timeBtwWaves;

    public float TBS_timeBtwSpawn;
    public float TSS_timeStartSpawning;

    
}
