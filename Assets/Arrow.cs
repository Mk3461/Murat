using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //public float speed=20f;
    
    public Rigidbody2D rb;
    public float force=5f;
    private float timer;
    private PlayerMovement playerMovement;
    void Start()
    {

        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position-new Vector3(0,1.4f,0);
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;//okun yönünün belirlemek için açý bulmamýzý saðlar.(Rad2Deg radyandan açýya geçmemizi saðlar)
        transform.rotation = Quaternion.Euler(0, 0, rot);
        
    }


    void Update()
    {

        timer += Time.deltaTime;
        if (timer > 7)
        {
            Destroy(gameObject);
        }
    }
}
