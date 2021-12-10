using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;

public class DragFunctionUE : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private GameObject unitOnDrag;
    private RectTransform rect;
    private UI_UnitOnDrag _UI_UnitOnDrag;

    public bool CanDragged
    {
        get => !GetComponent<UnitCarouselElement>().Equipped;
    }

    // Start is called before the first frame update
    void Start()
    {
        unitOnDrag = Scroll.Instance.UnitOnDrag;

        rect = unitOnDrag.GetComponent<RectTransform>();

        _UI_UnitOnDrag = unitOnDrag.GetComponent<UI_UnitOnDrag>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CanDragged)
        {
            _UI_UnitOnDrag.DisplayUnitOnDrag(GetComponent<UnitCarouselElement>().GetUnitStat());
            unitOnDrag.SetActive(true);
            rect.anchoredPosition = eventData.delta;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CanDragged)
            rect.position = (Vector2)Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        unitOnDrag.SetActive(false);
    }
}
