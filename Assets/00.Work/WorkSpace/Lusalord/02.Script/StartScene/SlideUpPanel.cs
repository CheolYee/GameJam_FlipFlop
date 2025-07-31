using UnityEngine;
using UnityEngine.InputSystem;

namespace _00.Work.WorkSpace.Lusalord._02.Script
{
    public class SlideUpPanel : MonoBehaviour
    {
        public float showY; // 올라왔을 때 Y 위치
        public float hideY = -300f; // 숨겨졌을 때 Y 위치
        public float slideSpeed = 5f; // 움직이는 속도 (값이 클수록 빠름)

        private RectTransform _rectTransform;
        private bool _isOpen; // 현재 상태

        void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.anchoredPosition = new Vector2(0, hideY); // 시작 시 숨김
        }

        void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                _isOpen = !_isOpen;
                StopAllCoroutines();
                StartCoroutine(SlideTo(_isOpen ? showY : hideY));
            }
        }

        System.Collections.IEnumerator SlideTo(float targetY)
        {
            float duration = 0.3f;
            float time = 0;
            float startY = _rectTransform.anchoredPosition.y;

            while (time < duration)
            {
                float newY = Mathf.Lerp(startY, targetY, time / duration);
                _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, newY);
                time += Time.deltaTime * slideSpeed;
                yield return null;
            }

            _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, targetY);
        }
    }
}
