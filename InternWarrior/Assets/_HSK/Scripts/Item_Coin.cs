using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Item_Coin : MonoBehaviour
{
    public int healAmount = 1; // 회복량

    PlayerManager manager;
    bool isHit = false;

    private void Start()
    { 
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void Update()
    { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHit) { return; }

        if (other.CompareTag("Player")) // 플레이어와 충돌했다면
        {
            isHit = true;

            // 코인 획득하는 로직
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














