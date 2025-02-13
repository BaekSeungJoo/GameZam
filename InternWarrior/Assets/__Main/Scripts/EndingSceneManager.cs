using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingSceneManager : MonoBehaviour
{
    [Header("���� ���� ��ư")]
    public Button gameQuitButton;

    [Header("�������� ��ư")]
    public Button goToMainButton;

    private void Start()
    {
        // ���� ���� ��ư
        gameQuitButton.onClick.AddListener(() => 
        {
            DOTween.KillAll();
            Application.Quit();
        });

        // �������� ��ư
        goToMainButton.onClick.AddListener(() => 
        {
            DOTween.KillAll();
            SceneManager.LoadScene("0 Title");
        });
    }
}
