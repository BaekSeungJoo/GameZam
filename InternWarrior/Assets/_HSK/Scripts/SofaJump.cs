using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaJump : MonoBehaviour
{
    public float jumpMultiplier = 2.0f; //���� ���

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾�� �浹��
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            PlayerMove playerMove = other.GetComponent<PlayerMove>();

            if (playerRb != null && playerMove != null)
            {
                float jumpForce = playerMove.jumpScale; // ���� ������ ��������
                playerRb.velocity = new Vector2(playerRb.velocity.x, 0); //���� �����ӵ� �ʱ�ȭ
                playerRb.AddForce(Vector2.up * jumpForce * jumpMultiplier, ForceMode2D.Impulse);

                Debug.Log("��������!"); 

            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
