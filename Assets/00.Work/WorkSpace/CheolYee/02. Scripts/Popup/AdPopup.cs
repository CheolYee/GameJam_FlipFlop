using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts.Popup
{
    public class AdPopup : MonoBehaviour
    {
        public event Action OnClose;
        
        [SerializeField] private Button closeButton;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private RectTransform headerBar;
        [SerializeField] private GameObject adPopupPrefab;

        [SerializeField] private List<Sprite> fakeAdSprites = new List<Sprite>();
        
        private int _remainingAds;
        private RectTransform _rectTransform;

        public void Initialize(string title, int adCount)
        {
            titleText.text = title;
            _remainingAds = adCount;
            Initialize(_remainingAds);
        }
        private void Initialize(int totalAds)
        {
            _rectTransform = GetComponent<RectTransform>();
            _remainingAds = totalAds;
            image.sprite = fakeAdSprites[Random.Range(0, fakeAdSprites.Count)];
            closeButton.onClick.AddListener(OnCloseClicked);
            _rectTransform.anchoredPosition = GetRandomPopupPosition(_rectTransform);
            
            Vector2 nativeSize = new Vector2(image.sprite.texture.width, image.sprite.texture.height);
            Vector2 newSize = nativeSize * 0.4f;

            image.rectTransform.sizeDelta = newSize;
            
            LayoutRebuilder.ForceRebuildLayoutImmediate(image.rectTransform);
            float imageWidth = image.rectTransform.rect.width;
            headerBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imageWidth);
        }

        private void OnCloseClicked()
        {
            if (_remainingAds > 0)
            {
                _remainingAds--;

                // 새로운 광고 팝업 생성
                Instantiate(adPopupPrefab, transform.parent)
                    .GetComponent<AdPopup>()
                    .Initialize(_remainingAds);
            }
            
            OnClose?.Invoke();
            Destroy(gameObject);
        }
        private Vector2 GetRandomPopupPosition(RectTransform popupRect)
        {
            var canvas = GetComponentInParent<Canvas>();
            var canvasRect = canvas.GetComponent<RectTransform>().rect;

            // 광고 팝업의 크기 고려해서 위치 범위 제한
            float popupWidth = popupRect.rect.width;
            float popupHeight = popupRect.rect.height;

            float x = Random.Range(-canvasRect.width / 4 + popupWidth / 4, canvasRect.width / 4 - popupWidth / 5);
            float y = Random.Range(-canvasRect.height / 4 + popupHeight / 4, canvasRect.height / 4 - popupHeight / 5);

            return new Vector2(x, y);
        }
        
        
    }
}