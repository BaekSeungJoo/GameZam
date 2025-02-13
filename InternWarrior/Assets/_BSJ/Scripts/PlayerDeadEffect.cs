using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadEffect : MonoBehaviour
{
    Transform effectTransform;
    SpriteRenderer sprite;

    public float moveSpeed;         // ����Ʈ�� �̵��ϴ� �ӵ�
    public float minSize = 0.5f;    // ����Ʈ �ּ� ũ�� (���)
    public float maxSize = 1f;      // ����Ʈ �ִ� ũ�� (���)
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
        // ������ �������� ��� �̵�
        effectTransform.position += moveSpeed * Time.deltaTime * new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);

        // ����Ʈ�� ũ�⸦ ���� ũ�⿡�� 0���� ����
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
