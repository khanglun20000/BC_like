using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChangeSceneBtn : MonoBehaviour
{
    private Button button;
    [SerializeField] private string nextScene;

    private void Awake()
    {
        button = GetComponent<Button>();
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
        SceneManager.LoadScene(nextScene);
    }
}
