using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    public int damage = 10;
    public int playersDamage = 25;
    public int currentHealth;
    public int maxHealth;

    private Transform target;

    

    void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - (Vector2)transform.position-new Vector2(0,1.4f);
            direction.Normalize();// birim vektör olmayý saðlar.
            transform.Translate(direction * speed * Time.deltaTime, Space.World);//direction yönüne doðru hareketi saðlar.
            animator.SetBool("Hurt", false);
        }
    }
    public void TakeDamage(int playersDamage)
    {
        
        
            currentHealth -= playersDamage;
            animator.SetBool("Hurt", true);

            if (currentHealth <= 0)
            {
                Die();
            }
           
  
    }
   void  Die()
    {
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 0.3f);
        this.enabled = false;
    }
    void GiveDamage(Collider2D collison)
    {
        if (collison.CompareTag("Player"))// p1,p2,p3,p4 ü playerlardan compenent ile al ve ondan sonra kullan.
        {
            if (target.name =="Fire_Knight")
            {
                /*
                if (p1.currentHealth > 0)
                { }
                    p1.takeDamage(damage);//
                    animator.SetBool("Explosion", true);
                    Destroy(gameObject);
                }
                */
            }
            else if(target.name == "Leaf_Ranger")
            {
                //if (p2.currentHealth > 0)
                //{
                //p2.takeDamage(damage);//
                //animator.SetBool("Explosion", true);
                //Destroy(gameObject);
                //}
            }
            else if (target.name == "Water_Priestess")
            {
                //if (p3.currentHealth > 0)
                //{
                //p3.takeDamage(damage);//
                //animator.SetBool("Explosion", true);
                //Destroy(gameObject);
                //}
            }
            else if (target.name == "Wind_Hashashin")
            {
                //if (p4.currentHealth > 0)
                //{
                //p4.takeDamage(damage);//
                //animator.SetBool("Explosion", true);
                //Destroy(gameObject);
                //}
            }
        }
    }
}