using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Alchhol : MonoBehaviour
{
    public int AlchholAmount = 1; // 획득량

    public float speed = 1f; // 속도 변수

    public float objectDestroyTime = 5f;
    public float currentDestroyTime = 0f;

    PlayerManager manager;

    bool isHit = false;

    private void Start()
    {
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    void Update()
    {
        // 오브젝트를 아래 방향으로 이동시키기
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        currentDestroyTime += Time.deltaTime;
        if(currentDestroyTime > objectDestroyTime)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHit) { return; }

        if (other.CompareTag("Player")) // 플레이어와 충돌했다면
        {
            // 한 번만 맞게 수정
            isHit = true;

            // 자동파괴 시간 멈춤
            currentDestroyTime = 0f;

            // 알코올 획득하는 로직
            if (manager != null)
            {
                manager.GetAlcohol(AlchholAmount);
            }

            // 파괴
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

    }
}
