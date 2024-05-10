using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Dusman3AI : MonoBehaviour
{
    public Vector2 pos1;
    public Vector2 pos2;
    public float leftrightspeed;
    public float oldPosition;
    public float distance;
    public float attackRange;
    public LayerMask playerLayer;

    public GameObject arrowPrefab;
    public Transform firePoint;

    public float attackInterval = 2f; // Ok atýþ aralýðý
    private float lastAttackTime;

    private Transform targetPos; // Oyuncunun konumu
    private Animator animator;
    private bool canMove = true;
    private bool canAttack=false;



    
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        animator = GetComponent<Animator>();
        targetPos = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncunun konumu
    }



    void Update()
    {
        if (canMove)
        {
            Flip();
            CanAttack();
            EnemyAi();

        }
        
    }

    

    void EnemyMove()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * leftrightspeed, 1.0f));

        if (transform.position.x > oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position.x < oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        oldPosition = transform.position.x;
    }

    void EnemyAi()
    {
    attack:

        if (canAttack)
        {
            //Time.time >=lastAttackTime+attackInterval
            Debug.Log("Eralp");
            EnemyAttack();
            canMove = false;
            lastAttackTime = Time.time;
            goto attack;
        }
        else
        {
            Debug.Log("Mustafa");
            canMove = true;
            EnemyMove();
            animator.SetBool("Attack", false);
        }
    }
    
    void CanAttack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, distance, playerLayer);
        
        if (hit.collider != null)
        {
            Debug.Log("Özgür");
            canAttack = true;
        }// Saldýrý aralýðýna göre kontrol
        else
        {
            Debug.Log("Nuri");
            canAttack = false;
        }
    }
    
  
    void Flip()
    {
        if (animator.GetBool("Attack") == false)
        {
            if (animator.GetBool("Hurt") == true)
            {
                transform.Rotate(0f, 180f, 0f);
            }
        }
    }

    void EnemyAttack()
    {
        
        // Animasyonu tetikleyin ve oku fýrlatýn
        firePoint.localScale = new Vector3(-1, 1, 1);
        animator.SetBool("Attack", true);
      

    }
       void ArrowShot()
        {
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);//okun çýkýþ animasyonuna koymak için
        }

}

