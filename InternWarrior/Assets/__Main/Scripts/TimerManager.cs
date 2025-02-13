using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [Header("게임 매니저 참조")]
    public GameManager gameManager;

    [Header("제한 시간 (5분)")]
    public float gameTime = 300f;

    [Header("현재 시간")]
    public float currentTime = 0f;

    [Header("제한 시간 출력 텍스트")]
    public TextMeshProUGUI timerText;

    [Header("초기 텍스트 색상")]
    public Color initialColor = Color.black;

    [Header("1분 남았을 때 텍스트 색상")]
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

            // 남은 시간이 1분 이하일 때 텍스트 색상 변경
            if (currentTime <= 60)
            {
                timerText.color = Color.red;
            }

            yield return null;
        }

        // 시간이 0이 되었을 때, 게임 엔드
        gameManager.MoveScene_GameEnd();
        timerText.text = "00:00";
    }
}
