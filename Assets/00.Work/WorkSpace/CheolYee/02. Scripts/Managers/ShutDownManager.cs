using System.Collections;
using _00.Work.Scripts.Managers;
using UnityEngine;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts.Managers
{
    public class ShutDownManager : MonoSingleton<ShutDownManager>
    {
        public GameObject shutdownPanel;

        protected override void Awake()
        {
            base.Awake();
            shutdownPanel.SetActive(false); // 초기엔 비활성화
        }

        public void TriggerShutdown(float shutdownDuration)
        {
            StartCoroutine(ShutdownRoutine(shutdownDuration));
        }

        private IEnumerator ShutdownRoutine(float shutdownDuration)
        {
            shutdownPanel.SetActive(true);

            // RaycastBlock 유지 (버튼 클릭 등 차단)
            yield return new WaitForSeconds(shutdownDuration);

            shutdownPanel.SetActive(false);
        }
    }
}