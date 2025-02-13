using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;  // ���� ������
    public Transform spawnPoint;      // ���� ��ȯ ��ġ

    private bool hasSpawned = false; // �ߺ� ��ȯ ����

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasSpawned) // �÷��̾ Ʈ���ſ� ������
        {
            GameObject mob = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);

            KnockbackMob backMob = mob.GetComponent<KnockbackMob>();
            backMob.knockbackForce = 100f;
            backMob.stopTime = 0f;
            backMob.moveTime = 1f;
            backMob.moveDistance = 50f;


            hasSpawned = true; // �� ���� ��ȯ�ǵ��� ����
        }
    }
}
