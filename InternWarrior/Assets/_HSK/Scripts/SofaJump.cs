using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaJump : MonoBehaviour
{
    [Header("점프 배수")]
    public float jumpMultiplier = 2.0f; //점프 배수
    private BoxCollider2D sofaCollider;
    private float sofaTopY = 0f;

    void Start()
    {
        sofaCollider = transform.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어 충돌 확인
        {
            
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            PlayerMove playerMove = other.GetComponent<PlayerMove>();

            if (playerRb != null && playerMove != null)
            {
                float playerCenterY = other.GetComponent<Collider2D>().bounds.center.y; // 플레이어 중심 Y

                if(sofaCollider != null)
                {
                    sofaTopY = sofaCollider.bounds.max.y; // 소파 최대 Y값
                }
                
                if(playerCenterY > sofaTopY)
                { 
                // 효과음 재생
                SoundController.PlaySFXSound("Jump");

                float jumpForce = playerMove.jumpScale; // 플레이어 점프력 가져옴
                playerRb.velocity = new Vector2(playerRb.velocity.x, 0); //현재 점프력을 0으로 변경
                playerRb.AddForce(Vector2.up * jumpForce * jumpMultiplier, ForceMode2D.Impulse);

                Debug.Log("소파점프!");
                }


            }

        }
    }
}
