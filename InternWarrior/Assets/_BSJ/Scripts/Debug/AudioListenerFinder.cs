using UnityEngine;

public class AudioListenerFinder : MonoBehaviour
{
    void Start()
    {
        // �� ���� ��� ����� ������ ã��
        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

        // ����� �����ʰ� �� �� �̻� �ִ� ��� ��� �޽��� ���
        if (audioListeners.Length > 1)
        {
            Debug.LogWarning("����� �����ʰ� �� �� �̻� �����մϴ�. ���� ������Ʈ���� �߰ߵǾ����ϴ�:");

            foreach (AudioListener listener in audioListeners)
            {
                Debug.Log("����� ������ ��ġ: " + listener.gameObject.name);
            }
        }
        else
        {
            Debug.Log("����� �����ʴ� �ϳ��� �����մϴ�.");
        }
    }
}
