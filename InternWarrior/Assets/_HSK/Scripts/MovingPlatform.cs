using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MovementType { Horizontal, Vertical } //�÷��� �̵� ���
    public MovementType movementType = MovementType.Horizontal;

    public float speed = 2f; // �̵��ӵ�
    public float moveDistance = 3f; // �̵� ����


    private Vector2 startPos;
    private int direction = 1; // �̵����� -1�̸� �ݴ��������
    private Rigidbody2D rb;




    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rb.bodyType = RigidbodyType2D.Kinematic; // �߷¿� ������ ���� �ʰ� ����

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
            collision.transform.SetParent(transform); // �÷��̾ �÷����� �ڽ����� ����
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
