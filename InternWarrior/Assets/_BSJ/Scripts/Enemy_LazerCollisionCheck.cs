using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LazerCollisionCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // TODO 체력 감소 로직
            print("플레이어 체력 - 3");
        }
    }
}
