using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackMob : MonoBehaviour
{
    public float knockbackForce = 5f; // �о�� ��

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                playerRb.velocity = Vector2.zero; // ���� �÷��̾� �ӵ� 0���� �ʱ�ȭ
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
