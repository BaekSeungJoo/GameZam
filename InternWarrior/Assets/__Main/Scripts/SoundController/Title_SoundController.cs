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

    // ���� ���� ��ư
    public Button button_GameStart;

    private void Start() {
        button_GameEnd.onClick.AddListener(() => {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");
        });

        button_mute.onClick.AddListener(() => {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");
        });

        button_GameStart.onClick.AddListener(() => {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");
        });
    }
}
