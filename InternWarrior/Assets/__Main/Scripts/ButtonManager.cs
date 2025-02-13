using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("�Ͻ����� ��ư")]
    public Button stopButton;

    // --------------------------------------------------

    [Header("������ �˾�")]
    public GameObject popupPrefab;

    [Header("�˾� �ݱ� ��ư")]
    public Button closeButton;

    [Header("����ϱ� ��ư")]
    public Button continueButton;

    [Header("���� �����")]
    public Button restartButton;

    [Header("��������")]
    public Button goToMainButton;

    // --------------------------------------------------

    [Header("��� ����ϱ� ��ư")]
    public Button Dead_ContinueButton;

    [Header("��� ���� �����")]
    public Button Dead_RestartButton;

    [Header("��� ��������")]
    public Button Dead_GoToMainButton;

    private void Start()
    {
        // �Ͻ����� ��ư
        stopButton.onClick.AddListener(() => 
        {
            // ȿ����
            SoundController.PlaySFXSound("pause");

            // ���� �ð� ���߱�
            Time.timeScale = 0;

            // �˾� ����
            AppearPopup(true);
        });

        // �˾� �ݱ� ��ư
        closeButton.onClick.AddListener(() => 
        {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");

            // ���� �ð� �ٽ� �帣��
            Time.timeScale = 1;

            // �˾� �ݱ�
            AppearPopup(false);
        });

        // ����ϱ� ��ư
        continueButton.onClick.AddListener(() =>
        {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");

            // ���� �ð� �ٽ� �帣��
            Time.timeScale = 1;

            // �˾� �ݱ�
            AppearPopup(false);
        });

        // ���� ����� ��ư
        restartButton.onClick.AddListener(() =>
        {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");

            // ���� �ð� �ٽ� �帣��
            Time.timeScale = 1;

            // ���� ���� �̸� ��������
            string currentSceneName = SceneManager.GetActiveScene().name;

            // ���� �� �ε��Ͽ� ����� (Ʈ�� ����)
            DOTween.KillAll();
            SceneManager.LoadScene(currentSceneName);
        });

        // ��������
        goToMainButton.onClick.AddListener(() =>
        {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");

            // ���� �ð� �ٽ� �帣��
            Time.timeScale = 1;

            // ���� ������ �̵� (Ʈ�� ����)
            DOTween.KillAll();
            SceneManager.LoadScene("0 Title");
        });

        // --------------------------------------------------

        // ��� ����ϱ� ��ư
        Dead_ContinueButton.onClick.AddListener(() =>
        {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");

            // ���� ���� �̸� ��������
            string currentSceneName = SceneManager.GetActiveScene().name;

            // ���� �� �ε��Ͽ� ����� (Ʈ�� ����)
            DOTween.KillAll();
            SceneManager.LoadScene(currentSceneName);
        });

        // ��� ���� ����� ��ư
        Dead_RestartButton.onClick.AddListener(() =>
        {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");

            // ���� �� �ε��Ͽ� ����� (Ʈ�� ����)
            DOTween.KillAll();
            SceneManager.LoadScene("1 Play");
        });

        // ��������
        Dead_GoToMainButton.onClick.AddListener(() =>
        {
            // ȿ����
            SoundController.PlaySFXSound("ui-button");

            // ���� ������ �̵� (Ʈ�� ����)
            DOTween.KillAll();
            SceneManager.LoadScene("0 Title");
        });
    }

    /// <summary>
    /// �˾��� ���ݴ� �Լ�
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
