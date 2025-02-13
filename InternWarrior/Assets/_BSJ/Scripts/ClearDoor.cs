using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDoor : MonoBehaviour
{
    [Header("최종 위치")]
    public Vector3 endPosition;

    [Header("최소 사이즈값")]
    public Vector3 minScale = new Vector3(0.1f, 0.1f, 0.1f); // 최소 사이즈 값

    [Header("애니메이션 지속 시간")]
    public float duration = 2f; // 애니메이션 지속 시간

    bool isHit = false;

    PlayerManager manager;

    private void Start()
    { 
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHit) { return; }

        if (other.CompareTag("Player")) // 플레이어와 충돌했다면
        {
            
            isHit = true;

            if(manager.keyCount <= 0)
            {
                manager.TimeOut();
            }

            else
            {
                // 효과음
                SoundController.PlaySFXSound("1-stage clear");
                
                // 두 번째 자식의 모든 자식들의 부모를 없앰
                Transform secondChild = other.transform.GetChild(1);
                if (secondChild != null)
                {
                    secondChild.GetChild(1).SetParent(null);
                    secondChild.GetChild(0).SetParent(null);
                }

                AnimateSprite(other.transform, () =>
                {
                    Debug.Log("애니메이션 완료");
                    // 애니메이션 완료 후 호출할 함수 추가
                    OnAnimationComplete();
                });
            }
        }   
    }

    void AnimateSprite(Transform playerTransform, TweenCallback onComplete)
    {
        // 이동과 크기 조정 애니메이션 설정
        Sequence sequence = DOTween.Sequence();
        sequence.Append(playerTransform.DOMove(transform.position + endPosition, duration).SetEase(Ease.Linear));
        sequence.Join(playerTransform.DOScale(minScale, duration).SetEase(Ease.Linear));
        sequence.OnComplete(onComplete);
    }

    void OnAnimationComplete()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("2 Play");
    }
}
