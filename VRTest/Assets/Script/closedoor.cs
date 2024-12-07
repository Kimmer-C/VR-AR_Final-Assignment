
using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    public Transform controller;
    public GameObject popup_1; // VR 컨트롤러 (OVR 컨트롤러의 Transform)

    void closePopup()
    {
        // 트리거 버튼 입력 감지 (오른손 컨트롤러의 Primary Index Trigger)
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            // 컨트롤러 위치에서 Ray를 발사
            Ray ray = new Ray(controller.position, controller.forward);
            RaycastHit hit;

            // Raycast로 충돌 감지
            if (Physics.Raycast(ray, out hit, 10.0f)) // Ray 길이: 10미터
            {
                // 충돌한 물체를 비활성화
                popup_1.SetActive(false);
                
            }
            else {
                Debug.Log("no");
            }
        }
    }
}