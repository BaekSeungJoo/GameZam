using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    [Header("점프횟수")]
    public int maxJump = 0;

    [Header("플레이어 현재HP")]
    public int playerHp = 10;

    [Header("플레이어 최대HP")]
    public int playerMaxHp = 10;

    [Header("스턴시 회색시간")]
    public float stunEffectSec = 1.0f;

    [Header("박카스 현재갯수")]
    public int weaponCount = 0;

    [Header("박카스 최대갯수")]
    public int weaponMax = 5;

    [Header("열쇠 카운트")]
    public int keyCount = 0;

    [Header("현재 알코올")]
    public int alcholCurrent = 0;

    [Header("알코올 최댓값")]
    public int alcholMax = 5;

    [Header("취함상태 해제 리미트 시간")]
    public float alcholLimitTime = 10f;

    [Header("현재 취함상태 해제 시간")]
    public float currentAlcholCancelTime = 0f;

    [Header("취함 상태인지 체크")]
    public bool isAlchol = false;

    [Header("포스트 프로세싱 볼륨 참조")]
    public Volume postProcessingVolume;

    private Vignette vignette;
    private LensDistortion lensDistortion;
    private ChromaticAberration chromaticAberration;

    [Header("플레이 UI 매니저 참조")]
    public PlayUIManager playUIManager;

    [Header("게임매니저 참조 (게임오버 관련)")]
    public GameManager gameManager;

    [Header("트리가드 참조")]
    public GameObject guard;

    [Header("트리가드 X 오프셋")]
    public float xOffset = -0.5f;
    [Header("트리가드 Y 오프셋")]
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
        // 포스트 프로세싱 초기화
        ChangeWindow(alcholCurrent);
        // 플레이어 게임오브젝트 찾기
        player = GameObject.Find("Player");

        // 플레이어 스프라이트 연동
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        // 플레이어 원래색깔 저장
        originalColor = playerSpriteRenderer.color;

        // 데이터 초기화
        playerHp = playerMaxHp;
        weaponCount = 0;
        alcholCurrent = 0;

        // 데이터 UI와 연동
        InitPlayUI();
    }

    private void Update()
    {
        // 취함 상태 라면
        if (isAlchol)
        {
            // 알코올 해제 타이머가 작동되고
            currentAlcholCancelTime += Time.deltaTime;

            // 알코올 해제 타임이 되면 알코올 수치를 1 감소시킨다. ( 취함 상태 해제 될 동안 계속 )
            if (currentAlcholCancelTime >= alcholLimitTime)
            {
                --alcholCurrent;
                currentAlcholCancelTime = 0f;

                // UI 업데이트
                InitPlayUI();

                // 포스트 프로세싱 재 설정
                ChangeWindow(alcholCurrent);

                // 알코올 카운트가 0이면 취함상태 완전 해제
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
        Debug.Log("박카스 획득함" + weaponCount);

        // UI 업데이트
        InitPlayUI();
    }

    public void GetAlcohol(int amount)
    {
        alcholCurrent = Mathf.Min(alcholCurrent + amount, alcholMax);
        Debug.Log("알코올 획득함" + alcholCurrent);

        // 알코올 포스트 프로세싱
        ChangeWindow(alcholCurrent);

        // 게임 오버 체크
         StartCoroutine(GameOverCheck());

        // 취함 적용
        isAlchol = true;
        currentAlcholCancelTime = 0f;

        // UI 업데이트
        InitPlayUI();
    }

    public void Heal(int amount)
    {
        playerHp = Mathf.Min(playerHp + amount, playerMaxHp);
        Debug.Log("체력 회복됨" + amount);
        Debug.Log("현재체력" + playerHp);

        // UI 업데이트
        InitPlayUI();
    }

    public void Damage(int amount)
    {
        // 효과음 재생
        SoundController.PlaySFXSound("hit");

        playerHp -= amount;
        if (playerHp < 0)
        {
            playerHp = 0;
        }
        Debug.Log("체력 까임" + amount);
        Debug.Log("현재체력" + playerHp);

        // 흑백으로 1초 변환
        TurnGreyFlick();

        // UI 업데이트
        InitPlayUI();

        // 게임 오버 체크
         StartCoroutine(GameOverCheck());
    }

     public void TurnGreyFlick()
    {
        StopAllCoroutines(); // 이전 코루틴 중지
        StartCoroutine(TurnGreyCoroutine());
    }

    private IEnumerator TurnGreyCoroutine()
    {
        Color greyColor = Color.grey;

        // 흑백으로 변경
        for (int i = 0; i < 3; i++)
        {
            // 흑백으로 변경
            playerSpriteRenderer.color = greyColor;
            yield return new WaitForSeconds(0.1f);

            // 원래 색깔로 복원
            playerSpriteRenderer.color = originalColor;
            yield return new WaitForSeconds(0.1f);
        }

        // 원래 색깔로 복원
        playerSpriteRenderer.color = originalColor;
    }

    public void TurnGreyForOneSecond()
    {
        StartCoroutine(TurnGreyOneCoroutine());
    }

    private IEnumerator TurnGreyOneCoroutine()
    {
        Color greyColor = Color.grey;

        // 흑백으로 변경
        playerSpriteRenderer.color = greyColor;
        yield return new WaitForSeconds(stunEffectSec);

        // 원래 색깔로 복원
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
    /// 플레이 UI를 초기화 하는 함수
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
    /// 게임 오버 체크
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
    /// 알코올 값에 따라서 화면이 변하도록 하게함
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
                        // Lens Distortion 설정
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
                        // Vignette 설정
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

        // Chromatic Aberration 설정
        if (postProcessingVolume != null)
        {
            // Chromatic Aberration 설정
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
