using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_SoundController : MonoBehaviour
{
    // ���� ���� ��ư
    public Button button_GameEnd;

    // ���� ���Ұ� ��ư
    public Button button_mute;

    // ��ư ������ ������Ʈ
    public GameObject button_icon_01;
    public GameObject button_icon_02;

    private bool isMuted = false; // ���Ұ� ���� ����
    private SoundManager soundManager; 

    // ���� ���� ��ư
    public Button button_GameStart;

    private void Start() {
        // SoundManager�� ã�Ƽ� ĳ��
        soundManager = FindObjectOfType<SoundManager>();

        button_GameEnd.onClick.AddListener(() => {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");
            GameEnd();
        });

        button_mute.onClick.AddListener(() => {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");
            ToggleMute();
        });

        button_GameStart.onClick.AddListener(() => {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");
        });
    }

    private void GameEnd()
    {
        #if UNITY_EDITOR
        // ����Ƽ �����Ϳ����� �÷��� ��带 �����մϴ�.
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // ����� ���ӿ����� ���ø����̼��� �����մϴ�.
        Application.Quit();
        #endif
    }

    private void ToggleMute()
    {
        isMuted = !isMuted;

        // SoundManager�� ���Ұ� ��� ȣ��
        if (soundManager != null)
        {
            soundManager.ToggleTotalMute(isMuted);
        }

        // ��ư ������ ������ Ȱ��ȭ/��Ȱ��ȭ
        UpdateButtonIcons();
    }

    private void UpdateButtonIcons()
    {
        button_icon_01.SetActive(!isMuted);
        button_icon_02.SetActive(isMuted);
    }
}
