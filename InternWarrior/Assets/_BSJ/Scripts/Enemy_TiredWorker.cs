using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy_TiredWorker : MonoBehaviour
{
    [Header("사망 모션 표현 시간")]
    public float deadTimer = 2f;

    [Header("얼마나 높이 올라갈 것 인지")]
    public float deadHigh = 2f;

    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;

    PlayerManager playerManager;

    public void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        if (playerManager == null)
        {
            Debug.LogError("PlayerManager 인식 불가");
        }
    }

    public void Dead_Worker()
    {
        // 박스 콜라이더 끄기
        if (boxCollider2D != null)
        {
            boxCollider2D.enabled = false;
        }

        // 회복
        playerManager.Heal(2);

        spriteRenderer = GetComponent<SpriteRenderer>();

        // 투명도 줄이기
        spriteRenderer.DOFade(0, deadTimer);

        // 트랜스폼 y값 올리기
        transform.DOMoveY(transform.position.y + deadHigh, deadTimer);
    }
}
