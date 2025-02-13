using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Item_Coin : MonoBehaviour
{
    public int healAmount = 1; // ȸ����

    PlayerManager manager;
    bool isHit = false;

    private void Start()
    { 
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHit) { return; }

        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴٸ�
        {
            isHit = true;

            // 효과음 재생
            SoundController.PlaySFXSound("Coin");

            // ���� ȹ���ϴ� ����
            if(manager != null)
            {
                manager.Heal(healAmount);
            }

            /*
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }
            */

            Destroy(gameObject);
        }
    }

}














