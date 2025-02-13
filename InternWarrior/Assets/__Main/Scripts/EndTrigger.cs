using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EndTrigger : MonoBehaviour
{
    public GameObject coverObject;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            coverObject.GetComponent<SpriteRenderer>().color = Color.white;
            coverObject.SetActive(true);

            StartCoroutine(GameClear());
        }
    }
    public IEnumerator GameClear()
    {
        yield return new WaitForSeconds(5.0f);
        DOTween.KillAll();
        SceneManager.LoadScene("3 GameClear");
    }

}
