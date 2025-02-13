using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayUIManager : MonoBehaviour
{
    [Header("���� �ؽ�Ʈ")]
    public TextMeshProUGUI Text_Coin;

    [Header("���ڿ� �ؽ�Ʈ")]
    public TextMeshProUGUI Text_Alcohol;

    [Header("��ī�� �ؽ�Ʈ")]
    public TextMeshProUGUI Text_Bacchus;

    [Header("ī��Ű �̹���")]
    public GameObject keyObject;

    /// <summary>
    /// ������ �ؽ�Ʈ�� �����ϴ� �Լ�
    /// </summary>
    public void Change_CoinText(int coinCount)
    {
        Text_Coin.text = coinCount.ToString();
    }

    /// <summary>
    /// ���ڿ��� �ؽ�Ʈ�� �����ϴ� �Լ�
    /// </summary>
    public void Change_AlcoholText(int alcoholCount)
    {
        Text_Alcohol.text = alcoholCount.ToString();
    }

    /// <summary>
    /// ��ī���� �ؽ�Ʈ�� �����ϴ� �Լ�
    /// </summary>
    public void Change_BacchusText(int bacchusCount)
    {
        Text_Bacchus.text = bacchusCount.ToString();
    }

    /// <summary>
    /// ī��Ű�� �����ִ� �Լ�
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
