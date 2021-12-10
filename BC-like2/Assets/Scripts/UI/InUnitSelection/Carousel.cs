using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carousel : MonoBehaviour
{
    [SerializeField] GameObject scrollbar;
    [SerializeField] private float scroll_pos = 0;
    [SerializeField] float[] pos;
    [SerializeField] float distance;
    protected virtual void Awake()
    {
        pos = new float[transform.childCount];

        distance = 1f / (pos.Length - 1f);

    }
    private void OnEnable()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            Transform childTransform = transform.GetChild(i);
            pos[i] = distance * i;
            childTransform.localScale = new Vector2(1f, 1f);

            if (i == 0)
            {
                EnableDrag(i, childTransform);
            }
            else
            {
                DisableDrag(i, childTransform);
                childTransform.localScale = new Vector2(0.75f, 0.75f);
            }
        }

    }
    private void OnDisable()
    {
        scroll_pos = 0;
    }
    protected virtual void Update()
    {
        if (Input.GetMouseButton(0))
        {
            scroll_pos = Mathf.Clamp(scrollbar.GetComponent<Scrollbar>().value, 0f, 1f);
            for (int i = 0; i < pos.Length; i++)
            {
                Transform childTransform = transform.GetChild(i);
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    EnableDrag(i, childTransform);
                    childTransform.localScale = new Vector2(1f, 1f);
                    for (int j = 0; j < pos.Length; j++)
                    {
                        if (j != i)
                        {
                            transform.GetChild(j).localScale = new Vector2(0.75f, 0.75f);
                        }
                    }
                }
                else
                {
                    if(pos.Length != 1)
                        DisableDrag(i, childTransform);
                }
            }
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }
    }

    protected virtual void EnableDrag(int i, Transform childTransform)
    {
        childTransform.GetComponent<Button>().interactable = true;

    }
    protected virtual void DisableDrag(int i, Transform childTransform) 
    {
        childTransform.GetComponent<Button>().interactable = false;
    }


}


