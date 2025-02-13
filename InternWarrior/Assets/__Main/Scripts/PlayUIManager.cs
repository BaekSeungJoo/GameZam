using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayUIManager : MonoBehaviour
{
    [Header("코인 텍스트")]
    public TextMeshProUGUI Text_Coin;

    [Header("알코올 텍스트")]
    public TextMeshProUGUI Text_Alcohol;

    [Header("박카스 텍스트")]
    public TextMeshProUGUI Text_Bacchus;

    [Header("카드키 이미지")]
    public GameObject keyObject;

    /// <summary>
    /// 코인의 텍스트를 변경하는 함수
    /// </summary>
    public void Change_CoinText(int coinCount)
    {
        Text_Coin.text = coinCount.ToString();
    }

    /// <summary>
    /// 알코올의 텍스트를 변경하는 함수
    /// </summary>
    public void Change_AlcoholText(int alcoholCount)
    {
        Text_Alcohol.text = alcoholCount.ToString();
    }

    /// <summary>
    /// 박카스의 텍스트를 변경하는 함수
    /// </summary>
    public void Change_BacchusText(int bacchusCount)
    {
        Text_Bacchus.text = bacchusCount.ToString();
    }

    /// <summary>
    /// 카드키를 보여주는 함수
    /// </summary>
    public void Show_CardKey(int keyCount)
    {
        if(keyCount > 0)
        {
            keyObject.SetActive(true);
        }
        else
        {
            keyObject.SetActive(false);
        }
    }
}
