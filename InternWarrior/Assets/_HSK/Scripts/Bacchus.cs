using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacchus : MonoBehaviour
{
    public int BacchusAmount = 1; // 획득량

    private void Start()
    { }

    private void Update()
    { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어와 충돌했다면
        {
            PlayerBacchus playerBacchus = other.GetComponent<PlayerBacchus>();
            if (playerBacchus != null)
            {
                playerBacchus.GetBacchus(BacchusAmount);
            }
            Destroy(gameObject);
        }

    }

}
