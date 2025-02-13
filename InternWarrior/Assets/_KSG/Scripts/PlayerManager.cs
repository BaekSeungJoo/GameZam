using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    [Header("����Ƚ��")]
    public int maxJump = 0;

    [Header("�÷��̾� ����HP")]
    public int playerHp = 10;

    [Header("�÷��̾� �ִ�HP")]
    public int playerMaxHp = 10;

    [Header("��ī�� ���簹��")]
    public int weaponCount = 0;

    [Header("��ī�� �ִ밹��")]
    public int weaponMax = 5;

    [Header("���� ī��Ʈ")]
    public int keyCount = 0;

    [Header("���� ���ڿ�")]
    public int alcholCurrent = 0;

    [Header("���ڿ� �ִ�")]
    public int alcholMax = 5;

    [Header("���Ի��� ���� ����Ʈ �ð�")]
    public float alcholLimitTime = 10f;

    [Header("���� ���Ի��� ���� �ð�")]
    public float currentAlcholCancelTime = 0f;

    [Header("���� �������� üũ")]
    public bool isAlchol = false;

    [Header("����Ʈ ���μ��� ���� ����")]
    public Volume postProcessingVolume;

    private Vignette vignette;
    private LensDistortion lensDistortion;
    private ChromaticAberration chromaticAberration;

    [Header("���ӸŴ��� ���� (���ӿ��� ����)")]
    public GameManager gameManager;

    [Header("Ʈ������ ����")]
    public GameObject guard;

    [Header("Ʈ������ X ������")]
    public float xOffset = -0.5f;
    [Header("Ʈ������ Y ������")]
    public float yOffset = 0.8f;

    private bool isStunning = false;
    private float stunTime = 0.0f;
    private string weaponDir;
    private float moveSpeed;
    private GameObject player;

    private void Start()
    {
        // ����Ʈ ���μ��� �ʱ�ȭ
        ChangeWindow(alcholCurrent);
        // �÷��̾� ���ӿ�����Ʈ ã��
        player = GameObject.Find("Player");

    }

    private void Update()
    {
        // ���� ���� ���
        if (isAlchol)
        {
            // ���ڿ� ���� Ÿ�̸Ӱ� �۵��ǰ�
            currentAlcholCancelTime += Time.deltaTime;

            // ���ڿ� ���� Ÿ���� �Ǹ� ���ڿ� ��ġ�� 1 ���ҽ�Ų��. ( ���� ���� ���� �� ���� ��� )
            if (currentAlcholCancelTime >= alcholLimitTime)
            {
                --alcholCurrent;
                currentAlcholCancelTime = 0f;

                // ����Ʈ ���μ��� �� ����
                ChangeWindow(alcholCurrent);

                // ���ڿ� ī��Ʈ�� 0�̸� ���Ի��� ���� ����
                if (alcholCurrent <= 0)
                {
                    alcholCurrent = 0;
                    isAlchol = false;
                }
            }
        }
    }

    public void SpawnTreeGuard()
    {
        GameObject guardObj = Instantiate(guard, new Vector3(xOffset,yOffset,0), Quaternion.identity);
        guardObj.transform.SetParent(player.transform, false);
    }

    public void SetPlayerSpeed(float value)
    {
        moveSpeed = value;
    }
    public float GetPlayerSpeed()
    {
        return moveSpeed;
    }
    public void SetWeaponDir(string dir)
    {
        weaponDir = dir;
    }
    public string GetWeaponDir()
    {
        return weaponDir;
    }

    public void GetBacchus(int amount)
    {
        weaponCount = Mathf.Min(weaponCount + amount, weaponMax);
        Debug.Log("��ī�� ȹ����" + weaponCount);
    }

    public void GetAlcohol(int amount)
    {
        alcholCurrent = Mathf.Min(alcholCurrent + amount, alcholMax);
        Debug.Log("���ڿ� ȹ����" + alcholCurrent);

        // ���ڿ� ����Ʈ ���μ���
        ChangeWindow(alcholCurrent);

        // ���� ���� üũ
        GameOverCheck();

        // ���� ����
        isAlchol = true;
        currentAlcholCancelTime = 0f;
    }

    public void Heal(int amount)
    {
        playerHp = Mathf.Min(playerHp + amount, playerMaxHp);
        Debug.Log("ü�� ȸ����" + amount);
        Debug.Log("����ü��" + playerHp);
    }

    public void Damage(int amount)
    {
        playerHp -= amount;
        if (playerHp < 0)
        {
            playerHp = 0;
        }
        Debug.Log("ü�� ����" + amount);
        Debug.Log("����ü��" + playerHp);

        // ���� ���� üũ
        GameOverCheck();
    }

    public void SetStun(bool stun)
    {
        isStunning = stun;
    }
    public bool GetStun()
    {
        return isStunning;
    }

    public void SetStunTime(float time)
    {
        stunTime = time;
    }
    public float GetStunTime()
    {
        return stunTime;
    }

    /// <summary>
    /// ���ڿ� �� ���̴� �Լ�
    /// </summary>
    public void DecreaseAlcohol()
    {

    }

    /// <summary>
    /// ���� ���� üũ
    /// </summary>
    public void GameOverCheck()
    {
        if (playerHp <= 0 || alcholCurrent >= 5)
        {
            gameManager.MoveScene_GameEnd();
        }
    }

    /// <summary>
    /// ���ڿ� ���� ���� ȭ���� ���ϵ��� �ϰ���
    /// </summary>
    public void ChangeWindow(int alchol)
    {
        if (postProcessingVolume != null)
        {
            if (postProcessingVolume.profile.TryGet<LensDistortion>(out lensDistortion))
            {
                switch (alchol)
                {
                    case 0:
                        // Lens Distortion ����
                        lensDistortion.intensity.value = 0f;
                        break;

                    case 1:
                        lensDistortion.intensity.value = -0.2f;
                        break;

                    case 2:
                        lensDistortion.intensity.value = -0.4f;
                        break;

                    case 3:
                        lensDistortion.intensity.value = -0.6f;
                        break;

                    case 4:
                        lensDistortion.intensity.value = -0.8f;
                        break;

                    default:
                        break;
                }
            }
        }

        if (postProcessingVolume != null)
        {
            if (postProcessingVolume.profile.TryGet<Vignette>(out vignette))
            {
                switch (alchol)
                {
                    case 0:
                        // Vignette ����
                        vignette.intensity.value = 0f;
                        break;

                    case 1:
                        vignette.intensity.value = 0.25f;
                        break;

                    case 2:
                        vignette.intensity.value = 0.5f;
                        break;

                    case 3:
                        vignette.intensity.value = 0.75f;
                        break;

                    case 4:
                        vignette.intensity.value = 1f;
                        break;
                    default:
                        break;
                }
            }
        }

        // Chromatic Aberration ����
        if (postProcessingVolume != null)
        {
            // Chromatic Aberration ����
            if (postProcessingVolume.profile.TryGet<ChromaticAberration>(out chromaticAberration))
            {
                switch (alchol)
                {
                    case 0:
                        chromaticAberration.intensity.value = 0f;
                        break;
                    case 1:
                        chromaticAberration.intensity.value = 0.2f;
                        break;
                    case 2:
                        chromaticAberration.intensity.value = 0.4f;
                        break;
                    case 3:
                        chromaticAberration.intensity.value = 0.6f;
                        break;
                    case 4:
                        chromaticAberration.intensity.value = 0.8f;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
