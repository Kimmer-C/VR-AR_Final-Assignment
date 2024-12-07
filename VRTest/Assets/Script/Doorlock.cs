using UnityEngine;
using UnityEngine.UI;

public class DoorLockVR : MonoBehaviour
{
    public string correctPassword = "1234"; // ���� ��й�ȣ

    // UI ���
    public Text resultText;
    public GameObject popupUI; // ��й�ȣ �Է� �˾� UI
    public InputField inputField; // ��й�ȣ �Է� �ʵ�

    // �� ������Ʈ�� �ִϸ�����
    public GameObject door;
    public Animator doorAnimator;

    // ����� ���
    public AudioSource audioSource;
    public AudioClip buttonClickClip; // ��ư Ŭ�� �Ҹ�
    public AudioClip correctClip;    // ���� �Ҹ�
    public AudioClip wrongClip;      // ���� �Ҹ�
    public AudioClip exitMusicClip; // �� ���� ����

    private string userInput = ""; // �Էµ� ��й�ȣ
    private bool isDoorOpen = false; // �� ����
    private bool isPopupActive = false; // �˾� ����

    void Start()
    {
        // �˾� UI �ʱ� ���� ��Ȱ��ȭ
        if (popupUI != null) popupUI.SetActive(false);
        if (resultText != null) resultText.text = "";
    }

    public void OnDoorClick()
    {
        if (isDoorOpen) return; // ���� �̹� ���ȴٸ� �˾� ǥ������ ����

        // �˾� Ȱ��ȭ
        if (popupUI != null)
        {
            popupUI.SetActive(true);
            isPopupActive = true;
        }
    }

    public void OnButtonClick(string number)
    {
        if (isDoorOpen || !isPopupActive) return;

        // ��ư Ŭ�� �Ҹ� ���
        if (audioSource != null && buttonClickClip != null)
            audioSource.PlayOneShot(buttonClickClip);

        // �Էµ� ���� �߰�
        userInput += number;

        // �Էµ� ���ڰ� ���� ���̿� �����ߴ��� Ȯ��
        if (userInput.Length == correctPassword.Length)
        {
            OnPasswordSubmit();
        }
    }

    public void OnPasswordSubmit()
    {
        if (!isPopupActive) return;

        // ��й�ȣ Ȯ��
        if (userInput == correctPassword)
        {
            UnlockDoor();
            PlayCorrectSound();
        }
        else
        {
            PlayWrongSound();
            if (resultText != null)
                resultText.text = "��й�ȣ�� Ʋ�Ƚ��ϴ�!";
        }

        // �˾� �ݱ� �� �ʱ�ȭ
        if (popupUI != null) popupUI.SetActive(false);
        isPopupActive = false;
        userInput = ""; // �Է� �ʱ�ȭ
        inputField.text = ""; // InputField �ʱ�ȭ
    }

    private void UnlockDoor()
    {
        if (isDoorOpen) return;

        isDoorOpen = true;

        // �� ���� �ִϸ��̼�
        if (doorAnimator != null)
            doorAnimator.SetTrigger("Open");

        if (resultText != null)
            resultText.text = "���� ���Ƚ��ϴ�!";

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
