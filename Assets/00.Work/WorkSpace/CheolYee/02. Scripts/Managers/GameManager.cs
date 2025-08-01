using System;
using _00.Work.WorkSpace.ForRest._02._Scripts;
using UnityEngine;

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

        private void OnDisable()
        {
            TimerManager.Instance.OnTimerFinished -= IsGameClear;
        }

        private void IsGameClear()
        {
            if (DiskSliderBar.Instance.isSuccess)
            {
                if (MissionManager.Instance.targetFiles.Count <= 0)
                {
                    gameClearUI.SetActive(true);
                }
                else
                {
                    gameFailUI.SetActive(true);
                }
            }
            else
            {
                gameFailUI.SetActive(true);
            }
        }
    }
}