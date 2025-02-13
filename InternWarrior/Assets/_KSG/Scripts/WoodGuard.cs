using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class WoodGuard : MonoBehaviour
{
    public float fadeInDuration = 1.0f; // 페이드인 지속 시간
    public float fadeOutDuration = 1.0f; // 페이드아웃 지속 시간
    public float displayDuration = 2.0f; // 스프라이트가 완전히 보이는 상태로 유지되는 시간

    private SpriteRenderer spriteRenderer;
    private bool isActivated = false;
    private UnityEngine.Color color;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // 스프라이트의 초기 투명도를 0으로 설정
            color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
        }
    }

    public void StartFade()
    {
        if (!isActivated)
        {
            // 페이드인 코루틴 시작
            StartCoroutine(FadeIn());
            isActivated = true;
        }
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        color = spriteRenderer.color;

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

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        color = spriteRenderer.color;

        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1 - elapsedTime / fadeOutDuration);
            spriteRenderer.color = color;
            yield return null;
        }
    }
}
