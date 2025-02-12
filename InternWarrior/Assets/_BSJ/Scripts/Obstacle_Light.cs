using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Light : MonoBehaviour
{
    public Transform effectPool;

    private GameObject obstacle;
    private ParticleSystem collision_effect;

    private void Start()
    {
        obstacle = this.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision_effect = effectPool.GetChild(0).GetComponent<ParticleSystem>();
            if (collision_effect != null)
            {
                collision_effect.transform.position = this.transform.position;
                collision_effect.Play();
            }

            // TODO : 플레이어 HP 닳는 로직
            print("플레이어 hp -1");

            // 장애물 삭제
            obstacle.SetActive(false);
        }
    }
}
