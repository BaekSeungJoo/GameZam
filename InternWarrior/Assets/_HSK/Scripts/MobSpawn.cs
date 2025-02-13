using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;  // 몬스터 프리팹
    public Transform spawnPoint;      // 몬스터 소환 위치

    private bool hasSpawned = false; // 중복 소환 방지

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasSpawned) // 플레이어가 트리거에 들어오면
        {
            GameObject mob = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);

            KnockbackMob backMob = mob.GetComponent<KnockbackMob>();
            backMob.knockbackForce = 100f;
            backMob.stopTime = 0f;
            backMob.moveTime = 1f;
            backMob.moveDistance = 50f;


            hasSpawned = true; // 한 번만 소환되도록 설정
        }
    }
}
