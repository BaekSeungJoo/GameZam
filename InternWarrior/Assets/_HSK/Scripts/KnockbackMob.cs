using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnockbackMob : MonoBehaviour
{   //넉백 관련
    [Header("밀어내는 힘")]
    public float knockbackForce = 50f; // 밀어내는 힘
    [Header("스턴 시간(초)")]
    public float stunTime = 1.0f;
    //이동 관련
    [Header("이동 속도")]
    public float speed = 2f; // 이동속도
    [Header("이동 거리")]
    public float moveDistance = 3f; //이동 범위

    //멈추게 하는거
    [Header("활성화 시간(초)")]
    public float moveTime = 3f;
    [Header("비활성화 시간(초)")]
    public float stopTime = 2f;


    private Rigidbody2D rb;
    private Vector2 startPos;
    private int direction = 1; // 방향 > 1이면 오른쪽, -1이면 왼쪽으로
    private SpriteRenderer spriteRenderer;
    private bool isMoving = true; //현재 이동중인지 여부

    PlayerManager playerManager;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 효과음 재생
            SoundController.PlaySFXSound("hit");

            Debug.Log("플레이어 충돌감지");
            // 플레이어 스턴
            playerManager.SetStun(true);
            playerManager.SetStunTime(stunTime);


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
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        if (playerManager == null)
        {
            Debug.LogError("PlayerManager 인식 불가");
        }

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;

        StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            isMoving = true;
            yield return new WaitForSeconds(moveTime);

            isMoving = false;
            rb.velocity = Vector2.zero; // 속도 초기화
            yield return new WaitForSeconds(stopTime);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (isMoving)
        {

            float traveled = transform.position.x - startPos.x; // 현재 이동거리 계산

            if (Mathf.Abs(traveled) >= moveDistance)
            {
                direction *= -1;
                spriteRenderer.flipX = !spriteRenderer.flipX; //이미지 뒤집기
            }

            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        }

    }
}
