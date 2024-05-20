using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy5 : MonoBehaviour
{
    public Animator animator;
    public int maxHealth=50;
    public int currentHealth;
    Dusman5AI enemy5ai;
    private bool isDead = false;
    void Start()
    {
        currentHealth = maxHealth;
        enemy5ai = GetComponent<Dusman5AI>();
    }
    public void TakeDamage(int damage)
    {
        if (isDead) return;
         
        currentHealth-=damage;
            animator.SetTrigger("Hurt");//

            if(currentHealth <= 0) 
            {
                Die();            
            }
            //StartCoroutine(ResetHurt());
        
    }
  /*
    IEnumerator ResetHurt() {
      
            yield return new WaitForSeconds(0.2f);
            animator.SetBool("Hurt", false);
           
        
    }
   */
    public void Die()
    {
        isDead= true;
        animator.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2f);
        this.enabled = false;
      //StartCoroutine(ResetDead());
    }
    /*
    
    IEnumerator ResetDead()
    {
        
            yield return new WaitForSeconds(0.2f); // Hurt animasyonunun süresini bekle
            animator.SetBool("Hurt", false);

    }
*/
}

