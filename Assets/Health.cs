using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Health : NetworkBehaviour
{

    public const int maxHealth = 100;

    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;

    public Text healthBar;

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        currentHealth -= amount;
        Debug.Log("took damage");
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //Debug.Log("Dead!");
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnChangeHealth(int health)
    {
        //healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
        healthBar.text = health.ToString();
    }
}