using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MovingPlatform : MonoBehaviour
{
    
    public enum MovementType { Horizontal, Vertical } // �÷��� �̵� ���

    [Header("����")]
    public MovementType movementType = MovementType.Horizontal;

    [Header("�̵��ӵ�")]
    public float speed = 2f; // �÷��� �⺻ �̵� �ӵ�
    [Header("�̵��Ÿ�")]
    public float moveDistance = 3f; // �̵� ����


    private Vector2 startPos;
    private int direction = 1; // �̵� ���� (-1�̸� �ݴ� ����)
    private Rigidbody2D rb;
    private Rigidbody2D playerRb; // �÷��̾� Rigidbody2D
    private bool isPlayerOnPlatform = false; // �÷��̾ �÷��� ���� �ִ��� Ȯ��


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rb.bodyType = RigidbodyType2D.Kinematic; // �߷� ���� X
    }

    private void FixedUpdate()
    {
        float traveled = movementType == MovementType.Horizontal ?
            transform.position.x - startPos.x : transform.position.y - startPos.y;

        if (Mathf.Abs(traveled) >= moveDistance)
        {
            direction *= -1; // ���� ����
        }

        Vector2 platformVelocity = movementType == MovementType.Horizontal ?
            new Vector2(direction * speed, rb.velocity.y) :
            new Vector2(rb.velocity.x, direction * speed);

        rb.velocity = platformVelocity;

        if (isPlayerOnPlatform && playerRb != null)
        {
            if (movementType == MovementType.Horizontal)
                AdjustPlayerVelocity(platformVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            collision.transform.SetParent(transform); // �÷��̾ �÷����� �ڽ����� ����
            isPlayerOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            isPlayerOnPlatform = false;
            playerRb = null;
        }
    }

    private void AdjustPlayerVelocity(Vector2 platformVelocity)
    {
        if (playerRb == null) return;

        float playerInput = Input.GetAxisRaw("Horizontal"); // �÷��̾� �Է� ��������
        float playerSpeed = GameObject.Find("PlayerManager").GetComponent<PlayerManager>().GetPlayerSpeed(); // �⺻ �÷��̾� �ӵ� (�÷��̾� �ڵ忡 �°� ���� ����)

        // �÷��� �ӵ��� �����Ͽ� �÷��̾� �̵��� �ڿ������� ����
        float adjustedSpeed = (playerInput * playerSpeed) + platformVelocity.x;
        playerRb.velocity = new Vector2(adjustedSpeed, playerRb.velocity.y);
    }
}
