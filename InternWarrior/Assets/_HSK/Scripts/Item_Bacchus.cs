using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bacchus : MonoBehaviour
{
    public int BacchusAmount = 1; // 획득량

    PlayerManager manager;

    private void Start()
    { 
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void Update()
    { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어와 충돌했다면
        {
            // 박카스 획득하는 로직
            if(manager != null)
            {
                manager.GetBacchus(BacchusAmount);
            }


            /*
            PlayerBacchus playerBacchus = other.GetComponent<PlayerBacchus>();
            if (playerBacchus != null)
            {

                playerBacchus.GetBacchus(BacchusAmount);
            }
            */

            Destroy(gameObject);
        }

    }

}
