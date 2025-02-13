using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingSceneManager : MonoBehaviour
{
    [Header("Ŭ���� ��������")]
    public Button Clear_GoToMainButton;

    private void Start()
    {
        // ��������
        Clear_GoToMainButton.onClick.AddListener(() =>
        {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");

            // ���� ������ �̵� (Ʈ�� ����)
            DOTween.KillAll();
            SceneManager.LoadScene("0 Title");
        });
    }
}
