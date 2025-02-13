using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaJump : MonoBehaviour
{
    public float jumpMultiplier = 2.0f; //점프 배수

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어와 충돌시
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            PlayerMove playerMove = other.GetComponent<PlayerMove>();

            if (playerRb != null && playerMove != null)
            {
                float jumpForce = playerMove.jumpScale; // 점프 스케일 가져오기
                playerRb.velocity = new Vector2(playerRb.velocity.x, 0); //기존 점프속도 초기화
                playerRb.AddForce(Vector2.up * jumpForce * jumpMultiplier, ForceMode2D.Impulse);

                Debug.Log("소파점프!"); 

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
