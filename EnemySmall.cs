using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : MonoBehaviour
{
   
    private Rigidbody2D rb;

    int speed = PublicScore.speedSmall;

    public GameObject particle;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.right * -speed);

    }

    void Update()
    {
       


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            Instantiate(particle, transform.position, Quaternion.identity);

            //make more follower next scene
            PublicScore.score++;
        }

        if (other.CompareTag("destroyEnem"))
        {
            Destroy(gameObject);
        }
    }

}
