using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool isStunning = false;
    private float stunTime = 0.0f;

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
