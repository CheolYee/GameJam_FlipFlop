using _00.Work.Scripts.Managers;
using _00.Work.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.WorkSpace.Lusalord._02.Script.LoadScene
{
    public class StageSelect : MonoBehaviour
    {
        [SerializeField] private Button[] buttons;

        private void Start()
        {
            SetupStageButtons();
        }

        public void StageLoad(int num)
        {
            FadeManager.Instance.FadeToScene(num);
        }
    
        void SetupStageButtons()
        {
            var data = SaveManager.LoadStageData();

            foreach (var button in buttons) // stageButtons는 스테이지 버튼 배열
            {
                int stageName = int.Parse(button.gameObject.name);

                if (data.stageProgress.Contains(stageName))
                    button.interactable = true;
                else
                    button.interactable = false;
            }
        }
    }
}
