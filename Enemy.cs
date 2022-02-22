using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;

    private Collider2D playerIncoming;

    public LayerMask playerLayer;

    private Rigidbody2D rb;

    public GameObject bullet;
    private int bulletSpeed = 450;
    public Transform spawnBullet;

    int speed = PublicScore.speedMedium;

    public GameObject deathParticle;

    public AudioSource shootSound;

    private int life;

    private SpriteRenderer spr;

    public AudioSource hitSound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.right * -speed);

        life = 3;

        spr = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        //avoid bullet to a certain extent
        /*Closebullet = Physics2D.OverlapCircle(transform.position, 2f, whatIsBullets); //find any bullet on whatisbullets layer
        if (Closebullet)
        {
            //dodge
        }
        else
        {

        }
        */

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.gameObject.transform.position);        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        playerIncoming = Physics2D.OverlapCircle(transform.position, 37f, playerLayer);
        if (playerIncoming && onScreen)
        {
            //shoot
            Debug.Log("shoot");

            if (!firedBullet)
            {
                StartCoroutine(shootBullet());
            }
        }


        if (life <= 0)
        {
            Destroy(gameObject);

            Instantiate(deathParticle, transform.position, Quaternion.identity);
        }

        if (life == 1)
        {
            spr.color = new Color(1, 1, 1, .5f);
        }

        if (life == 2)
        {
            spr.color = new Color(1, 1, 1, .75f);
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            hitSound.Play();
            life--;
        }

        if (other.CompareTag("destroyEnem"))
        {
            Destroy(gameObject);
        }
    }


    bool firedBullet = false;

    IEnumerator shootBullet()
    {

        shootSound.Play();
        //for one bullet
        GameObject newBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity) as GameObject;
        newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * -bulletSpeed);

        firedBullet = true;

        yield return new WaitForSeconds(1.4f);

        firedBullet = false;
    }

}
