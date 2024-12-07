using UnityEngine;

public class ObjectPopupManager : MonoBehaviour
{
    public GameObject popup; // 해당 물체와 연결된 팝업 오브젝트

    private void Start()
    {
        if (popup != null)
        {
            popup.SetActive(false); // 팝업을 기본적으로 비활성화
        }
    }

    public void TogglePopup()
    {
        if (popup != null)
        {
            // 팝업의 활성화 상태를 반전
            bool isActive = popup.activeSelf;
            popup.SetActive(!isActive);

            if (isActive)
            {
                Debug.Log($"{gameObject.name}의 팝업 비활성화됨: {popup.name}");
            }
            else
            {
                Debug.Log($"{gameObject.name}의 팝업 활성화됨: {popup.name}");
            }
        }
    }
}
