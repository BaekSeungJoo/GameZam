using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class IntroManager : MonoBehaviour
{
    public GameObject[] objects; // 3개의 게임 오브젝트를 배열로 캐싱
    private int currentIndex = 0;

    void Start()
    {
        // 사운드
        SoundController.PlayBGMSound("1-stage bgm");

        // 초기 상태 설정
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == 0);
        }
    }

    void Update()
    {
        if (Input.anyKeyDown) // 아무 키나 눌렀을 때
        {
            SwitchObject();
        }
    }

    void SwitchObject()
    {
        // 효과음
        SoundController.PlaySFXSound("ui-button");

        // 타이틀 씬으로 이동
        if(currentIndex >= 2)
        {
            DOTween.KillAll();
            SceneManager.LoadScene("0 Title");
        }

        else
        {
            // 현재 오브젝트 비활성화
            objects[currentIndex].SetActive(false);

            // 다음 인덱스로 이동
            currentIndex = (currentIndex + 1) % objects.Length;

            // 다음 오브젝트 활성화
            objects[currentIndex].SetActive(true);
        }
    }
}
