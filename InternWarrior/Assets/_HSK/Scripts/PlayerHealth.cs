using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 10;
    public int HP;

    // Start is called before the first frame update
    private void Start()
    {
        HP = maxHP; // 기본체력 최대로
    }

    public void Heal(int amount)
    {
        HP = Mathf.Min(HP + amount, maxHP);
        Debug.Log("체력 회복됨" + amount);
        Debug.Log("현재체력" + HP);
    }

    public void Damage(int amount)
    {
        HP -= amount;
        if (HP < 0)
        {
            HP = 0;
        }
        Debug.Log("체력 까임" + amount);
        Debug.Log("현재체력" + HP);
    }
}