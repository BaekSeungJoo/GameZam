using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("일시정지 버튼")]
    public Button stopButton;

    // --------------------------------------------------

    [Header("관리할 팝업")]
    public GameObject popupPrefab;

    [Header("팝업 닫기 버튼")]
    public Button closeButton;

    [Header("계속하기 버튼")]
    public Button continueButton;

    [Header("게임 재시작")]
    public Button restartButton;

    [Header("메인으로")]
    public Button goToMainButton;

    private void Start()
    {
        // 일시정지 버튼
        stopButton.onClick.AddListener(() => 
        {
            // 효과음
            SoundController.PlaySFXSound("pause");

            // 게임 시간 멈추기
            Time.timeScale = 0;

            // 팝업 열기
            AppearPopup(true);
        });

        // 팝업 닫기 버튼
        closeButton.onClick.AddListener(() => 
        {
            // 효과음
            SoundController.PlaySFXSound("ui-button");

            // 게임 시간 다시 흐르게
            Time.timeScale = 1;

            // 팝업 닫기
            AppearPopup(false);
        });

        // 계속하기 버튼
        continueButton.onClick.AddListener(() =>
        {
            // 효과음
            SoundController.PlaySFXSound("ui-button");

            // 게임 시간 다시 흐르게
            Time.timeScale = 1;

            // 팝업 닫기
            AppearPopup(false);
        });

        // 게임 재시작 버튼
        restartButton.onClick.AddListener(() =>
        {
            // 효과음
            SoundController.PlaySFXSound("ui-button");

            // 게임 시간 다시 흐르게
            Time.timeScale = 1;

            // 현재 씬의 이름 가져오기
            string currentSceneName = SceneManager.GetActiveScene().name;

            // 현재 씬 로드하여 재시작 (트윈 제거)
            DOTween.KillAll();
            SceneManager.LoadScene(currentSceneName);
        });

        // 메인으로
        goToMainButton.onClick.AddListener(() =>
        {
            // 효과음
            SoundController.PlaySFXSound("ui-button");

            // 게임 시간 다시 흐르게
            Time.timeScale = 1;

            // 메인 씬으로 이동 (트윈 제거)
            DOTween.KillAll();
            SceneManager.LoadScene("0 Title");
        });
    }

    /// <summary>
    /// 팝업을 여닫는 함수
    /// </summary>
    /// <param name="OpenOrClose"></param>
    public void AppearPopup(bool OpenOrClose)
    {
        if (OpenOrClose)
        {
            popupPrefab.SetActive(true);
        }

        else
        {
            popupPrefab.SetActive(false);
        }
    }
}
