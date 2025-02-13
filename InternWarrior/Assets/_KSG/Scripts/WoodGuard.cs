using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class WoodGuard : MonoBehaviour
{
    public float fadeInDuration = 1.0f; // ���̵��� ���� �ð�
    public float fadeOutDuration = 1.0f; // ���̵�ƿ� ���� �ð�
    public float displayDuration = 2.0f; // ��������Ʈ�� ������ ���̴� ���·� �����Ǵ� �ð�
    public float animationDuration = 1.0f; // �ִϸ��̼� ����ð�
    public int damage = 5; // 

    private SpriteRenderer spriteRenderer;
    private UnityEngine.Color color;
    private PlayerManager playerManager;
    Animator animator;

    [Header("����Ʈ")]
    public VFXPoolObjType vfxType;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();

        if (spriteRenderer != null)
        {
            // ��������Ʈ�� �ʱ� ������ 0���� ����
            color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;

            StartFade();
        }
    }

    public void StartFade()
    {
        // ���̵��� �ڷ�ƾ ����
        StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        // ���̵���
        float elapsedTime = 0f;
        color = spriteRenderer.color;
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeInDuration);
            spriteRenderer.color = color;

            yield return null;
        }

        // ������ �������ϰ� ����
        color.a = 1f;
        spriteRenderer.color = color;

        // �ִϸ��̼� ���
        animator.SetBool("isHitting", true);

        // ���÷��� �ð� ���� ����
        yield return new WaitForSeconds(animationDuration);

        // ����Ʈ ���
        GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(vfxType);
        hitVFX.SetActive(true);
        hitVFX.transform.position = this.transform.position + new Vector3 (0.7f, -0.5f);

        // �÷��̾�� �������� ��
        playerManager.Damage(damage);
        playerManager.InitPlayUI();

        // ���̵�ƿ�
        elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1 - elapsedTime / fadeOutDuration);
            spriteRenderer.color = color;
            yield return null;
        }

        // ������ �����ϰ� ����
        color.a = 0f;
        spriteRenderer.color = color;

        // �Ϸ��� �ִϸ��̼� ����
        animator.SetBool("isHitting", false);
        Destroy(this.gameObject);
    }

}
