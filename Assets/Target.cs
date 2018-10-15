using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {

    public float health = 50f;
    public Text healthBox;
    //public Sprite healthBar;

    public void Start()
    {
        healthBox = GetComponent<Text>();
        healthBox = Text.FindObjectOfType<Text>();
        //healthBar = GetComponent<Sprite>();
    }

    private void Update()
    {
        healthBox.text = health.ToString();
    }

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
