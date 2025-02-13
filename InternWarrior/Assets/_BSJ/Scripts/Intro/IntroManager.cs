using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class IntroManager : MonoBehaviour
{
    public GameObject[] objects; // 3ê°œì˜ ê²Œì„ ?˜¤ë¸Œì ?Š¸ë¥? ë°°ì—´ë¡? ìºì‹±
    private int currentIndex = 0;

    void Start()
    {
        // SoundManager¸¦ Ã£¾Æ¼­ Ä³½Ì
        SoundManager soundManager = FindObjectOfType<SoundManager>();

        // SoundManager°¡ Á¸ÀçÇÑ´Ù¸é À½¼Ò°Å ÇØÁ¦
        if (soundManager != null)
        {
            soundManager.ToggleTotalMute(false);
        }
        else
        {
            Debug.LogWarning("SoundManager¸¦ Ã£À» ¼ö ¾ø½À´Ï´Ù.");
        }
        
        // ?‚¬?š´?“œ
        SoundController.PlayBGMSound("main");

        // ì´ˆê¸° ?ƒ?ƒœ ?„¤? •
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == 0);
        }
    }

    void Update()
    {
        if (Input.anyKeyDown) // ?•„ë¬? ?‚¤?‚˜ ?ˆŒ????„ ?•Œ
        {
            SwitchObject();
        }
    }

    void SwitchObject()
    {
        // ?š¨ê³¼ìŒ
        SoundController.PlaySFXSound("ui-button");

        // ????´??? ?”¬?œ¼ë¡? ?´?™
        if(currentIndex >= 2)
        {
            DOTween.KillAll();
            SceneManager.LoadScene("0 Title");
        }

        else
        {
            // ?˜„?¬ ?˜¤ë¸Œì ?Š¸ ë¹„í™œ?„±?™”
            objects[currentIndex].SetActive(false);

            // ?‹¤?Œ ?¸?±?Š¤ë¡? ?´?™
            currentIndex = (currentIndex + 1) % objects.Length;

            // ?‹¤?Œ ?˜¤ë¸Œì ?Š¸ ?™œ?„±?™”
            objects[currentIndex].SetActive(true);
        }
    }
}
