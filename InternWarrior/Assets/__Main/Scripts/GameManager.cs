using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 게임 엔딩 씬으로 이동 ( 트윈 제거 )
    /// </summary>
    public void MoveScene_GameEnd()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("2 GameEnd");
    }

    /// <summary>
    /// 게임 클리어 씬으로 이동 ( 트윈 제거 )
    /// </summary>
    public void MoveScene_GameClear()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("3 GameClear");
    }
}
