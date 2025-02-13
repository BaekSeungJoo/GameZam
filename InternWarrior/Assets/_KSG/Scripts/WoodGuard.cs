using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGuard : MonoBehaviour
{
    public float fadeInDuration = 1.0f; // 페이드인 지속 시간
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // 스프라이트의 초기 투명도를 0으로 설정
            Color color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
        }
    }

    public void StartFade()
    {
        // 페이드인 코루틴 시작
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = spriteRenderer.color;

        while (elapsedTime < fadeInDuration)
        {
            // 페이드인 진행
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeInDuration);
            spriteRenderer.color = color;
            yield return null;
        }

        // 페이드인 완료 후 완전히 불투명하게 설정
        color.a = 1f;
        spriteRenderer.color = color;
    }
}
