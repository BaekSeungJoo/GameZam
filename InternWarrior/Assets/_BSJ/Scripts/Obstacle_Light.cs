using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Light : MonoBehaviour
{
    [Header("이펙트")]
    public VFXPoolObjType VfxType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 타격 성공 이펙트 콜
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(VfxType);
            hitVFX.SetActive(true);
            hitVFX.transform.position = this.transform.position;

            // TODO : 플레이어 HP 닳는 로직
            print("플레이어 hp -1");

            // 장애물 삭제
            this.gameObject.SetActive(false);
        }
    }
}
