using System;
using TMPro;
using UnityEngine;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts.Popup
{
    public class MessagePopup : MonoBehaviour
    {
        public event Action OnClose;
        
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI contentText;
        [SerializeField] private TextMeshProUGUI headerText;

        public void Initialize(string header, string title, string content)
        {
            headerText.text = header;
            titleText.text = title;
            contentText.text = content;
        }
        
        public void Close()
        {
            OnClose?.Invoke();
            Destroy(gameObject);
        }
    }
}