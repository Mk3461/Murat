using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Dusman5AI : MonoBehaviour
{

    public float distance;
    public Animator animator;
    Collider2D playercollider;
    public GameObject enemyPrefab;
    public Transform enemySpawnPos;
    private float timer = 0;

    public Transform playerPos;
    public bool isSpawning=false;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {/*
        if (!isSpawning)
        {
            float distance = Vector2.Distance(transform.position, playerPos.transform.position);

            timer += Time.deltaTime;

            if (distance < 10 && timer > 5 )
            {
                    spawn();
             
            }
        }
        */
        distance =Vector2.Distance(transform.position,playerPos.transform.position);
        timer += Time.deltaTime;
        if (!isSpawning)
        {
            spawn();
        }
    }
  void spawn()
    {
        if (distance < 10 && timer > 10)
        {
            isSpawning = true;
            animator.SetBool("isSpawn",true);
            StartCoroutine(stopForSpawn());
        }
    }
    
   IEnumerator stopForSpawn()
    {
        if (isSpawning)
        {
            yield return new WaitForSeconds(3f);
            timer = 0;
            isSpawning = false;
            animator.SetBool("isSpawn", false);
            
        }

    }
  
    
    void enemySpawnPoint()
    {
        Instantiate(enemyPrefab,enemySpawnPos.position,enemySpawnPos.rotation);
    }
}
 

