using UnityEngine;

public class openPopupManager : MonoBehaviour
{
    public GameObject popup; // 팝업창 Prefab
    

    // 팝업 생성 함수
    public void ShowPopup()
    {
        popup.SetActive(true);
        // 팝업이 이미 떠 있으면 닫기
         // 뒤집힌 방향 보정
    }
}