using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingSceneManager : MonoBehaviour
{
    [Header("클리어 메인으로")]
    public Button Clear_GoToMainButton;

    private void Start()
    {
        // 메인으로
        Clear_GoToMainButton.onClick.AddListener(() =>
        {
            // 효과음
            SoundController.PlaySFXSound("ui-button");

            // 메인 씬으로 이동 (트윈 제거)
            DOTween.KillAll();
            SceneManager.LoadScene("0 Title");
        });
    }
}
