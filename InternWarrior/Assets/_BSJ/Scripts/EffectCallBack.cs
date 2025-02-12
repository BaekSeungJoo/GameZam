using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCallBack : MonoBehaviour
{
    // ����Ʈ Ÿ��
    public VFXPoolObjType effectType;

    // �ڵ����� ��ȯ�Ǵ� �ð�
    [SerializeField]
    private float effectReturnTime = 2f;

    // ������ �������� ������ �ð�
    [SerializeField]
    private float startTime = 0f;

    private void Update()
    {
        // ������ �������� �� �ʰ� �������� �����ֱ�
        startTime += Time.deltaTime;

        // �Ѿ��� ��ȯ�Ǵ� �ð��� �Ǹ� ��ȯ
        if (startTime > effectReturnTime)
        {
            // ������Ʈ Ǯ�� ��ȯ
            startTime = 0f;
            VFXObjectPool.instance.CoolObj(gameObject, effectType);
        }
    }

    private void OnDisable()
    {
        startTime = 0f;
    }
}