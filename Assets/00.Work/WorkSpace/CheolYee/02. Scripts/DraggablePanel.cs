using UnityEngine;
using UnityEngine.EventSystems;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts
{
    public class DraggablePanel : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        private RectTransform _rectTransform;
        private Canvas _canvas;
        private Vector2 _offset;

        private void Awake()
        {
            _rectTransform = transform.parent.GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _rectTransform, eventData.position, eventData.pressEventCamera, out _offset);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out var localPoint))
            {
                _rectTransform.anchoredPosition = localPoint - _offset;
            }
        }
    }
}