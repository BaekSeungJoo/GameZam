using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LazerCollisionCheck : MonoBehaviour
{
    [Header("������ ������")]
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
            // TODO ü�� ���� ����
            print("�÷��̾� ü�� - 3");

            // ü�� ����
            manager.Damage(damage);
            manager.InitPlayUI();
        }
    }
}
