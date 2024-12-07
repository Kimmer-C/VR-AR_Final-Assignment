
using UnityEngine;

public class Closepopup : MonoBehaviour
{
    public Transform controller;
    public GameObject popup_1;
    public GameObject popup_2; 
    public GameObject popup_3; 
    public GameObject popup_4; 
    public GameObject popup_5; 
     // VR 컨트롤러 (OVR 컨트롤러의 Transform)

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
                bool isActive = popup_1.activeSelf;
                
                // 충돌한 물체를 비활성화
                popup_1.SetActive(!isActive);
                popup_2.SetActive(!isActive);
                popup_3.SetActive(!isActive);
                popup_4.SetActive(!isActive);
                popup_5.SetActive(!isActive);
                
            }
            else {
                Debug.Log("no");
            }
        }
    }
}