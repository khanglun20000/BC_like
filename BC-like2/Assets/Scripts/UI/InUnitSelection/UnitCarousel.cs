using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UnitCarousel : Carousel
{
    List<AllyStat> unitStats;

    [SerializeField] string unitType;

    [SerializeField] Button btnPb;

    [SerializeField] RectTransform content;

    // Start is called before the first frame update
    protected override void Awake()
    {
        if (GameManager.Instance)
        {
            unitStats = GameManager.Instance.GetUnitListOfRarity(unitType).Cast<AllyStat>().ToList();
            foreach(AllyStat stat in unitStats)
            {
                if (stat.unlocked)
                {
                    Button button = Instantiate(btnPb, content, false);
                    button.GetComponent<UnitCarouselElement>().SetUnitStat(stat);
                }
            }
        }
        base.Awake();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void EnableDrag(int i, Transform childTranform)
    {
        base.EnableDrag(i, childTranform);
        childTranform.GetComponent<DragFunctionUE>().enabled = true;
        if(childTranform.GetComponent<UnitCarouselElement>().Focused && childTranform.GetComponent<UnitCarouselElement>().GetUnitStat().slotNumber != 0)
        {
            UnitSelectionScene.Instance.GetSlot(childTranform.GetComponent<UnitCarouselElement>().GetUnitStat().slotNumber).SetBGToColor(Color.green);
        }
        UI_Info.Instance.SetAllyStat(unitStats[i]);
    }

    protected override void DisableDrag(int i, Transform childTranform)
    {
        base.DisableDrag(i, childTranform);
        childTranform.GetComponent<DragFunctionUE>().enabled = false;
        if (!childTranform.GetComponent<UnitCarouselElement>().Focused && childTranform.GetComponent<UnitCarouselElement>().GetUnitStat().slotNumber != 0)
        {
            UnitSelectionScene.Instance.GetSlot(childTranform.GetComponent<UnitCarouselElement>().GetUnitStat().slotNumber).SetBGToColor(Color.white);
        }
      
    }
    
    public void GoToPos(int pos)
    {

    }
}
