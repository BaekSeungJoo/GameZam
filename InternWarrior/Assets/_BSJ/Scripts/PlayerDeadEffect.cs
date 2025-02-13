using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadEffect : MonoBehaviour
{
    Transform effectTransform;
    SpriteRenderer sprite;

    public float moveSpeed;         // 이펙트가 이동하는 속도
    public float minSize = 0.5f;    // 이펙트 최소 크기 (축소)
    public float maxSize = 1f;      // 이펙트 최대 크기 (축소)
    public float sizeSpeed = 1;
    public Color[] colors;
    public float colorSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        effectTransform = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        float size = Random.Range(minSize, maxSize);
        effectTransform.localScale = new Vector2(size, size);
        sprite.color = colors[Random.Range(0, colors.Length)];
        moveSpeed = Random.Range(20, 40);
    }

    // Update is called once per frame
    void Update()
    {
        // 랜덤한 방향으로 계속 이동
        effectTransform.position += moveSpeed * Time.deltaTime * new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);

        // 이펙트의 크기를 현재 크기에서 0까지 줄임
        effectTransform.localScale = Vector2.Lerp(effectTransform.localScale, Vector2.zero, Time.deltaTime * sizeSpeed);

        Color color = sprite.color;
        color.a = Mathf.Lerp(sprite.color.a, 0, Time.deltaTime * colorSpeed);
        sprite.color = color;

        if (sprite.color.a <= 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
