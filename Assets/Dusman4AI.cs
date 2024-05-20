using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Dusman4AI : MonoBehaviour
{
    enemy1 H1;
    enemy3 H3;
    enemy5 H5;
    public Animator animator;
   //private Transform EnemyPos;
    public  float leftrightspeed=0.5f;
    public Vector2 pos1;
    public Vector2 pos2;
    private float oldPosition;
    public Transform healPoint;
    public float healingRange = 2f;
    public LayerMask EnemiesLayer;
    public float timer1 = 0;
    public float timer2 = 0;
    public float timer3 = 0;
    public bool isDead=false;
    

    void Start()
    {
        Physics2D.queriesStartInColliders = false;// oluþturulan colliderý kendisi etkilememesi için kullanýlýr
        animator = GetComponent<Animator>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // EnemyPos = GameObject.FindGameObjectWithTag("Enemys").GetComponent<Transform>();

        H1 = GetComponent<enemy1>();
        H3 = GetComponent<enemy3>();
        H5 = GetComponent<enemy5>();
     
    }


    void Update()
    {
        
        if (animator.GetBool("Hurt")==false) 
        {
           
            EnemyMove();
            EnemyAi();
        }
        
    }
 
    void EnemyMove()
    {
        if(!isDead)
        {
            Vector3 newPosition = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * 0.2f, 1));
            transform.position = newPosition;
            if (transform.position.x > oldPosition)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
            if(transform.position.x < oldPosition) 
            {
                transform.localRotation=Quaternion.Euler(0, 180,0);
            }
            oldPosition = transform.position.x;
            animator.SetBool("isWalking", true);
        }
    }
    void EnemyAi()
    {
        if (!isDead)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(healPoint.position, healingRange, EnemiesLayer);
            foreach (var enemys in enemies)
            {
                enemy1 enemyH1 = enemys.GetComponent<enemy1>();
                enemy3 enemyH3 = enemys.GetComponent<enemy3>();
                enemy5 enemyH5 = enemys.GetComponent<enemy5>();
                // H5 i eklemeyi unutma
                if (enemyH1 != null)  
                    {
                    if (enemyH1 != null)
                    {
                        H1 = enemyH1;
                        leftrightspeed = 0;
                        Heal1();
                    } 
                    
                    }
                    else if (enemyH3 != null)// H5 i eklemeyi unutma 
                    {

                    H3 = enemyH3;
                    leftrightspeed = 0;
                    Heal2();
                       
                  
                    }
                  else if (enemyH5 != null)
                    { 
                       H5=enemyH5;
                       Heal3();
                       leftrightspeed = 0;
                  }

                }
            }
        }
    
        void Heal1()
    {   
       
        timer1 += Time.deltaTime;
        if (timer1 >= 5)
        {


            if (H1.currentHealth > 0 && H1.currentHealth < H1.maxHealth)
            {
                //animator.SetBool("Heal", true);
                animator.SetTrigger("Heal");
                H1.currentHealth += 25;
                timer1 = 0;
            }

        }
    }
    void Heal2()
    {

        timer2 += Time.deltaTime;
        if (timer2 >= 5)
        {

            if (H3.currentHealth > 0 && H3.currentHealth < H3.maxHealth)
            {

                // animator.SetBool("Heal", true);
                //animator.SetTrigger("Heal");
                H3.currentHealth += 25;
                timer2 = 0;
            }
        }
    }
          void Heal3()
          {
              timer3 += Time.deltaTime;
              if (timer3 >= 5)
              {
                  if (H5.currentHealth > 0 && H5.currentHealth < H5.maxHealth && H5!=null)
                  {
                     // animator.SetBool("Heal", true);
                        animator.SetTrigger("Heal");
                      H5.currentHealth += 25;
                      timer3 = 0;
                  }
              }
          }
        
    
}



