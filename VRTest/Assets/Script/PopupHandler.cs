using UnityEngine;

public class PopupHandler : MonoBehaviour
{
    // 팝업 창을 연결하기 위한 변수
    public GameObject popup;

    // 팝업을 활성화하는 함수
    public void ShowPopup()
    {
        if (popup != null)
        {
            popup.SetActive(true); // 팝업 활성화
            Debug.Log("Activated popup: " + popup.name);
        }
        else
        {
            Debug.LogWarning("No popup assigned to this object!");
        }
    }

    // 팝업을 비활성화하는 함수 (필요 시 사용)
    public void HidePopup()
    {
        if (popup != null)
        {
            popup.SetActive(false); // 팝업 비활성화
            Debug.Log("Deactivated popup: " + popup.name);
        }
    }

    public bool IsPopupActive()
    {
        return popup != null && popup.activeSelf;
    }
}