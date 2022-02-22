using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    private GameObject player;

    private Collider2D playerIncoming;

    public LayerMask playerLayer;

    private Rigidbody2D rb;

    public GameObject bullet;
    private int bulletSpeed = 450;
    public Transform spawnBullet;

    int speed = 165;

    //private int life;

    public GameObject deathParticle;

    public AudioSource shootSound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.right * -speed);

        InvokeRepeating("Seek", 0, .2f);

    }

    void Update()
    {
        playerIncoming = Physics2D.OverlapCircle(transform.position, 28f, playerLayer);
        if (playerIncoming)
        {
            //shoot
            Debug.Log("shoot");

            if (!firedBullet)
            {
                StartCoroutine(shootBullet());
            }
        }
        
    }

    void Seek()
    {
        playerIncoming = Physics2D.OverlapCircle(transform.position, 28f, playerLayer);
        if (playerIncoming)
        {
            rb.velocity *= .5f;
            transform.up = playerIncoming.transform.position - transform.position;
            rb.AddForce(transform.up * 60);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            Instantiate(deathParticle, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("destroyEnem"))
        {
            Destroy(gameObject);
        }
    }


    bool firedBullet = false;

    IEnumerator shootBullet()
    {
        // all round bullet
        for (int i = 0; i < 4; i++)
        {
            shootSound.Play();
            int zRotation = i * 90;
            Quaternion rot = transform.rotation;
            rot.eulerAngles = new Vector3(0, 0, zRotation);
            GameObject newBullet = Instantiate(bullet, spawnBullet.position, rot) as GameObject;
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.right * -bulletSpeed);

        }

        firedBullet = true;

        yield return new WaitForSeconds(1.2f);

        firedBullet = false;
    }
}
