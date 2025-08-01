using _00.Work.WorkSpace.CheolYee._02._Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts
{
    public class FileItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI fileName;
        [SerializeField] private FileDataSo fileData;

        private CanvasGroup _canvasGroup;
        private RectTransform _rectTransform;
        private Transform _originalParent;
        private Vector2 _originalPosition;

        private bool _isDragging;
        private Vector2 _dragStartPos;

        private float _lastClickTime;
        private const float DoubleClickThreshold = 0.25f; // 초 단위

        private GameObject _folderPanel;
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _rectTransform = GetComponent<RectTransform>();
            Initialize();
        }

        public void Initialize()
        {
            image.sprite = fileData.icon;
            fileName.text = fileData.fileName;
        }

        public void Initialize(FileDataSo data)
        {
            fileData = data;
            image.sprite = fileData.icon;
            fileName.text = fileData.fileName;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _dragStartPos = eventData.position;
            _isDragging = false;

            _originalParent = transform.parent;
            _originalPosition = _rectTransform.anchoredPosition;

            _canvasGroup.blocksRaycasts = false;
            transform.SetParent(transform.root);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_isDragging && Vector2.Distance(_dragStartPos, eventData.position) > 10f)
            {
                _isDragging = true;
            }

            if (_isDragging)
            {
                _rectTransform.anchoredPosition += eventData.delta / transform.lossyScale.x;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            transform.SetParent(_originalParent);

            if (_isDragging)
            {
                _rectTransform.anchoredPosition = _originalPosition;
            }

            _isDragging = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_isDragging) return;

            float timeSinceLastClick = Time.time - _lastClickTime;
            _lastClickTime = Time.time;

            if (timeSinceLastClick <= DoubleClickThreshold)
            {
                HandleDoubleClick();
            }
        }

        private void HandleDoubleClick()
        {
            if (fileData.type == FileType.Folder)
            {
                Debug.Log($"[열기] 폴더 열기: {fileName.text}");
                // 폴더 열기 이벤트 호출
                OpenFolder();
            }
            else
            {
                PopUpManager.Instance.OpenPopup(fileData);
            }
        }

        private void OpenFolder()
        {
            FolderManager.Instance.CreatePanel(fileData);
        }

        public void DeleteSelf()
        {
            if (fileData.type == FileType.Folder) return;
            
            FileEventManager.HandleTrigger(fileData);
            Destroy(gameObject);
        }
    }
}
