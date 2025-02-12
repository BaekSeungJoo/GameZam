using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Obstacle_Light_Trigger : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = transform.parent.GetChild(0).GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0;  // 초기에는 중력을 0으로 설정
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.gravityScale = 1;  // 플레이어와 충돌 시 중력을 1로 설정하여 떨어지게 함
        }
    }
}
