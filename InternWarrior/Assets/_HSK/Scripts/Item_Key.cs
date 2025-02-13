using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Key : MonoBehaviour
{
    PlayerManager playerManager;
    bool isHit = false;

    private void Awake()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHit) { return; }

        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴٸ�
        {
            isHit = true;

            // Ű ȹ���ϴ� ���� (UI ������Ʈ)
            playerManager.keyCount++;
            playerManager.InitPlayUI();

            Destroy(gameObject);
        }
    }
}
