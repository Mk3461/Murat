using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public float attackInterval = 10; // Ok at�� aral���
    private float lastAttackTime;

    private Transform targetPos; // Oyuncunun konumu
    private Animator animator;
    private bool canMove = true;

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
        // Raycast ile oyuncuyu alg�lay�n
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, distance, playerLayer);

        if (hit.collider != null && Time.time >= lastAttackTime + attackInterval) // Sald�r� aral���na g�re kontrol
        {
            EnemyAttack();
            canMove = false;
            lastAttackTime = Time.time; // Sald�r� zaman�n� g�ncelleyin
        }
        else
        {
            animator.SetBool("Attack", false);
            canMove = true;
            EnemyMove(); // Oyuncu yoksa normal hareket
        }
    }

    void Flip()
    {
        // Opsiyonel: D��man�n y�n de�i�tirmesi i�in animasyon kontrol�
    }

    void EnemyAttack()
    {
        // Animasyonu tetikleyin ve oku f�rlat�n
        firePoint.localScale = new Vector3(-1, 1, 1);
        animator.SetBool("Attack",true);



    }
    void Eralp()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
    void AttackFree()
    {
        if (animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", false);
            StartCoroutine(counter());

        }


    } 
    IEnumerator counter()
    {
        yield return new WaitForSeconds(2);
    }
}
