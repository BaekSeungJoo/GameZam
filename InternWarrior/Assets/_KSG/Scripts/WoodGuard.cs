using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGuard : MonoBehaviour
{
    public float fadeInDuration = 1.0f; // ���̵��� ���� �ð�
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // ��������Ʈ�� �ʱ� ������ 0���� ����
            Color color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
        }
    }

    public void StartFade()
    {
        // ���̵��� �ڷ�ƾ ����
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = spriteRenderer.color;

        while (elapsedTime < fadeInDuration)
        {
            // ���̵��� ����
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeInDuration);
            spriteRenderer.color = color;
            yield return null;
        }

        // ���̵��� �Ϸ� �� ������ �������ϰ� ����
        color.a = 1f;
        spriteRenderer.color = color;
    }
}
