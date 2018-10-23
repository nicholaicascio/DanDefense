using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Debug.Log("Enemy is ded");
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
