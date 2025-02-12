using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Item_LoopingAnim : MonoBehaviour
{
    private void Start()
    {
        // y���� ���� ��ġ���� +0.5�� �̵��� �� -0.5�� �̵��ϴ� �ִϸ��̼��� ���� �ݺ�
        transform.DOMoveY(transform.position.y + 0.5f, 1f)
            .SetEase(Ease.InOutSine) // �ε巯�� ��¡ ��� ����
            .SetLoops(-1, LoopType.Yoyo);
    }
}
