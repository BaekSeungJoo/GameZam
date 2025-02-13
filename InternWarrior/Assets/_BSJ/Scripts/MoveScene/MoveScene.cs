using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public string sceneName = string.Empty;

    public void SceneMove()
    {
        SceneManager.LoadScene(sceneName);
    }
}
