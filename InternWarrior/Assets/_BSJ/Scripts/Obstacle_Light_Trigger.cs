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
        rb.gravityScale = 0;  // �ʱ⿡�� �߷��� 0���� ����
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.gravityScale = 1;  // �÷��̾�� �浹 �� �߷��� 1�� �����Ͽ� �������� ��
        }
    }
}
