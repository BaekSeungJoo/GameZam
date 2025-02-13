using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject coverObject;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            coverObject.GetComponent<SpriteRenderer>().color = Color.white;
            coverObject.SetActive(true);
        }
    }
}
