using UnityEngine;

public class MultiPopupHandler : MonoBehaviour
{
    public Transform controller; // VR 컨트롤러의 Transform (예: RightHandAnchor)

    void Update()
    {
        // VR 컨트롤러의 Primary Index Trigger 버튼을 눌렀을 때 동작
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            // 컨트롤러 위치에서 Ray 발사
            Ray ray = new Ray(controller.position, controller.forward);
            RaycastHit hit;

            // Ray가 충돌한 경우 처리
            if (Physics.Raycast(ray, out hit, 10.0f)) // Ray 길이: 10미터
            {
                // 충돌한 물체의 PopupHandler 컴포넌트를 가져옴
                PopupHandler popupHandler = hit.collider.GetComponent<PopupHandler>();

                if (popupHandler != null)
                {
                    if(popupHandler.IsPopupActive()){
                        popupHandler.HidePopup();
                    }
                    else{
                        popupHandler.ShowPopup();
                    }
                    // ShowPopup() 함수 호출로 팝업 활성화
                        
                }
                else
                {
                    Debug.Log("No PopupHandler attached to the hit object.");
                }
            }
        }
    }
}