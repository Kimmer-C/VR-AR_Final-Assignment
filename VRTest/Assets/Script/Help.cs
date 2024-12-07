using UnityEngine;

public class PopupController : MonoBehaviour
{
    public Transform controller; // VR 컨트롤러 Transform
    private float rayLength = 10.0f; // Ray 길이

    void Update()
    {
        // 트리거 버튼 입력 감지 (오른손 컨트롤러의 Primary Index Trigger)
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            // 컨트롤러 위치에서 Ray 발사
            Ray ray = new Ray(controller.position, controller.forward);
            RaycastHit hit;

            // Raycast로 충돌 감지
            if (Physics.Raycast(ray, out hit, rayLength))
            {
                // 충돌한 물체의 ObjectPopupManager 호출
                ObjectPopupManager popupManager = hit.collider.GetComponent<ObjectPopupManager>();

                if (popupManager != null)
                {
                    popupManager.TogglePopup(); // 팝업 열기/닫기
                }
                else
                {
                    Debug.Log("충돌한 오브젝트에 ObjectPopupManager가 없습니다.");
                }
            }
            else
            {
                Debug.Log("Ray가 아무것도 감지하지 못했습니다.");
            }
        }
    }
}
