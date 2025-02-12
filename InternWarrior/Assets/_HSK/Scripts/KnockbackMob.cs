using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackMob : MonoBehaviour
{
    public float knockbackForce = 50f; // �о�� ��
    public float disableMovementTIme = 0.5f; // �̵� ���� �ð�

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
