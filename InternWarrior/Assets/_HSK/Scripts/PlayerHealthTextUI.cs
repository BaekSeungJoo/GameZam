using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthTextUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    private void Start()
    { }

    // Update is called once per frame
    private void Update()
    {
        if (playerHealth != null && healthText != null)
        {
            healthText.text = "HP" + playerHealth.HP + " / " + playerHealth.maxHP;

        }

    }
}
