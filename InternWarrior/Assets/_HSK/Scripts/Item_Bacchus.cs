using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bacchus : MonoBehaviour
{
    public int BacchusAmount = 1; // ȹ�淮

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

        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴٸ�
        {
            isHit = true;

            // ȿ����
            SoundController.PlaySFXSound("get");
            
            // ��ī�� ȹ���ϴ� ����
            if (manager != null)
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
