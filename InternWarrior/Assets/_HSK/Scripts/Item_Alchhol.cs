using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Alchhol : MonoBehaviour
{
    public int AlchholAmount = 1; // ȹ�淮

    PlayerManager manager;

    private void Start()
    {
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴٸ�
        {
            Destroy(gameObject);

            // ��ī�� ȹ���ϴ� ����
            if (manager != null)
            {
                manager.GetAlcohol(AlchholAmount);
            }

            /*
            PlayerBacchus playerBacchus = other.GetComponent<PlayerBacchus>();
            if (playerBacchus != null)
            {

                playerBacchus.GetBacchus(BacchusAmount);
            }
            */
        }

    }
}
