using UnityEngine;
using UnityEngine.UI;

public class DoorLockVR : MonoBehaviour
{
    public string correctPassword = "1234"; // 정답 비밀번호

    // UI 요소
    public Text resultText;
    public GameObject popupUI; // 비밀번호 입력 팝업 UI
    public InputField inputField; // 비밀번호 입력 필드

    // 문 오브젝트와 애니메이터
    public GameObject door;
    public Animator doorAnimator;

    // 오디오 요소
    public AudioSource audioSource;
    public AudioClip buttonClickClip; // 버튼 클릭 소리
    public AudioClip correctClip;    // 정답 소리
    public AudioClip wrongClip;      // 오답 소리
    public AudioClip exitMusicClip; // 문 열림 음악

    private string userInput = ""; // 입력된 비밀번호
    private bool isDoorOpen = false; // 문 상태
    private bool isPopupActive = false; // 팝업 상태

    void Start()
    {
        // 팝업 UI 초기 상태 비활성화
        if (popupUI != null) popupUI.SetActive(false);
        if (resultText != null) resultText.text = "";
    }

    public void OnDoorClick()
    {
        if (isDoorOpen) return; // 문이 이미 열렸다면 팝업 표시하지 않음

        // 팝업 활성화
        if (popupUI != null)
        {
            popupUI.SetActive(true);
            isPopupActive = true;
        }
    }

    public void OnButtonClick(string number)
    {
        if (isDoorOpen || !isPopupActive) return;

        // 버튼 클릭 소리 재생
        if (audioSource != null && buttonClickClip != null)
            audioSource.PlayOneShot(buttonClickClip);

        // 입력된 숫자 추가
        userInput += number;

        // 입력된 숫자가 정답 길이에 도달했는지 확인
        if (userInput.Length == correctPassword.Length)
        {
            OnPasswordSubmit();
        }
    }

    public void OnPasswordSubmit()
    {
        if (!isPopupActive) return;

        // 비밀번호 확인
        if (userInput == correctPassword)
        {
            UnlockDoor();
            PlayCorrectSound();
        }
        else
        {
            PlayWrongSound();
            if (resultText != null)
                resultText.text = "비밀번호가 틀렸습니다!";
        }

        // 팝업 닫기 및 초기화
        if (popupUI != null) popupUI.SetActive(false);
        isPopupActive = false;
        userInput = ""; // 입력 초기화
        inputField.text = ""; // InputField 초기화
    }

    private void UnlockDoor()
    {
        if (isDoorOpen) return;

        isDoorOpen = true;

        // 문 열림 애니메이션
        if (doorAnimator != null)
            doorAnimator.SetTrigger("Open");

        if (resultText != null)
            resultText.text = "문이 열렸습니다!";

        PlayExitMusic();
    }

    private void PlayCorrectSound()
    {
        if (audioSource != null && correctClip != null)
            audioSource.PlayOneShot(correctClip);
    }

    private void PlayWrongSound()
    {
        if (audioSource != null && wrongClip != null)
            audioSource.PlayOneShot(wrongClip);
    }

    private void PlayExitMusic()
    {
        if (audioSource != null && exitMusicClip != null)
        {
            audioSource.clip = exitMusicClip;
            audioSource.Play();
        }
    }
}
