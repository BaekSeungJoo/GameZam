using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Intro : MonoBehaviour
{
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        ScaleImage();
    }

    void ScaleImage()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 0.5f));
    }
}
