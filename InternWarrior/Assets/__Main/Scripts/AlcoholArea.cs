using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholArea : MonoBehaviour
{
    public int AlchholAmount = 1; // 획득량
    public float stayTime = 10f; // 필요한 스테이 시간
    private float currentStayTime = 0f; // 현재 스테이 시간

    PlayerManager manager;

    bool isHit = false;
    bool isStaying = false;

    private void Start()
    {
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어와 충돌했다면
        {
            isStaying = true;
            currentStayTime += Time.deltaTime;

            if (currentStayTime >= stayTime)
            {
                // 스테이 시간이 10초를 넘으면 초 초기화
                currentStayTime = 0f;

                // 알코올 획득하는 로직
                if (manager != null)
                {
                    manager.GetAlcohol(AlchholAmount);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어가 트리거를 나갔다면
        {
            isStaying = false;
            currentStayTime = 0f; // 트리거를 나가면 시간을 초기화
        }
    }
}
