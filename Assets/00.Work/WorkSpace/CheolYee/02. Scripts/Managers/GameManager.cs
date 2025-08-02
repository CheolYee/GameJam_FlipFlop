using _00.Work.Scripts.Managers;
using _00.Work.Scripts.UI;
using _00.Work.WorkSpace.ForRest._02._Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameClearUI;
        [SerializeField] private GameObject gameFailUI;
        
        private void Awake()
        {
            gameClearUI.SetActive(false);
            gameFailUI.SetActive(false);
        }

        private void Start()
        {
            TimerManager.Instance.OnTimerFinished += IsGameClear;
        }

        private void IsGameClear()
        {
            if (DiskSliderBar.Instance.isSuccess)
            {
                if (MissionManager.Instance.targetFiles.Count <= 0)
                {
                    int currentStage = SceneManager.GetActiveScene().buildIndex;
                    int nextStage = currentStage + 1;
                    
                    if (nextStage < SceneManager.sceneCountInBuildSettings)
                    {
                        OnStageClear(nextStage);
                    }

                    gameClearUI.SetActive(true);
                    GameEndTrigger clearUI = gameClearUI.GetComponent<GameEndTrigger>();
                    clearUI.OnAnyKeyPressed += () => FadeManager.Instance.FadeToScene(1);
                    clearUI.OnRKeyPressed += () => FadeManager.Instance.FadeToScene(SceneManager.GetActiveScene().buildIndex);
                }
                else
                {
                    gameFailUI.SetActive(true);
                    GameEndTrigger clearUI = gameFailUI.GetComponent<GameEndTrigger>();
                    clearUI.OnAnyKeyPressed += () => FadeManager.Instance.FadeToScene(1);
                    clearUI.OnRKeyPressed += () => FadeManager.Instance.FadeToScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            else
            {
                gameFailUI.SetActive(true);
                GameEndTrigger clearUI = gameFailUI.GetComponent<GameEndTrigger>();
                clearUI.OnAnyKeyPressed += () => FadeManager.Instance.FadeToScene(1);
                clearUI.OnRKeyPressed += () => FadeManager.Instance.FadeToScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
        void OnStageClear(int nextStage)
        {
            var data = SaveManager.LoadStageData();

            // 다음 스테이지 해금
            if (!data.stageProgress.Contains(nextStage))
                data.stageProgress.Add(nextStage);
            // 저장
            SaveManager.SaveStageData(data);
        }

    }
}