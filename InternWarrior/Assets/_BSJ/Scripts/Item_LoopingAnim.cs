using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Item_LoopingAnim : MonoBehaviour
{
    [Header("�� �� ���� �̵��� ������ ���ϴ� �ð�")]
    public float moveTime = 1f;

    [Header("�� �Ʒ� �̵� ���� ��")]
    public float moveHigh = 0.5f;

    // ���Ʒ������̴� Ʈ��
    private Tween moveTween;

    private void Start()
    {
        // y���� ���� ��ġ���� +0.5�� �̵��� �� -0.5�� �̵��ϴ� �ִϸ��̼��� ���� �ݺ�
        moveTween = transform.DOMoveY(transform.position.y + moveHigh, moveTime)
            .SetEase(Ease.InOutSine) // �ε巯�� ��¡ ��� ����
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        // ������Ʈ�� �ı��� �� �ִϸ��̼� ����
        if (moveTween != null)
        {
            moveTween.Kill();
        }
    }

    private void OnDisable()
    {
        // ������Ʈ�� ��Ȱ��ȭ�� �� �ִϸ��̼� ����
        if (moveTween != null)
        {
            moveTween.Kill();
        }
    }
}
