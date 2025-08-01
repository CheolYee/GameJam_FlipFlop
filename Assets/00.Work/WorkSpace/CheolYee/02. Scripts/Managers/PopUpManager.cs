using System.Collections.Generic;
using _00.Work.Scripts.Managers;
using _00.Work.WorkSpace.CheolYee._02._Scripts.Popup;
using UnityEngine;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts.Managers
{
    public class PopUpManager : MonoSingleton<PopUpManager>
    {
        [SerializeField] private Transform popupParent;
        [SerializeField] private GameObject imagePopupPrefab;
        [SerializeField] private GameObject textPopupPrefab;
        [SerializeField] private GameObject adPopupPrefab;

        private readonly Dictionary<string, GameObject> _activePopups = new();
        
        public void OpenPopup(FileDataSo popupData)
        {
            if (!popupData.openFile) return;
            
            switch (popupData.openType)
            {
                case OpenType.OpenImg:
                    OpenImagePopup(popupData);
                    break;
                case OpenType.ShowWindow:
                    OpenTextPopup(popupData);
                    break;
                case OpenType.ShowAd:
                    OpenAdPopup(popupData);
                    break;
                case OpenType.ShutDown:
                    ShutDownManager.Instance.TriggerShutdown(popupData.shutDownCount);
                    break;
            }
        }

        private void OpenImagePopup(FileDataSo data)
        {
            if (_activePopups.ContainsKey(data.fileName)) return;
            
            var popup = Instantiate(imagePopupPrefab, popupParent);
            var imagePopup = popup.GetComponent<ImagePopup>();
            imagePopup.Initialize(data.title, data.image);

            _activePopups[data.fileName] = popup;

            imagePopup.OnClose += () => _activePopups.Remove(data.fileName);
        }

        private void OpenTextPopup(FileDataSo data)
        {
            if (_activePopups.ContainsKey(data.fileName)) return;
            
            var popup = Instantiate(textPopupPrefab, popupParent);
            var messagePopup = popup.GetComponent<MessagePopup>();
            messagePopup.Initialize(data.headerText, data.textTitle, data.content);
            
            _activePopups[data.fileName] = popup;
            
            messagePopup.OnClose += () => _activePopups.Remove(data.fileName);
        }

        public void OpenAdPopup(FileDataSo data)
        {
            if (_activePopups.ContainsKey(data.fileName)) return;
            
            var popup = Instantiate(adPopupPrefab, popupParent);
            
            var adPopup = popup.GetComponent<AdPopup>();
            adPopup.Initialize(data.title, data.adCount);
            
            _activePopups[data.fileName] = popup;
            
            adPopup.OnClose += () => _activePopups.Remove(data.fileName);
        }
    }
}