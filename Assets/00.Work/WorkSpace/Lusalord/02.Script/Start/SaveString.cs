using _00.Work.Scripts.UI;
using _00.Work.WorkSpace.Lusalord._02.Script.StartScene.SO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _00.Work.WorkSpace.Lusalord._02.Script.Start
{
    public class SaveString : MonoBehaviour
    {
        [SerializeField] private SaveStringName saveStringName; // 플레이어 이름을 저장할 SO
        [SerializeField] private TextMeshProUGUI playerNameText; // InputField로 입력 받을 TMP 
    
        private void Update()
        {
            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                if (!string.IsNullOrEmpty(playerNameText.text))
                {
                    saveStringName.playerName = playerNameText.text;
                    FadeManager.Instance.FadeToScene(1);
                }
            }
        }
    }
}
