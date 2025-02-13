using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Beer_LoopingAnim : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float fireRate = 3f; // 발사 간격 (초)

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
                              .SetEase(Ease.OutBounce) // 확 커지면서 임팩트 있게
                              .OnComplete(() =>
                              {
                                  AnimateScale();
                              });
                 });
    }

    private void Fire()
    {
        Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        // 추가적인 발사 효과를 여기서 구현할 수 있습니다.
    }
}
