using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public float scrollSpeed;
    public Camera gameCamera;
    public AllyStat[] unitsList;
    [SerializeField] private InventoryObject currentInventoryObject;

    [SerializeField] Transform[] summonGate;

    [SerializeField] UI_UnitsContainer ui_uc;

    ISummonUnit summonType;
    public static GameScene Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        summonType = new NormalSummon();

        currentInventoryObject = GameManager.Instance.CurrentInventoryObject;
        ui_uc.SetInventoryObject(currentInventoryObject);
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        if(inputX != 0)
        {
            gameCamera.transform.position += transform.right * scrollSpeed * inputX * Time.deltaTime;
        }
    }

    public void SummonUnit(AllyStat unitToSummon)
    {
        summonType.DoSummon(unitToSummon, summonGate[UnityEngine.Random.Range(0,summonGate.Length)]);
    }
}
