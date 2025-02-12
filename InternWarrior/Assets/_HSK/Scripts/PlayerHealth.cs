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
        HP = maxHP; // �⺻ü�� �ִ��
    }

    public void Heal(int amount)
    {
        HP = Mathf.Min(HP + amount, maxHP);
        Debug.Log("ü�� ȸ����" + amount);
        Debug.Log("����ü��" + HP);
    }

    public void Damage(int amount)
    {
        HP -= amount;
        if (HP < 0)
        {
            HP = 0;
        }
        Debug.Log("ü�� ����" + amount);
        Debug.Log("����ü��" + HP);
    }
}