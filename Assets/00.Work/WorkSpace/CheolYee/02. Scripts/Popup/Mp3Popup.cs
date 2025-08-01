using System;
using _00.Work.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts.Popup
{
    public class Mp3Popup : MonoBehaviour
    {
        public event Action OnClose;
        
        [SerializeField] private Button closeButton;
        [SerializeField] private Button playButton;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private RectTransform headerBar;

        private RectTransform _rectTransform;
        private string _mp3FilePath;

        public void Initialize(string mp3Name)
        {
            titleText.text = mp3Name;
            _mp3FilePath = mp3Name;
            playButton.onClick.AddListener(OnPlayeButtonClicked);
            closeButton.onClick.AddListener(Close);
        }
        
        public void Close()
        {
            OnClose?.Invoke();
            Destroy(gameObject);
        }

        private void OnPlayeButtonClicked()
        {
            SoundManager.Instance.PlaySfx(_mp3FilePath, true);
        }
        
        
    }
}