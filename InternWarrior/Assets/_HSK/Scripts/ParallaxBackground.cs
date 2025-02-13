using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cameraTransform;  // 카메라 참조
    public float parallaxEffect = 0.01f; // 배경 이동 비율 (0.1~0.5 사이 추천)

    private Vector3 lastCameraPosition;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform; // 메인 카메라 가져오기

        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        // 카메라 이동 방향의 반대 방향으로 배경 이동
        transform.position += new Vector3(-1 * deltaMovement.x * parallaxEffect, -1 * deltaMovement.y * parallaxEffect, 0);

        lastCameraPosition = cameraTransform.position;
    }
}
