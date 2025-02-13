using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [Header("꽃병만 있는 스프라이트")]
    public Sprite onlyVase;

    PlayerManager playerManager;
    bool isActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!isActivated)
            {
                playerManager.SpawnTreeGuard();
                isActivated = true;

                GetComponent<SpriteRenderer>().sprite = onlyVase;
            }    
        }
    }
}
