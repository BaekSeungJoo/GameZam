using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Item_LoopingAnim : MonoBehaviour
{
    [Header("몇 초 동안 이동할 것인지 정하는 시간")]
    public float moveTime = 1f;

    [Header("위 아래 이동 높이 값")]
    public float moveHigh = 0.5f;

    // 위아래움직이는 트윈
    private Tween moveTween;

    private void Start()
    {
        // y값이 현재 위치에서 +0.5로 이동한 후 -0.5로 이동하는 애니메이션을 무한 반복
        moveTween = transform.DOMoveY(transform.position.y + moveHigh, moveTime)
            .SetEase(Ease.InOutSine) // 부드러운 이징 방식 적용
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        // 오브젝트가 파괴될 때 애니메이션 중지
        if (moveTween != null)
        {
            moveTween.Kill();
        }
    }

    private void OnDisable()
    {
        // 오브젝트가 비활성화될 때 애니메이션 중지
        if (moveTween != null)
        {
            moveTween.Kill();
        }
    }
}
