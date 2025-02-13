using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Alchhol : MonoBehaviour
{
    public int AlchholAmount = 1; // ȹ�淮

    public float speed = 1f; // �ӵ� ����

    public float objectDestroyTime = 5f;
    public float currentDestroyTime = 0f;

    PlayerManager manager;

    bool isHit = false;

    private void Start()
    {
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    void Update()
    {
        // ������Ʈ�� �Ʒ� �������� �̵���Ű��
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        currentDestroyTime += Time.deltaTime;
        if(currentDestroyTime > objectDestroyTime)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHit) { return; }

        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴٸ�
        {
            // �� ���� �°� ����
            isHit = true;

            // �ڵ��ı� �ð� ����
            currentDestroyTime = 0f;

            // ���ڿ� ȹ���ϴ� ����
            if (manager != null)
            {
                manager.GetAlcohol(AlchholAmount);
            }

            // �ı�
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

    }
}
