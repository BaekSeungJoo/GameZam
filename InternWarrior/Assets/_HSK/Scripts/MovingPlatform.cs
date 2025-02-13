using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MovementType { Horizontal, Vertical } //플랫폼 이동 방식
    public MovementType movementType = MovementType.Horizontal;

    public float speed = 2f; // 이동속도
    public float moveDistance = 3f; // 이동 범위


    private Vector2 startPos;
    private int direction = 1; // 이동방향 -1이면 반대방향으로
    private Rigidbody2D rb;




    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rb.bodyType = RigidbodyType2D.Kinematic; // 중력에 영향을 받지 않게 설정

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float traveled = movementType == MovementType.Horizontal ?
            transform.position.x - startPos.x : transform.position.y - startPos.y;

        if (Mathf.Abs(traveled) >= moveDistance)
        {
            direction *= -1;
        }

        Vector2 movement = movementType == MovementType.Horizontal ?
            new Vector2(direction * speed, rb.velocity.y) :
            new Vector2(rb.velocity.x, direction * speed);

        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform); // 플레이어를 플랫폼의 자식으로 설정
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }


    void Update()
    {

    }
}
