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
        // ���� ���� 0���� 1�� 4�� ���� �ִϸ��̼�
        spriteRenderer.DOFade(1, 4f).From(0).SetEase(Ease.Linear);
    }
}
