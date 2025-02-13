using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class WoodGuard : MonoBehaviour
{
    public float fadeInDuration = 1.0f; // ���̵��� ���� �ð�
    public float fadeOutDuration = 1.0f; // ���̵�ƿ� ���� �ð�
    public float displayDuration = 2.0f; // ��������Ʈ�� ������ ���̴� ���·� �����Ǵ� �ð�

    private SpriteRenderer spriteRenderer;
    private bool isActivated = false;
    private UnityEngine.Color color;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // ��������Ʈ�� �ʱ� ������ 0���� ����
            color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
        }
    }

    public void StartFade()
    {
        if (!isActivated)
        {
            // ���̵��� �ڷ�ƾ ����
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
