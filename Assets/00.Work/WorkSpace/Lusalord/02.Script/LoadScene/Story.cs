using System;
using System.Collections;
using _00.Work.WorkSpace.Lusalord._02.Script.SO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    private int num = 1;
    [SerializeField] private StoryScript[] script;
    
    [SerializeField] private TextMeshProUGUI storyText;
    
    [SerializeField] private string sceneName;

    private void Start()
    {
        storyText.text = script[0].story;
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (num >= script.Length)
            {
                SceneManager.LoadScene(sceneName);
            }
            storyText.text = script[num].story;
            num++;
            
        }
        
    }
}
