using System.Collections;
using System.Collections.Generic;
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

    [Header("포스트 프로세싱 볼륨 참조")]
    public Volume postProcessingVolume;

    private Vignette vignette;
    private LensDistortion lensDistortion;


    private bool isStunning = false;
    private float stunTime = 0.0f;
    private string weaponDir;
    private float moveSpeed;

    private void Start()
    {
        // 포스트 프로세싱 초기화
        ChangeWindow(alcholCurrent);
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
    }

    public void GetAlcohol(int amount)
    {
        alcholCurrent = Mathf.Min(alcholCurrent + amount, alcholMax);
        Debug.Log("알코올 획득함" + alcholCurrent);

        // 알코올 포스트 프로세싱
        ChangeWindow(alcholCurrent);
    }

    public void Heal(int amount)
    {
        playerHp = Mathf.Min(playerHp + amount, playerMaxHp);
        Debug.Log("체력 회복됨" + amount);
        Debug.Log("현재체력" + playerHp);
    }

    public void Damage(int amount)
    {
        playerHp -= amount;
        if (playerHp < 0)
        {
            playerHp = 0;
        }
        Debug.Log("체력 까임" + amount);
        Debug.Log("현재체력" + playerHp);
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
    }
}
