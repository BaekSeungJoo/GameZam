using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Light : MonoBehaviour
{
    [Header("����Ʈ")]
    public VFXPoolObjType VfxType;

    private GameObject obstacle;

    private void Start()
    {
        obstacle = this.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ÿ�� ���� ����Ʈ ��
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(VfxType);
            hitVFX.SetActive(true);
            hitVFX.transform.position = this.transform.position;

            // TODO : �÷��̾� HP ��� ����
            print("�÷��̾� hp -1");

            // ��ֹ� ����
            obstacle.SetActive(false);
        }
    }
}
