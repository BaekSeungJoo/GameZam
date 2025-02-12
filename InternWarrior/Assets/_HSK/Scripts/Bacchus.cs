using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacchus : MonoBehaviour
{
    public int BacchusAmount = 1; // ȹ�淮

    private void Start()
    { }

    private void Update()
    { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴٸ�
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
