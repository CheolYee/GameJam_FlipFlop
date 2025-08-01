using _00.Work.WorkSpace.Lusalord._02.Script.StartScene.SO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace _00.Work.WorkSpace.Lusalord._02.Script.StartScene
{
    public class SaveString : MonoBehaviour
    {
        [SerializeField] private SaveStringName saveStringName; // 플레이어 이름을 저장할 SO
        [SerializeField] private TextMeshProUGUI playerNameText; // InputField로 입력 받을 TMP 
        [SerializeField] private string sceneName; // 입력 받은 후, 이동 할 씬의 이름
    
        private void Update()
        {
            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                if (!string.IsNullOrEmpty(playerNameText.text))
                {
                    saveStringName.playerName = playerNameText.text;
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }
}
