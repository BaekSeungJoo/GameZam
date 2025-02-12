using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Item_LoopingAnim : MonoBehaviour
{
    private void Start()
    {
        // y값이 현재 위치에서 +0.5로 이동한 후 -0.5로 이동하는 애니메이션을 무한 반복
        transform.DOMoveY(transform.position.y + 0.5f, 1f)
            .SetEase(Ease.InOutSine) // 부드러운 이징 방식 적용
            .SetLoops(-1, LoopType.Yoyo);
    }
}
