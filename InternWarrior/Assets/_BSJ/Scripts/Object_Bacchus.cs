using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Bacchus : MonoBehaviour
{
    [Header("ȸ���ӵ�")]
    public float rotationSpeed = 360f;

    [Header("���ư��� ����")]
    public Vector3 flyDirection = Vector3.right;

    [Header("���ư��� �ӵ�")]
    public float flySpeed = 5f;

    [Header("����Ʈ")]
    public Transform effectPool;
    private ParticleSystem collision_effect;

    private void Update()
    {
        // ��������Ʈ ȸ��
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);

        // ��������Ʈ �̵�
        transform.Translate(flyDirection * flySpeed * Time.deltaTime, Space.World);
    }

    // ���ư��� ���� ���� �Լ�
    public void SetFlyDirection(string direction)
    {
        if (direction == "right")
        {
            flyDirection = Vector3.right;
        }
        else if (direction == "left")
        {
            flyDirection = Vector3.left;
        }
        else
        {
            Debug.LogError("Invalid direction. Use 'right' or 'left'.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ǰ��� ȸ����� ����� ���
        if (collision.gameObject.CompareTag("TiredWorker"))
        {
            // ���� ����Ʈ
            collision_effect = effectPool.GetChild(1).GetComponent<ParticleSystem>();
            if (collision_effect != null)
            {
                collision_effect.transform.position = this.transform.position;
                collision_effect.Play();
            }

            // TODO : �÷��̾� ü�� ȸ��
            print("��ī�� ��ô : �÷��̾� ü�� ȸ��");

            // �ǰ��� ���� ��� ���
            Enemy_TiredWorker enemy_TiredWorker = collision.gameObject.transform.GetComponent<Enemy_TiredWorker>();
            if (enemy_TiredWorker != null)
            {
                enemy_TiredWorker.Dead_Worker();
            }

            // ��ֹ� ����
            Destroy(this.gameObject);
        }

        // �� �ܿ� ����� ���
        else
        {
            // ����Ʈ
            collision_effect = effectPool.GetChild(0).GetComponent<ParticleSystem>();
            if (collision_effect != null)
            {
                collision_effect.transform.position = this.transform.position;
                collision_effect.Play();
            }

            // ��ֹ� ����
            Destroy(this.gameObject);
        }
    }
}
