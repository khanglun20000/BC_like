using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] SpawnerUnitData[] sud;
    [SerializeField] bool canRandSpawn = true;
    [SerializeField] EnemyStat[] randomUnits; // array of units that can be ramdomly spawned
    [SerializeField] float timeStartRandSpawn = 8;
    [SerializeField] float minTimeBtwRandSpawn = 2;
    [SerializeField] float maxTimeBtwRandSpawn = 4;

    [SerializeField] Transform[] summonGate;
    float timeBtwRandSpawn;

    ISummonUnit summonType;

    // Start is called before the first frame update
    void Start()
    {
        summonType = new NormalSummon();

        timeBtwRandSpawn = timeStartRandSpawn;

        foreach(SpawnerUnitData unit in sud)
        {
            StartCoroutine(DelayedSpawn(unit));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canRandSpawn)
        {
            if (timeBtwRandSpawn <= 0)
            {
                SpawnUnit(randomUnits[UnityEngine.Random.Range(0, randomUnits.Length)]);
                print("spawn");
                timeBtwRandSpawn = UnityEngine.Random.Range(minTimeBtwRandSpawn, maxTimeBtwRandSpawn);
            }
            else
            {
                timeBtwRandSpawn -= Time.deltaTime;
            }
        }

    }

    void SpawnUnit(EnemyStat unitToSpawn)
    {
        summonType.DoSummon(unitToSpawn, summonGate[UnityEngine.Random.Range(0, summonGate.Length)]);
    }

    IEnumerator DelayedSpawn(SpawnerUnitData unit)
    {
        yield return new WaitForSeconds(unit.TSS_timeStartSpawning);
        for (int i = 0; i < unit.Waves; i++)
        {
           
            for (int j = 0; j < unit.UnitsEachWave; j++)
            {
                SpawnUnit(unit.unitToSpawn);
                print("delayedspawn");
                yield return new WaitForSeconds(unit.TBS_timeBtwSpawn);
            }
            if (unit.hasInfiniteWave)
            {
                i--;
            }
            yield return new WaitForSeconds(unit.TBW_timeBtwWaves - unit.TBS_timeBtwSpawn);
        }
        
    }
}
