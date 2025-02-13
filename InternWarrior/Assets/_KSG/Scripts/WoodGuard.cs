using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class WoodGuard : MonoBehaviour
{
    public float fadeInDuration = 1.0f; // 페이드인 지속 시간
    public float fadeOutDuration = 1.0f; // 페이드아웃 지속 시간
    public float displayDuration = 2.0f; // 스프라이트가 완전히 보이는 상태로 유지되는 시간
    public float animationDuration = 1.0f; // 애니메이션 재생시간
    public int damage = 5; // 

    private SpriteRenderer spriteRenderer;
    private UnityEngine.Color color;
    private PlayerManager playerManager;
    Animator animator;

    [Header("이펙트")]
    public VFXPoolObjType vfxType;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();

        if (spriteRenderer != null)
        {
            // 스프라이트의 초기 투명도를 0으로 설정
            color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;

            StartFade();
        }
    }

    public void StartFade()
    {
        // 페이드인 코루틴 시작
        StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        // 페이드인
        float elapsedTime = 0f;
        color = spriteRenderer.color;
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeInDuration);
            spriteRenderer.color = color;

            yield return null;
        }

        // 완전히 불투명하게 설정
        color.a = 1f;
        spriteRenderer.color = color;

        // 애니메이션 재생
        animator.SetBool("isHitting", true);

        // 디스플레이 시간 동안 유지
        yield return new WaitForSeconds(animationDuration);

        // 이펙트 재생
        GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(vfxType);
        hitVFX.SetActive(true);
        hitVFX.transform.position = this.transform.position + new Vector3 (0.7f, -0.5f);

        // 플레이어에게 데미지를 줌
        playerManager.Damage(damage);
        playerManager.InitPlayUI();

        // 페이드아웃
        elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1 - elapsedTime / fadeOutDuration);
            spriteRenderer.color = color;
            yield return null;
        }

        // 완전히 투명하게 설정
        color.a = 0f;
        spriteRenderer.color = color;

        // 완료후 애니메이션 해제
        animator.SetBool("isHitting", false);
        Destroy(this.gameObject);
    }

}
