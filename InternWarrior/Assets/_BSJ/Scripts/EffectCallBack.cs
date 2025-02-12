using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCallBack : MonoBehaviour
{
    // 이펙트 타입
    public VFXPoolObjType effectType;

    // 자동으로 반환되는 시간
    [SerializeField]
    private float effectReturnTime = 2f;

    // 생성된 시점부터 더해질 시간
    [SerializeField]
    private float startTime = 0f;

    private void Update()
    {
        // 생성된 시점부터 몇 초가 지났는지 더해주기
        startTime += Time.deltaTime;

        // 총알이 반환되는 시간이 되면 반환
        if (startTime > effectReturnTime)
        {
            // 오브젝트 풀로 반환
            startTime = 0f;
            VFXObjectPool.instance.CoolObj(gameObject, effectType);
        }
    }

    private void OnDisable()
    {
        startTime = 0f;
    }
}