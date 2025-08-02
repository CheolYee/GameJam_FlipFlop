using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts.Popup
{
    public class ImagePopup : MonoBehaviour
    {
        public event Action OnClose;
        
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private Image contentImage;
        [SerializeField] private RectTransform headerBar;

        public void Initialize(string title, Sprite image)
        {
            titleText.text = title;
            contentImage.sprite = image;
            
            //원본 이미지의 0.8배후 적용
            Vector2 nativeSize = new Vector2(image.texture.width, image.texture.height);
            Vector2 newSize = nativeSize * 0.4f;

            contentImage.rectTransform.sizeDelta = newSize;
            

            // 상단 바의 크기를 이미지 크기에 따라 맞춤
            LayoutRebuilder.ForceRebuildLayoutImmediate(contentImage.rectTransform);
            float imageWidth = contentImage.rectTransform.rect.width;
            headerBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imageWidth);
        }
        

        public void Close()
        {
            OnClose?.Invoke();
            Destroy(gameObject);
        }
    }
}