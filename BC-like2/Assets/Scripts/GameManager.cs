using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private int currentInventoryNumber;
    public int CurrentInventoryNumber
    {
        get 
        {
            return currentInventoryNumber; 
        }
        set
        {
            CurrentInventoryObject = InventoryObjects[value];
            currentInventoryNumber = value;
        }
    }

    public  InventoryObject CurrentInventoryObject;
    public  List<InventoryObject> InventoryObjects;

    [SerializeField]
    private List<UnitStat> normalUnitList;
    [SerializeField]
    private List<UnitStat> specialUnitList;

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        InventoryObjects = LoadAllInventories();
        CurrentInventoryNumber = PlayerPrefs.GetInt("currentInventory", 0);
        

        normalUnitList = LoadUnitListOfRarity("AllyStat/Normal");
        specialUnitList = LoadUnitListOfRarity("AllyStat/Special");
    }

    public List<UnitStat> LoadUnitListOfRarity(string rarity)
    {
        List<UnitStat> list = new List<UnitStat>();
        string path = "UnitsData/" + rarity;
        list = Resources.LoadAll(path, typeof(UnitStat)).Cast<UnitStat>().ToList();
        list = list.OrderBy(w => w.ID).ToList();
        return list;
    }

   public List<UnitStat> GetUnitListOfRarity(string rarity)
    {
        List<UnitStat> list = new List<UnitStat>();
        switch (rarity)
        {
            case "Normal":
                list = normalUnitList;
                break;
            case "Special":
                list = specialUnitList;
                break;
            default:
                break;
        }
        return list;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public List<InventoryObject> LoadAllInventories()
    {
        List<InventoryObject> list = new List<InventoryObject>();
        list = Resources.LoadAll("InventoryData", typeof(InventoryObject)).Cast<InventoryObject>().ToList();
        return list;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("currentInventory", currentInventoryNumber);
    }
}
