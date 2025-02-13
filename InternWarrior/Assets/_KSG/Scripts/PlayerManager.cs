using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private bool isStunning = false;
    private float stunTime = 0.0f;

    public void GetBacchus(int amount)
    {
        weaponCount = Mathf.Min(weaponCount + amount, weaponMax);
        Debug.Log("박카스 획득함" + weaponCount);
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
}
