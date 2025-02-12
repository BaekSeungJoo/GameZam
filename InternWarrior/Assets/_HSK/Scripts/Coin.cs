using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int healAmount = 1; // ȸ����

    private void Start()
    { }

    private void Update()
    { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴٸ�
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }
            Destroy(gameObject);
        }

    }

}














