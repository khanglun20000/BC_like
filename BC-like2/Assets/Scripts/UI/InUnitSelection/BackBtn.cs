using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackBtn : MonoBehaviour
{
    private Button button;

    private BtnState state;

    [SerializeField] ScrollRect scrollRect;

    private void Awake()
    {
        button = GetComponent<Button>();
        state = BtnState.CAROUSEL;
    }

    public void SetBtnState(BtnState state)
    {
        this.state = state;
    }

    private void OnEnable()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }
    void TaskOnClick()
    {
        switch (state)
        {
            case BtnState.CAROUSEL:
                SceneManager.LoadScene("Menu");
                break;
            case BtnState.UNIT_CAROUSEL:
                scrollRect.GetComponent<Scroll>().SwitchBackContent();
                state = BtnState.CAROUSEL;
                break;
        }
    }
    public enum BtnState
    {
        CAROUSEL,
        UNIT_CAROUSEL
    }
}
