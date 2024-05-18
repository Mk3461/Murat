using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 50;
    public int currentHealth;
    Dusman3AI enemy3ai;

    void Start()
    {
        currentHealth = maxHealth;
        enemy3ai = GetComponent<Dusman3AI>();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        
        Debug.Log("Enemy Died!");
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2f);
        this.enabled = false;
    }
}
