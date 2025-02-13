using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class IntroManager : MonoBehaviour
{
    public GameObject[] objects; // 3개의 게임 ?��브젝?���? 배열�? 캐싱
    private int currentIndex = 0;

    void Start()
    {
        // ?��?��?��
        SoundController.PlayBGMSound("main");

        // 초기 ?��?�� ?��?��
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == 0);
        }
    }

    void Update()
    {
        if (Input.anyKeyDown) // ?���? ?��?�� ?��????�� ?��
        {
            SwitchObject();
        }
    }

    void SwitchObject()
    {
        // ?��과음
        SoundController.PlaySFXSound("ui-button");

        // ????��??? ?��?���? ?��?��
        if(currentIndex >= 2)
        {
            DOTween.KillAll();
            SceneManager.LoadScene("0 Title");
        }

        else
        {
            // ?��?�� ?��브젝?�� 비활?��?��
            objects[currentIndex].SetActive(false);

            // ?��?�� ?��?��?���? ?��?��
            currentIndex = (currentIndex + 1) % objects.Length;

            // ?��?�� ?��브젝?�� ?��?��?��
            objects[currentIndex].SetActive(true);
        }
    }
}
