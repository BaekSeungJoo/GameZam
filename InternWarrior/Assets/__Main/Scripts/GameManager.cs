using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// ���� ���� ������ �̵� ( Ʈ�� ���� )
    /// </summary>
    public void MoveScene_GameEnd()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("2 GameEnd");
    }

    /// <summary>
    /// ���� Ŭ���� ������ �̵� ( Ʈ�� ���� )
    /// </summary>
    public void MoveScene_GameClear()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("3 GameClear");
    }
}
