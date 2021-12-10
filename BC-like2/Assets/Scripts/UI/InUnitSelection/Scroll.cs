using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scroll : MonoBehaviour
{
    [SerializeField] GameObject carousel;

    [SerializeField] GameObject[] listUnitCarousel;

    [SerializeField] ScrollRect scrollRect;

    [SerializeField] BackBtn backBtn;

    [SerializeField] GameObject infoBtn;

    public static Scroll Instance;

    public GameObject UnitOnDrag;

    int activeContent;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public void ElementCallBack(CarouselElementType type)
    {
        carousel.SetActive(false);
        infoBtn.SetActive(true);
        backBtn.SetBtnState(BackBtn.BtnState.UNIT_CAROUSEL);
        switch (type)
        {
            case CarouselElementType.NORMAL:
                activeContent = SwitchContent(0);
                break;
            case CarouselElementType.SPECIAL:
                activeContent = SwitchContent(1);
                break;
        }

    }

    public int SwitchContent(int i)
    {
        listUnitCarousel[i].SetActive(true);
        scrollRect.content = listUnitCarousel[i].GetComponent<RectTransform>();
        return i;
    }

    public void SwitchBackContent()
    {
        listUnitCarousel[activeContent].SetActive(false);
        carousel.SetActive(true);
        scrollRect.content = carousel.GetComponent<RectTransform>();
        infoBtn.SetActive(false);
    }
}

public enum CarouselElementType
{
    NORMAL,
    SPECIAL
}
