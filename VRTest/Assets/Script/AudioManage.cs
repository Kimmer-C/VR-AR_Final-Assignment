using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;  // 오디오 소스
    public AudioClip music1;         // 음악 1
    public AudioClip music2;         // 음악 2

    public AudioClip music3;

    public GameObject popupObject;   // 팝업 오브젝트 안내판
    public GameObject popupObject2; // 얘는 문

    private bool isPopupActive = false; // 팝업 활성화 상태 추적
    private bool isPopupActive2 = true; // 팝업 활성화 상태 추적

    void Start()
    {
        // AudioSource 자동 설정
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
            {
                Debug.LogError("AudioSource 컴포넌트가 없습니다. 게임 오브젝트에 AudioSource를 추가하세요!");
                return;
            }
        }

        // 초기 음악 재생
        PlayMusic(music1);
    }

    void Update()
    {
        // 팝업 오브젝트의 활성화 상태 감지
        if (popupObject != null && popupObject.activeSelf && !isPopupActive)
        {
            Debug.Log("팝업 활성화 감지. 음악 전환 중...");
            isPopupActive = true; // 상태 업데이트
            PlayMusic(music2);    // 음악 전환
        }
        else if (popupObject != null && !popupObject.activeSelf && isPopupActive)
        {
            Debug.Log("팝업 비활성화 감지. 초기 음악 재생...");
            isPopupActive = false; // 상태 업데이트
            PlayMusic(music1);     // 초기 음악 재생
        }

        else if(popupObject2 != null && !popupObject2.activeSelf && isPopupActive2)
        {

            Debug.Log("팝업 활성화 감지. 음악 전환 중...");
            isPopupActive2 = false; // 상태 업데이트
            PlayMusic(music3);    // 음악 전환
        }
    }


    void PlayMusic(AudioClip musicClip)
    {
        if (audioSource == null || musicClip == null) return;

        audioSource.Stop();
        audioSource.clip = musicClip;
        audioSource.Play();
    }
}
