using System;
using System.Collections;
using _00.Work.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace _00.Work.WorkSpace.ForRest._02._Scripts
{
    public class TimerManager : MonoSingleton<TimerManager>
    {
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private float startSeconds = 120f;
    
        public event Action OnTimerFinished;

        private float _remainingSeconds;
        private Coroutine _countDownCoroutine;
        private bool _isRunning;

        private void Start()
        {
            StartTimer(startSeconds); //시작 시 시작 초로 타이머 시작
        }
        
        //타이머 시작 (어디서든 TimerManager.Instance.StartTimer()로 호출 가능)
        private void StartTimer(float setTime)
        {
            if (_isRunning) return; //이미 타이머가 돌아가고 있다면 무시
        
            _remainingSeconds = setTime; //시작 시간을 입력값으로 설정
            _countDownCoroutine = StartCoroutine(TimerCoroutine()); //코루틴 시작해서 1초씩 감소
            _isRunning = true; //타이머 작동 중이라고 표시
        }

        public void RestartTimer()
        {
            if (_isRunning) return;
        
            StartTimer(_remainingSeconds);
        }
        
        //타이머 멈춤 (어디서든 TimerManager.Instance.StopTimer()로 호출 가능)
        public void StopTimer()
        {
            if (!_isRunning) return; //타이머가 돌고 있지 않다면 무시
        
            StopCoroutine(_countDownCoroutine); //타이머 코루틴 멈춤
            _isRunning = false; //타이머 작동 안하고 있다고 표시
            Debug.Log("Stop Timer");
        }

        public void AddTimer(float setTime) // 타이머의 시간을 뺄 수 있는 기능
        {
            _remainingSeconds += setTime;
            UpdateTimerUI();
        }
        
        public void LessTimer(float setTime) // 타이머의 시간을 뺄 수 있는 기능
        {
            _remainingSeconds -= setTime;
            UpdateTimerUI();
        }
        
        public void SetTimer(float setTime) // 타이머의 시간을 설정할 수 있는 기능
        {
            _remainingSeconds = setTime;
            UpdateTimerUI();
        }
        
        //타이머 동작
        private void UpdateTimerUI() //화면에 시간 표시하는 함수
        {
            int minutes = Mathf.FloorToInt(_remainingSeconds / 60); // 분
            int seconds = Mathf.FloorToInt(_remainingSeconds % 60); // 초
            timerText.text = $"{minutes:00}:{seconds:00}"; // 00:00처럼 나오게 표시
        }

        private IEnumerator TimerCoroutine() //1초씩 시간 감소 코루틴
        {
            while (_remainingSeconds > 0) //시간이 0보다 클 시 무한 반복
            {
                UpdateTimerUI(); //화면에 시간 보여주기
                yield return null; //1초 기다리기
                _remainingSeconds -= Time.deltaTime; //현재 타이머 시간 1초 감소
            }

        
            //타이머가 끝났을 시
            _remainingSeconds = 0; //혹시 음수가 되지 않도록 0으로 설정
            UpdateTimerUI(); //마지막 시간 업데이트 (00:00 보여주기)
            _isRunning = false; //타이머 작동 중지
        
            OnTimerFinished?.Invoke(); //등록된 이벤트 함수가 있다면 종료 이벤트 실행
        }

        private new void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
