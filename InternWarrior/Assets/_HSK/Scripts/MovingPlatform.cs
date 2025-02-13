using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MovingPlatform : MonoBehaviour
{
    
    public enum MovementType { Horizontal, Vertical } // 플랫폼 이동 방식

    [Header("방향")]
    public MovementType movementType = MovementType.Horizontal;

    [Header("이동속도")]
    public float speed = 2f; // 플랫폼 기본 이동 속도
    [Header("이동거리")]
    public float moveDistance = 3f; // 이동 범위


    private Vector2 startPos;
    private int direction = 1; // 이동 방향 (-1이면 반대 방향)
    private Rigidbody2D rb;
    private Rigidbody2D playerRb; // 플레이어 Rigidbody2D
    private bool isPlayerOnPlatform = false; // 플레이어가 플랫폼 위에 있는지 확인


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rb.bodyType = RigidbodyType2D.Kinematic; // 중력 영향 X
    }

    private void FixedUpdate()
    {
        float traveled = movementType == MovementType.Horizontal ?
            transform.position.x - startPos.x : transform.position.y - startPos.y;

        if (Mathf.Abs(traveled) >= moveDistance)
        {
            direction *= -1; // 방향 반전
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
            collision.transform.SetParent(transform); // 플레이어를 플랫폼의 자식으로 설정
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

        float playerInput = Input.GetAxisRaw("Horizontal"); // 플레이어 입력 가져오기
        float playerSpeed = GameObject.Find("PlayerManager").GetComponent<PlayerManager>().GetPlayerSpeed(); // 기본 플레이어 속도 (플레이어 코드에 맞게 수정 가능)

        // 플랫폼 속도를 보정하여 플레이어 이동을 자연스럽게 조절
        float adjustedSpeed = (playerInput * playerSpeed) + platformVelocity.x;
        playerRb.velocity = new Vector2(adjustedSpeed, playerRb.velocity.y);
    }
}
