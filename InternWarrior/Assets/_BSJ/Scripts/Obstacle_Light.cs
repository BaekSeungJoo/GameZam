using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Light : MonoBehaviour
{
    [Header("����Ʈ")]
    public VFXPoolObjType VfxType;

    [Header("������")]
    public int damage = 3;

    PlayerManager playerManager;

    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ȿ����
        SoundController.PlaySFXSound("light");

        if (collision.gameObject.CompareTag("Player"))
        {
            // Ÿ�� ���� ����Ʈ ��
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(VfxType);
            hitVFX.SetActive(true);
            hitVFX.transform.position = this.transform.position;

            // �÷��̾�� �������� ��
            playerManager.Damage(damage);
            playerManager.InitPlayUI();

            // ��ֹ� ����
            this.gameObject.SetActive(false);
        }

        else
        {
            // Ÿ�� ���� ����Ʈ ��
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(VfxType);
            hitVFX.SetActive(true);
            hitVFX.transform.position = this.transform.position;

            // ��ֹ� ����
            Destroy(this.gameObject);
        }
    }
}
