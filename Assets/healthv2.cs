﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class healthv2 : NetworkBehaviour {

    public int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")] public int currentHealth;
  
    public RectTransform healthBar;

    public void TakeDamage(int amount)
    {
        /*
        if (!isServer)
        {
            return;
        }
        */
        currentHealth -= amount;
        Debug.Log("subtracted from health in TakeDamage");
       
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(transform.gameObject);
            Debug.Log("dead");
        }
    }

    void OnChangeHealth(int hp)
    {
        //currentHealth -= 10;
        //healthBar.text = Health.ToString();
        //currentHealth = hp;
        healthBar.sizeDelta = new Vector2(hp * 2, healthBar.sizeDelta.y);
        Debug.Log("healthbar changed size");
    }
    [Command]
    public void CmdTakeDamage(int amount) //maybe take damage locally then call command take damage (this)
    {
        if (!isServer)
        {
            Debug.Log("Server taking damage");
            TakeDamage(amount);
            OnChangeHealth(currentHealth);
        }
        //if (!isServer)
        {
           // OnChangeHealth(amount);

            RpcTakeDamage(amount);
            Debug.Log("cmdtakedagame");
        }
    }
    [ClientRpc]
    public void RpcTakeDamage(int amount)
    {
        TakeDamage(amount);
        OnChangeHealth(currentHealth);
        Debug.Log("rpctakedamage ");
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }
}