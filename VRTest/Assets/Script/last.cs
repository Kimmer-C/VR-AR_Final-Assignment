using UnityEngine;

public class Closepopup__ : MonoBehaviour
{
    public Transform controller; // VR 컨트롤러 Transform
    [SerializeField]
    private GameObject[] popups;  // 관리할 팝업 오브젝트 배열
    [SerializeField]
    private GameObject[] objects; // 팝업을 트리거하는 물체 배열

    void Update()
    {
        // 트리거 버튼 입력 감지 (오른손 컨트롤러의 Primary Index Trigger)
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            // 컨트롤러 위치에서 Ray 발사
            Ray ray = new Ray(controller.position, controller.forward);
            RaycastHit hit;

            // Raycast로 충돌 감지
            if (Physics.Raycast(ray, out hit, 10.0f)) // Ray 길이: 10미터
            {
                Debug.Log($"Ray가 감지한 물체: {hit.collider.name}");

                // 충돌한 물체와 연결된 팝업 활성화/비활성화
                for (int i = 0; i < objects.Length; i++)
                {
                    if (hit.collider.gameObject == objects[i])
                    {
                        if (i == 5 || i == 6)
                        {
                            // i가 5 또는 6일 때, 해당 물체를 비활성화
                            popups[i].SetActive(false);
                            Debug.Log($"{objects[i].name} 비활성화됨.");
                        }
                        else
                        {
                            // 팝업 활성화/비활성화
                            TogglePopup(popups[i]);
                        } // 해당 팝업 활성화/비활성화
                    }
                    else
                    {
                        // i가 5 또는 6이 아니면 팝업 비활성화
                        if (i != 5 && i != 6)
                        {
                            popups[i].SetActive(false);
                        }
                    }
                }
            }
            else
            {
                Debug.Log("Ray가 아무것도 감지하지 못했습니다.");
            }
        }
    }

    void TogglePopup(GameObject popup)
    {
        if (popup != null)
        {
            bool isActive = popup.activeSelf;
            popup.SetActive(!isActive);

            Debug.Log($"{popup.name} {(isActive ? "비활성화" : "활성화")}");
        }
    }
}
