using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Key : MonoBehaviour
{
    PlayerManager playerManager;
    bool isHit = false;

    private void Awake()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHit) { return; }
        
        SoundController.PlaySFXSound("get");

        if (other.CompareTag("Player")) // 플레이어와 충돌했다면
        {
            isHit = true;

            // 키 획득하는 로직 (UI 업데이트)
            playerManager.keyCount++;
            playerManager.InitPlayUI();

            Destroy(gameObject);
        }
    }
}
