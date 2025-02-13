using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Light : MonoBehaviour
{
    [Header("이펙트")]
    public VFXPoolObjType VfxType;

    [Header("데미지")]
    public int damage = 3;

    PlayerManager playerManager;

    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 효과음
        SoundController.PlaySFXSound("light");

        if (collision.gameObject.CompareTag("Player"))
        {
            // 타격 성공 이펙트 콜
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(VfxType);
            hitVFX.SetActive(true);
            hitVFX.transform.position = this.transform.position;

            // 플레이어에게 데미지를 줌
            playerManager.Damage(damage);
            playerManager.InitPlayUI();

            // 장애물 삭제
            this.gameObject.SetActive(false);
        }

        else
        {
            // 타격 실패 이펙트 콜
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(VfxType);
            hitVFX.SetActive(true);
            hitVFX.transform.position = this.transform.position;

            // 장애물 삭제
            Destroy(this.gameObject);
        }
    }
}
