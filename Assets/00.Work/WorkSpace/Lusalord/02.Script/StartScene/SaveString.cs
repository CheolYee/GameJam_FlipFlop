using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _00.Work.WorkSpace.Lusalord._02.Script.StartScene
{
    public class SaveString : MonoBehaviour
    {
        [SerializeField] private SaveStringName saveStringName;
        [SerializeField] private TextMeshProUGUI playerNameText;
    
        private void Update()
        {
            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                if (!string.IsNullOrEmpty(playerNameText.text))
                {
                    saveStringName.playerName = playerNameText.text;
                }
            }
        }
    }
}
