using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackMob : MonoBehaviour
{
    public float knockbackForce = 5f; // 밀어내는 힘

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
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
