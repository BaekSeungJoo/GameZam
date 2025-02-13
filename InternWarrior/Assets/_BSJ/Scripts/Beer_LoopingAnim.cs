using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Beer_LoopingAnim : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float fireRate = 3f; // �߻� ���� (��)

    private void Start()
    {
        AnimateScale();
        InvokeRepeating("Fire", fireRate, fireRate);
    }

    private void AnimateScale()
    {
        transform.DOScale(0.95f, fireRate)
                 .SetEase(Ease.InOutSine)
                 .OnComplete(() =>
                 {
                     transform.DOScale(Vector3.one, 0.1f)
                              .SetEase(Ease.OutBounce) // Ȯ Ŀ���鼭 ����Ʈ �ְ�
                              .OnComplete(() =>
                              {
                                  AnimateScale();
                              });
                 });
    }

    private void Fire()
    {
        Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        // �߰����� �߻� ȿ���� ���⼭ ������ �� �ֽ��ϴ�.
    }
}
