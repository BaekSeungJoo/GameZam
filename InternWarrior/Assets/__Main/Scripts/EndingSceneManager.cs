using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingSceneManager : MonoBehaviour
{
    [Header("게임 종료 버튼")]
    public Button gameQuitButton;

    [Header("메인으로 버튼")]
    public Button goToMainButton;

    private void Start()
    {
        // 게임 종료 버튼
        gameQuitButton.onClick.AddListener(() => 
        {
            DOTween.KillAll();
            Application.Quit();
        });

        // 메인으로 버튼
        goToMainButton.onClick.AddListener(() => 
        {
            DOTween.KillAll();
            SceneManager.LoadScene("0 Title");
        });
    }
}
