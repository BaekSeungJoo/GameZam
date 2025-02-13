using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
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

    [Header("���Ͻ� ȸ���ð�")]
    public float stunEffectSec = 1.0f;

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

    [Header("�÷��� UI �Ŵ��� ����")]
    public PlayUIManager playUIManager;

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
    private SpriteRenderer playerSpriteRenderer;
    private Color originalColor;

    private void Start()
    {
        // ����Ʈ ���μ��� �ʱ�ȭ
        ChangeWindow(alcholCurrent);
        // �÷��̾� ���ӿ�����Ʈ ã��
        player = GameObject.Find("Player");

        // �÷��̾� ��������Ʈ ����
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        // �÷��̾� �������� ����
        originalColor = playerSpriteRenderer.color;

        // ������ �ʱ�ȭ
        playerHp = playerMaxHp;
        weaponCount = 0;
        alcholCurrent = 0;

        // ������ UI�� ����
        InitPlayUI();
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

                // UI ������Ʈ
                InitPlayUI();

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

        // UI ������Ʈ
        InitPlayUI();
    }

    public void GetAlcohol(int amount)
    {
        alcholCurrent = Mathf.Min(alcholCurrent + amount, alcholMax);
        Debug.Log("���ڿ� ȹ����" + alcholCurrent);

        // ���ڿ� ����Ʈ ���μ���
        ChangeWindow(alcholCurrent);

        // ���� ���� üũ
         StartCoroutine(GameOverCheck());

        // ���� ����
        isAlchol = true;
        currentAlcholCancelTime = 0f;

        // UI ������Ʈ
        InitPlayUI();
    }

    public void Heal(int amount)
    {
        playerHp = Mathf.Min(playerHp + amount, playerMaxHp);
        Debug.Log("ü�� ȸ����" + amount);
        Debug.Log("����ü��" + playerHp);

        // UI ������Ʈ
        InitPlayUI();
    }

    public void Damage(int amount)
    {
        // ȿ���� ���
        SoundController.PlaySFXSound("hit");

        playerHp -= amount;
        if (playerHp < 0)
        {
            playerHp = 0;
        }
        Debug.Log("ü�� ����" + amount);
        Debug.Log("����ü��" + playerHp);

        // ������� 1�� ��ȯ
        TurnGreyFlick();

        // UI ������Ʈ
        InitPlayUI();

        // ���� ���� üũ
         StartCoroutine(GameOverCheck());
    }

     public void TurnGreyFlick()
    {
        StopAllCoroutines(); // ���� �ڷ�ƾ ����
        StartCoroutine(TurnGreyCoroutine());
    }

    private IEnumerator TurnGreyCoroutine()
    {
        Color greyColor = Color.grey;

        // ������� ����
        for (int i = 0; i < 3; i++)
        {
            // ������� ����
            playerSpriteRenderer.color = greyColor;
            yield return new WaitForSeconds(0.1f);

            // ���� ����� ����
            playerSpriteRenderer.color = originalColor;
            yield return new WaitForSeconds(0.1f);
        }

        // ���� ����� ����
        playerSpriteRenderer.color = originalColor;
    }

    public void TurnGreyForOneSecond()
    {
        StartCoroutine(TurnGreyOneCoroutine());
    }

    private IEnumerator TurnGreyOneCoroutine()
    {
        Color greyColor = Color.grey;

        // ������� ����
        playerSpriteRenderer.color = greyColor;
        yield return new WaitForSeconds(stunEffectSec);

        // ���� ����� ����
        playerSpriteRenderer.color = originalColor;
    }



    public void SetStun(bool stun)
    {
        isStunning = stun;

        if(isStunning)
            TurnGreyForOneSecond();
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
    /// �÷��� UI�� �ʱ�ȭ �ϴ� �Լ�
    /// </summary>
    public void InitPlayUI()
    {
        playUIManager.Change_CoinText(playerHp);
        playUIManager.Change_AlcoholText(alcholCurrent);
        playUIManager.Change_BacchusText(weaponCount);
        playUIManager.Show_CardKey(keyCount);

         StartCoroutine(GameOverCheck());
    }

    /// <summary>
    /// ���� ���� üũ
    /// </summary>
    public IEnumerator GameOverCheck()
    {
        if (playerHp <= 0 || alcholCurrent >= 5)
        {
            player.GetComponent<PlayerMove>().PlayerDead();
            yield return new WaitForSeconds(4.0f);

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
