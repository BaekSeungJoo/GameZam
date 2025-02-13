using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LazerCollisionCheck : MonoBehaviour
{
    [Header("레이저 데미지")]
    public int damage = 3;

    PlayerManager manager;

    void Start()
    {
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            // TODO 체력 감소 로직
            print("플레이어 체력 - 3");

            // 체력 감소
            manager.Damage(damage);
            manager.InitPlayUI();
        }
    }
}
