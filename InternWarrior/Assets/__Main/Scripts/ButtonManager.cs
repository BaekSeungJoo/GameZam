using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        // �Ͻ����� ��ư
        stopButton.onClick.AddListener(() => 
        {
            // ���� �ð� ���߱�
            Time.timeScale = 0;

            // �˾� ����
            AppearPopup(true);
        });

        // �˾� �ݱ� ��ư
        closeButton.onClick.AddListener(() => 
        {
            // ���� �ð� �ٽ� �帣��
            Time.timeScale = 1;

            // �˾� �ݱ�
            AppearPopup(false);
        });

        // ����ϱ� ��ư
        continueButton.onClick.AddListener(() =>
        {
            // ���� �ð� �ٽ� �帣��
            Time.timeScale = 1;

            // �˾� �ݱ�
            AppearPopup(false);
        });

        // ���� ����� ��ư
        restartButton.onClick.AddListener(() =>
        {
            // ���� �ð� �ٽ� �帣��
            Time.timeScale = 1;

            // ���� ���� �̸� ��������
            string currentSceneName = SceneManager.GetActiveScene().name;

            // ���� �� �ε��Ͽ� �����
            SceneManager.LoadScene(currentSceneName);
        });

        // ��������
        goToMainButton.onClick.AddListener(() =>
        {
            // ���� �ð� �ٽ� �帣��
            Time.timeScale = 1;

            // ���� ������ �̵�
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
