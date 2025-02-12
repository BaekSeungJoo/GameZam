using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy_TiredWorker : MonoBehaviour
{
    [Header("��� ��� ǥ�� �ð�")]
    public float deadTimer = 2f;

    [Header("�󸶳� ���� �ö� �� ����")]
    public float deadHigh = 2f;

    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void Dead_Worker()
    {
        // �ڽ� �ݶ��̴� ����
        if (boxCollider2D != null)
        {
            boxCollider2D.enabled = false;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();

        // ���� ���̱�
        spriteRenderer.DOFade(0, deadTimer);

        // Ʈ������ y�� �ø���
        transform.DOMoveY(transform.position.y + deadHigh, deadTimer);
    }
}
