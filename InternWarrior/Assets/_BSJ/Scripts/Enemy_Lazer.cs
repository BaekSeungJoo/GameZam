using System.Collections;
using UnityEngine;
using DG.Tweening;

public class LaserController : MonoBehaviour
{
    public GameObject laserObject; // ������ ������Ʈ
    public float activeTime = 3f; // ������ Ȱ��ȭ �ð�
    public float inactiveTime = 3f; // ������ ��Ȱ��ȭ �ð�
    public Vector3 targetScale = new Vector3(2f, 7.5f, 1f); // ������ ���� ������
    public float scaleDuration = 0.2f; // ������ �ִϸ��̼� �ð�

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
            // ������ ����
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // ������ Ȱ��ȭ
            laserObject.SetActive(true);

            // ������ ������ ����
            laserObject.transform.localScale = new Vector3(0, 0, 1); // �ʱ� ������ ����
            Tween scaleUpTween = laserObject.transform.DOScale(targetScale, scaleDuration);

            // ������ ���� �Ϸ� ���
            yield return scaleUpTween.WaitForCompletion();

            // ������ ���� �ð� ���
            yield return new WaitForSeconds(activeTime - 2 * scaleDuration);

            // ������ ������ ����
            Tween scaleDownTween = laserObject.transform.DOScale(new Vector3(0, targetScale.y, 1), scaleDuration);

            // ������ ���� �Ϸ� ���
            yield return scaleDownTween.WaitForCompletion();

            // ������ ��Ȱ��ȭ
            laserObject.SetActive(false);

            // ��Ȱ��ȭ �ð� ���
            yield return new WaitForSeconds(inactiveTime);
        }
    }
}
