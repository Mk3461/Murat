using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public Animator animator;
    
    public int maxHealth = 100;
    int currentHealth;

    Dusman1AI enemy1ai;
    
    void Start()
    {
        //Collider2D enemy = GetComponent<Collider2D>();
        currentHealth = maxHealth;
        enemy1ai=GetComponent<Dusman1AI>();
    }
    public void TakeDamage(int damage)
    {
        currentHealth-=damage;
        animator.SetTrigger("Hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        enemy1ai.leftrightspeed = 0;
        Debug.Log("Enemy died!");
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2f);
        enemy1ai.followspeed = 0;
        this.enabled = false;
       
    }
}