using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cameraTransform;  // ī�޶� ����
    public float parallaxEffect = 0.01f; // ��� �̵� ���� (0.1~0.5 ���� ��õ)

    private Vector3 lastCameraPosition;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform; // ���� ī�޶� ��������

        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        // ī�޶� �̵� ������ �ݴ� �������� ��� �̵�
        transform.position += new Vector3(-1 * deltaMovement.x * parallaxEffect, -1 * deltaMovement.y * parallaxEffect, 0);

        lastCameraPosition = cameraTransform.position;
    }
}
