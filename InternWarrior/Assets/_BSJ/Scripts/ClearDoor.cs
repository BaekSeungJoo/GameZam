using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDoor : MonoBehaviour
{
    /// <summary>
    /// Ŭ���� ������ �̵�
    /// </summary>
    public void MoveClearScene()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("3 GameClear");
    }
}
