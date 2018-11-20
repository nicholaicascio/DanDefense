using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class healthv2 : NetworkBehaviour {

    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")] public int currentHealth = maxHealth;
    public RectTransform healthBar;

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("dead");
        }
    }

    void OnChangeHealth(int Health)
    {
        //currentHealth -= 10;
        //healthBar.text = Health.ToString();
        healthBar.sizeDelta = new Vector2(currentHealth * 2, healthBar.sizeDelta.y);
    }
}
