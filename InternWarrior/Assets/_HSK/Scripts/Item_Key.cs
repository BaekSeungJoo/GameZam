using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Key : MonoBehaviour
{
    PlayerManager playerManager;

    private void Awake()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴٸ�
        {
            // Ű ȹ���ϴ� ����
            //print("Ű ȹ���߽��ϴ�.");
            playerManager.keyCount++;

            Destroy(gameObject);
        }
    }
}
