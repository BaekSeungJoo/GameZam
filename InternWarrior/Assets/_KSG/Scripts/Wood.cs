using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wood : MonoBehaviour
{
    WoodGuard woodGuard;

    // Start is called before the first frame update
    void Start()
    {
        woodGuard = GameObject.Find("WoodGuard").GetComponent<WoodGuard>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            woodGuard.StartFade();
        }
    }
}
