using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴٸ�
        {
            // Ű ȹ���ϴ� ����
            print("Ű ȹ���߽��ϴ�.");

            Destroy(gameObject);
        }
    }
}
