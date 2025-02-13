using UnityEngine;

public class AudioListenerFinder : MonoBehaviour
{
    void Start()
    {
        // 씬 내의 모든 오디오 리스너 찾기
        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

        // 오디오 리스너가 두 개 이상 있는 경우 경고 메시지 출력
        if (audioListeners.Length > 1)
        {
            Debug.LogWarning("오디오 리스너가 두 개 이상 존재합니다. 다음 오브젝트에서 발견되었습니다:");

            foreach (AudioListener listener in audioListeners)
            {
                Debug.Log("오디오 리스너 위치: " + listener.gameObject.name);
            }
        }
        else
        {
            Debug.Log("오디오 리스너는 하나만 존재합니다.");
        }
    }
}
