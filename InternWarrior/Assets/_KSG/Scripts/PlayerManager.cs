using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private bool isStunning = false;
    private float stunTime = 0.0f;

    public void GetBacchus(int amount)
    {
        weaponCount = Mathf.Min(weaponCount + amount, weaponMax);
        Debug.Log("��ī�� ȹ����" + weaponCount);
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
