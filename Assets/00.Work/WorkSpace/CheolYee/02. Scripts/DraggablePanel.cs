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
            transform.parent.SetAsLastSibling();
            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _rectTransform, eventData.position, eventData.pressEventCamera, out _offset);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out var localPoint))
            {
                Vector2 newAnchoredPos = localPoint - _offset;

                RectTransform canvasRect = _canvas.transform as RectTransform;
                Vector2 panelSize = _rectTransform.sizeDelta;
                if (canvasRect != null)
                {
                    Vector2 canvasSize = canvasRect.rect.size;

                    float clampedX = Mathf.Clamp(newAnchoredPos.x,
                        -canvasSize.x / 2f + panelSize.x / 2f,
                        canvasSize.x / 2f - panelSize.x / 2f);
                    float clampedY = Mathf.Clamp(newAnchoredPos.y,
                        -canvasSize.y / 2f + panelSize.y / 2f + 50f,
                        canvasSize.y / 2f - panelSize.y / 2f - 50f);

                    _rectTransform.anchoredPosition = new Vector2(clampedX, clampedY);
                }
            }
        }
    }
}