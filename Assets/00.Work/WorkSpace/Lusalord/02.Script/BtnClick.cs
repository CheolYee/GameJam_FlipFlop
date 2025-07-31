using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _00.Work.WorkSpace.Lusalord._02.Script
{
    public class BtnClick : MonoBehaviour
    {
        [SerializeField] private GameObject popupUI; // 활성화 될 UI
        
        [SerializeField] private Button btn; //눌렀을 때 팝업이 활성화 되게 만들어주는 버튼 UI
        private bool _isPopup = false; // 현재 팝업이 열려 있는지 여부를 체크하는 Bool 변수

        List<RaycastResult> raycastResult = new List<RaycastResult>(); // 마우스 위치를 담는 Raycast
        private void Start()
        {
            popupUI.SetActive(false); //시작할 때에는 팝업을 꺼주고 시작함
            
            btn.onClick.AddListener(TogglePopupUI); //버튼에 클릭 이벤트 리스너를 연결
        }

        private void Update()
        {
            // 팝업이 켜져있는 상태에서 마우스 왼쪽 클릭을 할 경우,
            if (_isPopup && Input.GetMouseButtonDown(0))
            {
                // 클릭한 위치가 팝업 UI가 아니면 팝업 비활성화
                if (!IsPopupUiOverUIObject())
                {
                    HidePopup();
                }
            }
        }
        
        // 팝업을 열거나 닫는 함수
        private void TogglePopupUI()
        {
            _isPopup = !_isPopup; 
            popupUI.SetActive(_isPopup);
        }

        // 팝업을 닫음
        private void HidePopup()
        {
            _isPopup = false;
            popupUI.SetActive(false);
        }
        
        //현재 마우스 포인터가 UI 위에 있는지 검사함
        private bool IsPopupUiOverUIObject()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            
            
            raycastResult.Clear();
            EventSystem.current.RaycastAll(eventData, raycastResult);

            foreach (var result in raycastResult)
            {
                if (result.gameObject == popupUI || result.gameObject == btn.gameObject ||
                    popupUI.transform.IsChildOf(result.gameObject.transform))
                {
                    return true;
                }
            }
            return false;
            
        }

    }
}
