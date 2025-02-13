using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholArea : MonoBehaviour
{
    public int AlchholAmount = 1; // ȹ�淮
    public float stayTime = 10f; // �ʿ��� ������ �ð�
    private float currentStayTime = 0f; // ���� ������ �ð�

    PlayerManager manager;

    bool isHit = false;
    bool isStaying = false;

    private void Start()
    {
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴٸ�
        {
            isStaying = true;
            currentStayTime += Time.deltaTime;

            if (currentStayTime >= stayTime)
            {
                // ������ �ð��� 10�ʸ� ������ �� �ʱ�ȭ
                currentStayTime = 0f;

                // ���ڿ� ȹ���ϴ� ����
                if (manager != null)
                {
                    manager.GetAlcohol(AlchholAmount);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾ Ʈ���Ÿ� �����ٸ�
        {
            isStaying = false;
            currentStayTime = 0f; // Ʈ���Ÿ� ������ �ð��� �ʱ�ȭ
        }
    }
}
