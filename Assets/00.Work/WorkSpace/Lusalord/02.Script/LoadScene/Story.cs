using _00.Work.Scripts.UI;
using _00.Work.WorkSpace.Lusalord._02.Script.SO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Story : MonoBehaviour
{
    private int num = 1;
    [SerializeField] private StoryScript[] script;
    
    [SerializeField] private TextMeshProUGUI storyText;
    

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
                FadeManager.Instance.FadeToScene(0);
                return;
            }
            storyText.text = script[num].story;
            num++;
            
        }
        
    }
}
