using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman1AI : MonoBehaviour
{
   
    public Vector2 pos1;
    public Vector2 pos2;
    public float leftrightspeed;
    private float oldPosition;
    public Transform firepoint;
    public float distance;
    private float attackRange = 1f;

    private Transform targetPos;
    public LayerMask playerLayer;
    public float followspeed;

    private Animator animator;
    void Start()
    {
        Physics2D.queriesStartInColliders = false;

        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//tag'i player olan nesneyi takip etmeyi sa�lar.
        animator= GetComponent<Animator>();
      
    }

   
    void Update()
    {
        Flip();
        EnemyAi();
    }
    void EnemyMove()
    {
        
        
            transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * leftrightspeed, 1.0f));//lerp iki nokta aras� hesaplama sunuyor bizlere ayr�ca 3.parametre bizim h�z hespalamas� yapmam�z� sa�l�yor

            if (transform.position.x > oldPosition)//burada ise d��man�n y�z�n� nereye d�n�p hareket edece�ini anlamam�z� sa�l�yor
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
        RaycastHit2D hitEnemy=Physics2D.Raycast(transform.position,-transform.right,distance);//sanal �ubu�u �izmemize yar�yor ilk 2 parametre hangi y�ne bakaca��na karar verdirirken son parametre uzunluk i�indir.

        if(hitEnemy.collider != null)//bir obje �arpt� demek oluyor sanal �ubu�a.
        {
            Debug.DrawLine(transform.position,hitEnemy.point,Color.red);
            EnemyFollow();
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(firepoint.position,attackRange, playerLayer);
            foreach(var player in hitPlayer)
            {
                animator.SetBool("Attack",true);
            }
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
        if (animator.GetBool("Hurt") && !animator.GetBool("Attack")){
            transform.Rotate(0f, 180f, 0f);
        }
  
    }


    void EnemyFollow()//karakteri takip edecek metottur.player tag'e sahip nesnenin konumunu bulmay� sa�lar.
    {
        Vector3 targetPosition=new Vector3(targetPos.position.x,gameObject.transform.position.y,targetPos.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, followspeed * Time.deltaTime);
    }

}
    