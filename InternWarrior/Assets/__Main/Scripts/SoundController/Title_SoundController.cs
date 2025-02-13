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

    // 게임 시작 버튼
    public Button button_GameStart;

    private void Start() {
        button_GameEnd.onClick.AddListener(() => {
            // 효과음
            SoundController.PlaySFXSound("ui-button");
        });

        button_mute.onClick.AddListener(() => {
            // 효과음
            SoundController.PlaySFXSound("ui-button");
        });

        button_GameStart.onClick.AddListener(() => {
            // 효과음
            SoundController.PlaySFXSound("ui-button");
        });
    }
}
