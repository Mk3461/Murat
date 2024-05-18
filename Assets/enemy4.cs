using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class enemy4 : MonoBehaviour
{
    public Animator animator;
    public int maxHealth;
    public int currentHealth;
    Dusman4AI enemy4ai;
    private Rigidbody2D rb;
   
    void Start()
    {
        currentHealth=maxHealth;
        enemy4ai=GetComponent<Dusman4AI>();
          
    }
    public void TakeDamage(int damage)
    {
        if (animator.GetBool("Hurt") ==false && !enemy4ai.isDead)
        {
            currentHealth -= damage;
            animator.SetBool("Hurt", true);

            if (currentHealth <= 0)
            {
                Die();
            }
            StartCoroutine(ResetHurt());
            animator.SetBool("isWalking", false);
        }
    }
    IEnumerator ResetHurt()
    {
        if (enemy4ai.isDead == false)
        {
            yield return new WaitForSeconds(0.2f); // Hurt animasyonunun süresini bekle
            animator.SetBool("Hurt", false);
            animator.SetBool("isWalking", true); // Yürüyüþ animasyonunu tekrar baþlat
        }
    }
    public void Die()
    {
        enemy4ai.isDead = true;
        enemy4ai.leftrightspeed = 0;
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2f);
        this.enabled = false;
        StartCoroutine(ResetDead());
    }
    IEnumerator ResetDead()
    {
        if (enemy4ai.isDead == true)
        {
            yield return new WaitForSeconds(0.2f); // Hurt animasyonunun süresini bekle
            animator.SetBool("Hurt", false);
            
        }
    }
}
