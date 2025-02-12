using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackMob : MonoBehaviour
{
    public float knockbackForce = 50f; // 밀어내는 힘
    public float disableMovementTIme = 0.5f; // 이동 정지 시간

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();


            Vector3 knockbackDirection;

            if (playerRb != null)
            {
                if (transform.position.y <= other.transform.position.y)
                {
                    knockbackDirection = (other.transform.position - transform.position).normalized;
                }
                else
                {
                    knockbackDirection = (other.transform.position - new Vector3(transform.position.x, other.transform.position.y)).normalized;
                }
                playerRb.velocity = Vector2.zero; // 기존 플레이어 속도 0으로 초기화
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
