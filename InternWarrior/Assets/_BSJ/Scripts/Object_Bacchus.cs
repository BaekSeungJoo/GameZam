using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Bacchus : MonoBehaviour
{
    [Header("회전속도")]
    public float rotationSpeed = 360f;

    [Header("날아가는 방향")]
    public Vector3 flyDirection = Vector3.right;

    [Header("날아가는 속도")]
    public float flySpeed = 5f;

    [Header("이펙트")]
    [Header("성공")]
    public VFXPoolObjType good_VfxType;

    [Header("실패")]
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
        // 스프라이트 회전
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);

        // 스프라이트 이동
        transform.Translate(flyDirection * flySpeed * Time.deltaTime, Space.World);

        // 5초후 제거
        timer += Time.deltaTime;
        if (timer > 5.0f)
            Destroy(this.gameObject);
    }

    // 날아가는 방향 설정 함수
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
        // 피곤한 회사원에 닿았을 경우
        if (collision.gameObject.CompareTag("TiredWorker"))
        {
            // 타격 성공 이펙트 콜
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(good_VfxType);
            hitVFX.SetActive(true);
            hitVFX.transform.position = this.transform.position;

            // TODO : 플레이어 체력 회복
            print("박카스 투척 : 플레이어 체력 회복");

            // 피곤한 경비원 사망 모션
            Enemy_TiredWorker enemy_TiredWorker = collision.gameObject.transform.GetComponent<Enemy_TiredWorker>();
            if (enemy_TiredWorker != null)
            {
                enemy_TiredWorker.Dead_Worker();
            }

            // 장애물 삭제
            Destroy(this.gameObject);
        }

        // 그 외에 닿았을 경우
        else
        {
            // 타격 실패 이펙트 콜
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(bad_VfxType);
            hitVFX.SetActive(true);
            hitVFX.transform.position = this.transform.position;

            // 장애물 삭제
            Destroy(this.gameObject);
        }
    }
}
