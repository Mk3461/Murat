using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Dusman3AI : MonoBehaviour
{
    public Vector2 pos1;
    public Vector2 pos2;
    public float leftrightspeed;
    public float oldPosition;
    public Transform firepoint;
    public float distance;
    public float attackRange;

    private Transform targetPos;
    public LayerMask PlayerLayer;
    public float followSpeed;
    private Animator animator;



    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        EnemyAi();
    }
    void EnemyMove()
    {


        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * leftrightspeed, 1.0f));

        if (transform.position.x > oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (transform.position.x < oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        oldPosition = transform.position.x;

    }
    void EnemyAi()//burada ama� ilk etapta e�er distance i�inde ana karakteri g�r�rse sanal �ubuk k�rm�z� olacak ama e�er distance i�inde karakteri g�rmezse ye�il olacak.D��man alg�lamas� i�in kullan�l�r.
    {
        RaycastHit2D hitEnemy = Physics2D.Raycast(transform.position, -transform.right, distance);//sanal �ubu�u �izmemize yar�yor ilk 2 parametre hangi y�ne bakaca��na karar verdirirken son parametre uzunluk i�indir.

        if (hitEnemy.collider != null)//bir obje �arpt� demek oluyor sanal �ubu�a.
        {
            Debug.DrawLine(transform.position, hitEnemy.point, Color.red);
            animator.SetBool("Attack", true);
            
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
            animator.SetBool("Attack", false);
            EnemyMove();
        }
    }
    void Flip()
    {
        if (animator.GetBool("Hurt") && !animator.GetBool("Attack"))
        {
            transform.Rotate(0f, 180f, 0f);
        }

    }
    
}
