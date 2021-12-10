using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CarouselElement : MonoBehaviour
{
    Button button;

    [SerializeField] CarouselElementType type;

    Scroll scroll;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    private void OnEnable()
    {
        scroll = gameObject.GetComponentInParent<Scroll>();
        button.onClick.AddListener(() => scroll.ElementCallBack(type));
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }
}
