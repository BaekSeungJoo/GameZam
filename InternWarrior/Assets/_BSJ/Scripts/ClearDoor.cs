using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDoor : MonoBehaviour
{
    [Header("���� ��ġ")]
    public Vector3 endPosition;

    [Header("�ּ� �����")]
    public Vector3 minScale = new Vector3(0.1f, 0.1f, 0.1f); // �ּ� ������ ��

    [Header("�ִϸ��̼� ���� �ð�")]
    public float duration = 2f; // �ִϸ��̼� ���� �ð�

    bool isHit = false;

    PlayerManager manager;

    private void Start()
    { 
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHit) { return; }

        if (other.CompareTag("Player")) // �÷��̾�� �浹�ߴٸ�
        {
            
            isHit = true;

            if(manager.keyCount <= 0)
            {
                manager.TimeOut();
            }

            else
            {
                // ȿ����
                SoundController.PlaySFXSound("1-stage clear");
                
                // �� ��° �ڽ��� ��� �ڽĵ��� �θ� ����
                Transform secondChild = other.transform.GetChild(1);
                if (secondChild != null)
                {
                    secondChild.GetChild(1).SetParent(null);
                    secondChild.GetChild(0).SetParent(null);
                }

                AnimateSprite(other.transform, () =>
                {
                    Debug.Log("�ִϸ��̼� �Ϸ�");
                    // �ִϸ��̼� �Ϸ� �� ȣ���� �Լ� �߰�
                    OnAnimationComplete();
                });
            }
        }   
    }

    void AnimateSprite(Transform playerTransform, TweenCallback onComplete)
    {
        // �̵��� ũ�� ���� �ִϸ��̼� ����
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
