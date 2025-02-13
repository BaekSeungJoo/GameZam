using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnockbackMob : MonoBehaviour
{   //�˹� ����
    [Header("�о�� ��")]
    public float knockbackForce = 50f; // �о�� ��
    [Header("���� �ð�(��)")]
    public float stunTime = 1.0f;
    //�̵� ����
    [Header("�̵� �ӵ�")]
    public float speed = 2f; // �̵��ӵ�
    [Header("�̵� �Ÿ�")]
    public float moveDistance = 3f; //�̵� ����

    //���߰� �ϴ°�
    [Header("Ȱ��ȭ �ð�(��)")]
    public float moveTime = 3f;
    [Header("��Ȱ��ȭ �ð�(��)")]
    public float stopTime = 2f;


    private Rigidbody2D rb;
    private Vector2 startPos;
    private int direction = 1; // ���� > 1�̸� ������, -1�̸� ��������
    private SpriteRenderer spriteRenderer;
    private bool isMoving = true; //���� �̵������� ����

    PlayerManager playerManager;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ȿ���� ���
            SoundController.PlaySFXSound("hit");

            Debug.Log("�÷��̾� �浹����");
            // �÷��̾� ����
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
                playerRb.velocity = Vector2.zero; // ���� �÷��̾� �ӵ� 0���� �ʱ�ȭ
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }

    }

    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        if (playerManager == null)
        {
            Debug.LogError("PlayerManager �ν� �Ұ�");
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
            rb.velocity = Vector2.zero; // �ӵ� �ʱ�ȭ
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

            float traveled = transform.position.x - startPos.x; // ���� �̵��Ÿ� ���

            if (Mathf.Abs(traveled) >= moveDistance)
            {
                direction *= -1;
                spriteRenderer.flipX = !spriteRenderer.flipX; //�̹��� ������
            }

            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        }

    }
}
