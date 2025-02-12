using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool isStunning = false;
    private float stunTime = 0.0f;

    public void SetStun(float time)
    {
        isStunning = true;
        stunTime += time;
    }
    public bool GetStun()
    {
        return isStunning;
    }

    public float GetStunTime()
    {
        return stunTime;
    }
}
