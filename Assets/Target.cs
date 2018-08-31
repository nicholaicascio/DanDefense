using UnityEngine;

public class Target : MonoBehaviour {

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
