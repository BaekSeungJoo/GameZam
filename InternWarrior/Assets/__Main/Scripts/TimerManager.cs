using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [Header("���� �Ŵ��� ����")]
    public GameManager gameManager;

    [Header("���� �ð� (5��)")]
    public float gameTime = 300f;

    [Header("���� �ð�")]
    public float currentTime = 0f;

    [Header("���� �ð� ��� �ؽ�Ʈ")]
    public TextMeshProUGUI timerText;

    [Header("�ʱ� �ؽ�Ʈ ����")]
    public Color initialColor = Color.black;

    [Header("1�� ������ �� �ؽ�Ʈ ����")]
    public Color warningColor = Color.red;

    private void Start()
    {
        currentTime = gameTime;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // ���� �ð��� 1�� ������ �� �ؽ�Ʈ ���� ����
            if (currentTime <= 60)
            {
                timerText.color = Color.red;
            }

            yield return null;
        }

        // �ð��� 0�� �Ǿ��� ��, ���� ����
        gameManager.MoveScene_GameEnd();
        timerText.text = "00:00";
    }
}
