using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_SoundController : MonoBehaviour
{
    // 게임 종료 버튼
    public Button button_GameEnd;

    // 게임 음소거 버튼
    public Button button_mute;

    // 버튼 아이콘 오브젝트
    public GameObject button_icon_01;
    public GameObject button_icon_02;

    private bool isMuted = false; // 음소거 상태 변수
    private SoundManager soundManager; 

    // 게임 시작 버튼
    public Button button_GameStart;

    private void Start() {
        // SoundManager를 찾아서 캐싱
        soundManager = FindObjectOfType<SoundManager>();

        button_GameEnd.onClick.AddListener(() => {
            // 효과음
            SoundController.PlaySFXSound("ui-button");
            GameEnd();
        });

        button_mute.onClick.AddListener(() => {
            // 효과음
            SoundController.PlaySFXSound("ui-button");
            ToggleMute();
        });

        button_GameStart.onClick.AddListener(() => {
            // 효과음
            SoundController.PlaySFXSound("ui-button");
        });
    }

    private void GameEnd()
    {
        #if UNITY_EDITOR
        // 유니티 에디터에서는 플레이 모드를 종료합니다.
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // 빌드된 게임에서는 애플리케이션을 종료합니다.
        Application.Quit();
        #endif
    }

    private void ToggleMute()
    {
        isMuted = !isMuted;

        // SoundManager의 음소거 기능 호출
        if (soundManager != null)
        {
            soundManager.ToggleTotalMute(isMuted);
        }

        // 버튼 아이콘 번갈아 활성화/비활성화
        UpdateButtonIcons();
    }

    private void UpdateButtonIcons()
    {
        button_icon_01.SetActive(!isMuted);
        button_icon_02.SetActive(isMuted);
    }
}
