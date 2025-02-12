using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bacchus : MonoBehaviour
{
    public int BacchusAmount = 1; // ȹ�淮

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
            // ��ī�� ȹ���ϴ� ����
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
