using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoverSpriteFadeIn : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // 알파 값을 0에서 1로 4초 동안 애니메이션
        spriteRenderer.DOFade(1, 4f).From(0).SetEase(Ease.Linear);
    }
}
