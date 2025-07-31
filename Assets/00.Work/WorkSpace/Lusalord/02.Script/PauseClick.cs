using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseClick : MonoBehaviour
{
    [SerializeField] private string _panelName;
    public void ExitClicked()
    {
        Application.Quit();
    }

    public void RestartClicked()
    {
        SceneManager.LoadScene(_panelName);
    }
}
