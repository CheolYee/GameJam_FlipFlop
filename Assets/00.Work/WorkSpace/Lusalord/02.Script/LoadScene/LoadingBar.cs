using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.WorkSpace.Lusalord._02.Script.LoadScene
{
    public class LoadingBar : MonoBehaviour
    {
        [SerializeField] private Scrollbar scrollbar;
        [SerializeField] private float stepInterval = 0.1f;     // 한 칸 이동 주기 (초)
        [SerializeField] private float stepAmount = 0.05f;       // 한 번에 이동하는 거리
        [SerializeField] private float totalLoadingTime = 5f;    // 전체 로딩 시간

        private float _elapsedLoadingTime = 0f;

        private void Start()
        {
            if (scrollbar == null)
            {
                Debug.LogError("Scrollbar가 연결되지 않았습니다.");
                enabled = false;
                return;
            }

            scrollbar.value = 0f;
            StartCoroutine(LoadingRoutine());
        }

        private IEnumerator LoadingRoutine()
        {
            _elapsedLoadingTime = 0f;

            while (_elapsedLoadingTime < totalLoadingTime)
            {
                // 스크롤바 값을 한 스텝 이동
                scrollbar.value += stepAmount;

                // 오른쪽 끝에 도달하면 다시 0으로
                if (scrollbar.value >= 1f)
                {
                    scrollbar.value = 0f;
                }

                _elapsedLoadingTime += stepInterval;
                yield return new WaitForSeconds(stepInterval);
            }

            scrollbar.value = 1f;
            Debug.Log("로딩 완료!");
        }
    }
}
