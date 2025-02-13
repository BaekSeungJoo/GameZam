using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Bacchus : MonoBehaviour
{
    [Header("ȸ���ӵ�")]
    public float rotationSpeed = 360f;

    [Header("���ư��� ����")]
    public Vector3 flyDirection = Vector3.right;

    [Header("���ư��� �ӵ�")]
    public float flySpeed = 5f;

    [Header("����Ʈ")]
    [Header("����")]
    public VFXPoolObjType good_VfxType;

    [Header("����")]
    public VFXPoolObjType bad_VfxType;

    private PlayerManager playerManager;
    private float timer = 0.0f;

    private void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        SetFlyDirection();
    }

    private void Update()
    {
        // ��������Ʈ ȸ��
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);

        // ��������Ʈ �̵�
        transform.Translate(flyDirection * flySpeed * Time.deltaTime, Space.World);

        // 5���� ����
        timer += Time.deltaTime;
        if (timer > 5.0f)
            Destroy(this.gameObject);
    }

    // ���ư��� ���� ���� �Լ�
    public void SetFlyDirection()
    {
        string direction = playerManager.GetWeaponDir();

        if (direction == "right")
        {
            flyDirection = Vector3.right;
        }
        else if (direction == "left")
        {
            flyDirection = Vector3.left;
        }
        else
        {
            Debug.LogError("Invalid direction. Use 'right' or 'left'.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ǰ��� ȸ����� ����� ���
        if (collision.gameObject.CompareTag("TiredWorker"))
        {
            // Ÿ�� ���� ����Ʈ ��
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(good_VfxType);
            hitVFX.SetActive(true);
            hitVFX.transform.position = this.transform.position;

            // TODO : �÷��̾� ü�� ȸ��
            print("��ī�� ��ô : �÷��̾� ü�� ȸ��");

            // �ǰ��� ���� ��� ���
            Enemy_TiredWorker enemy_TiredWorker = collision.gameObject.transform.GetComponent<Enemy_TiredWorker>();
            if (enemy_TiredWorker != null)
            {
                enemy_TiredWorker.Dead_Worker();
            }

            // ��ֹ� ����
            Destroy(this.gameObject);
        }

        // �� �ܿ� ����� ���
        else
        {
            // Ÿ�� ���� ����Ʈ ��
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(bad_VfxType);
            hitVFX.SetActive(true);
            hitVFX.transform.position = this.transform.position;

            // ��ֹ� ����
            Destroy(this.gameObject);
        }
    }
}
