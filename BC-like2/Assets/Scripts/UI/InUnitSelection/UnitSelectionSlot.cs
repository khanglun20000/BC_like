using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UnitSelectionSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public AllyStat unitStat;
    public bool isEmpty = true; // check if the slot is empty 
    public int slotNumber;

    [SerializeField] private Image unitAvatar;
    [SerializeField] private Image avatartBG;
    [SerializeField] private TMP_Text unitCost;

    private GameObject unitOnDrag;
    private RectTransform rect;
    private UI_UnitOnDrag _UI_UnitOnDrag;

    // check if this USS is receiving unitstat from UnistCarouselElement or other UnitSelectionSlot
    public bool isReceivingUS = false;

    // check if this slot is giving unitstat
    public bool isPassingUS = false;


    private void Start()
    {
        unitOnDrag = Scroll.Instance.UnitOnDrag;

        rect = unitOnDrag.GetComponent<RectTransform>();

        _UI_UnitOnDrag = unitOnDrag.GetComponent<UI_UnitOnDrag>();
    }

    public void Erase()
    {
        unitStat = null;

        isEmpty = true;
        unitAvatar.color = new Color(0,0,0,0);
        unitCost.text = null;
        SetBGToColor(Color.white);
    }

    public void SetUnitStat(AllyStat allyStat)
    {
        unitStat = allyStat;
        unitStat.slotNumber = slotNumber;
        unitStat.equipped = true;

        isEmpty = false;
        isReceivingUS = true;
        UnitStatDropped();
    }
    public void UnitStatDropped()
    {
        unitAvatar.sprite = unitStat.avatar;
        unitAvatar.color = new Color(1,1,1,1);
        unitCost.text = unitStat.cost.ToString();

    }

    public void SetBGToColor(Color color)
    {
        avatartBG.color = color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag 
           && ((eventData.pointerDrag.GetComponent<UnitCarouselElement>() && eventData.pointerDrag.GetComponent<DragFunctionUE>().CanDragged) 
            || (eventData.pointerDrag.GetComponent<UnitSelectionSlot>() && eventData.pointerDrag != gameObject && !eventData.pointerDrag.GetComponent<UnitSelectionSlot>().isEmpty)))
        {
            SetBGToColor(Color.red);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag
           && ((eventData.pointerDrag.GetComponent<UnitCarouselElement>() && !eventData.pointerDrag.GetComponent<UnitCarouselElement>().Equipped)
            || (eventData.pointerDrag.GetComponent<UnitSelectionSlot>() && eventData.pointerDrag != gameObject && !eventData.pointerDrag.GetComponent<UnitSelectionSlot>().isEmpty)))
        {
            SetBGToColor(Color.white);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isEmpty)
        {
            _UI_UnitOnDrag.DisplayUnitOnDrag(GetComponent<UnitSelectionSlot>().unitStat);
            unitOnDrag.SetActive(true);
            rect.anchoredPosition = eventData.delta;
            isReceivingUS = false;
            isPassingUS = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.position = (Vector2)Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // receive from UnitCarousel
        if (eventData.pointerDrag.GetComponent<UnitCarouselElement>() && !eventData.pointerDrag.GetComponent<UnitCarouselElement>().Equipped)
        {
            UnitSelectionScene.Instance.SetUSToSlot(eventData.pointerDrag.GetComponent<UnitCarouselElement>().GetUnitStat(), slotNumber);
            SetBGToColor(Color.green);
        }

        // receive from other slot
        if (eventData.pointerDrag.GetComponent<UnitSelectionSlot>() && eventData.pointerDrag != gameObject && !eventData.pointerDrag.GetComponent<UnitSelectionSlot>().isEmpty)
        {
            // USS of giving slot
            UnitSelectionSlot cacheUSS = eventData.pointerDrag.GetComponent<UnitSelectionSlot>();
            Color tempColor = avatartBG.color;
            AllyStat tempUS = unitStat;

            // set unitstat from giving slot for this slot
            UnitSelectionScene.Instance.SetUSToSlot(cacheUSS.unitStat, slotNumber);
            avatartBG.color = cacheUSS.avatartBG.color;
            cacheUSS.isPassingUS = true;

            // if this slot already has unitstat
            if (!isEmpty && tempUS)                                                                      
            {
                // if yes set unitstat of this slot for giving slot
                UnitSelectionScene.Instance.SetUSToSlot(tempUS, cacheUSS.slotNumber);
                cacheUSS.avatartBG.color = tempColor;
                isPassingUS = true;
            }
            else
            {
                isPassingUS = false;
            }
        }
        // if drag inisde this game object
        else if (eventData.pointerDrag == gameObject && !eventData.pointerDrag.GetComponent<UnitSelectionSlot>().isEmpty)   
        {
            isReceivingUS = true;
            isPassingUS = true;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        unitOnDrag.SetActive(false);

        if (isEmpty)
        {
            SetBGToColor(Color.white);
        }
        else
        {
            if (!isPassingUS)
            {
                unitStat.equipped = false;
                unitStat.slotNumber = 0;
            }

            if (!isReceivingUS)
            {
                UnitSelectionScene.Instance.RemoveUSfromSlot(slotNumber);
            }
        }

        isPassingUS = false;
        isReceivingUS = false;
    }
}
