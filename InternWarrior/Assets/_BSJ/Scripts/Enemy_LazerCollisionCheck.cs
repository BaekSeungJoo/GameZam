using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LazerCollisionCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // TODO ü�� ���� ����
            print("�÷��̾� ü�� - 3");
        }
    }
}
