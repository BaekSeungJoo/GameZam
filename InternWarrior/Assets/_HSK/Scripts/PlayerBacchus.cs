using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerBacchus : MonoBehaviour
{
    public int maxBacchus = 10; // 박카스 최대 소지량
    public int haveBacchus;

    // Start is called before the first frame update
    private void Start()
    {
        haveBacchus = 0; //초기 소지량    
    }

    public void GetBacchus(int amount)
    {
        haveBacchus = Mathf.Min(haveBacchus + amount, maxBacchus);
        Debug.Log("박카스 획득함" + haveBacchus);
    }

}