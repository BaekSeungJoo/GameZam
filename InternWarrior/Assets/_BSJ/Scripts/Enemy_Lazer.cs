using System.Collections;
using UnityEngine;
using DG.Tweening;

public class LaserController : MonoBehaviour
{
    public GameObject laserObject; // 레이저 오브젝트
    public float activeTime = 3f; // 레이저 활성화 시간
    public float inactiveTime = 3f; // 레이저 비활성화 시간
    public Vector3 targetScale = new Vector3(2f, 7.5f, 1f); // 레이저 최종 스케일
    public float scaleDuration = 0.2f; // 스케일 애니메이션 시간

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(LaserRoutine());
    }

    private IEnumerator LaserRoutine()
    {
        while (true)
        {
            // 레이저 사운드
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // 레이저 활성화
            laserObject.SetActive(true);

            // 레이저 스케일 증가
            laserObject.transform.localScale = new Vector3(0, 0, 1); // 초기 스케일 설정
            Tween scaleUpTween = laserObject.transform.DOScale(targetScale, scaleDuration);

            // 스케일 증가 완료 대기
            yield return scaleUpTween.WaitForCompletion();

            // 레이저 유지 시간 대기
            yield return new WaitForSeconds(activeTime - 2 * scaleDuration);

            // 레이저 스케일 감소
            Tween scaleDownTween = laserObject.transform.DOScale(new Vector3(0, targetScale.y, 1), scaleDuration);

            // 스케일 감소 완료 대기
            yield return scaleDownTween.WaitForCompletion();

            // 레이저 비활성화
            laserObject.SetActive(false);

            // 비활성화 시간 대기
            yield return new WaitForSeconds(inactiveTime);
        }
    }
}
