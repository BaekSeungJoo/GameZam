using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerBacchus : MonoBehaviour
{
    public int maxBacchus = 10; // ��ī�� �ִ� ������
    public int haveBacchus;

    // Start is called before the first frame update
    private void Start()
    {
        haveBacchus = 0; //�ʱ� ������    
    }

    public void GetBacchus(int amount)
    {
        haveBacchus = Mathf.Min(haveBacchus + amount, maxBacchus);
        Debug.Log("��ī�� ȹ����" + haveBacchus);
    }

}