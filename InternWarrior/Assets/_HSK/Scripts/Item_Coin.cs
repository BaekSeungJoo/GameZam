using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Item_Coin : MonoBehaviour
{
    public int healAmount = 1; // ȸ����

    PlayerManager manager;

    private void Start()
    { 
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void Update()
    { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴٸ�
        {
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














