using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어와 충돌했다면
        {
            // 키 획득하는 로직
            print("키 획득했습니다.");

            Destroy(gameObject);
        }
    }
}
