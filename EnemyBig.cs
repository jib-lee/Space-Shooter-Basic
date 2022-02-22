using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBig : MonoBehaviour
{
    private GameObject player;

    private Collider2D playerIncoming;

    public LayerMask playerLayer;

    private Rigidbody2D rb;

    public GameObject bullet;
    private int bulletSpeed = 450;
    public Transform spawnBullet;

    int speed = PublicScore.speedBig;

    private int life;

    public GameObject deathParticle;

    private SpriteRenderer spr;

    public AudioSource shootSound;

    public AudioSource hitSound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        life = 5;

        rb.AddForce(transform.right * -speed);

        spr = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.gameObject.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        playerIncoming = Physics2D.OverlapCircle(transform.position, 38f, playerLayer);
        if (playerIncoming && onScreen)
        {
       
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

        if (life == 4)
        {
            spr.color = new Color(1, 1, 1, .9f);
        }

        if (life == 3)
        {
            spr.color = new Color(1, 1, 1, .8f);
        }

        if (life == 2)
        {
            spr.color = new Color(1, 1, 1, .65f);
        }

        if (life == 1)
        {
            spr.color = new Color(1, 1, 1, .50f);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            hitSound.Play();
            Destroy(other.gameObject);
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

        // for 3 bullet
        for (int i = -1; i < 2; i++)
        {
            shootSound.Play();
            int zRotation = i * 45;
            Quaternion rot = transform.rotation;
            rot.eulerAngles = new Vector3(0, 0, zRotation);
            GameObject newBullet = Instantiate(bullet, spawnBullet.position, rot) as GameObject;
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.right * -bulletSpeed);

        }
        firedBullet = true;

        yield return new WaitForSeconds(1.6f);

        firedBullet = false;
    }
}
