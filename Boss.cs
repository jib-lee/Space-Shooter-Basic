using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private GameObject player;

    private Collider2D playerIncoming;

    public LayerMask playerLayer;

    private Rigidbody2D rb;

    public GameObject chaseEnem;
    public GameObject bigEnem;
    public Transform spawnEnemy;
    public GameObject bullet;
    private int bulletSpeed = 450;
    public Transform spawnBullet;

    private int life;

    int speed = 85;

    public GameObject deathParticle;

    public Animator anim;

    private SpriteRenderer spr;

    public AudioSource shootSound;

    public AudioSource spawnSound;

    public AudioSource hitSound;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        life = 111;

        rb.AddForce(transform.right * -speed);

        spr = GetComponent<SpriteRenderer>();

    }

    
    void Update()
    {
        Debug.Log(life);

        playerIncoming = Physics2D.OverlapCircle(transform.position, 42f, playerLayer);

        if (playerIncoming)
        {
            if (!bigEnemy && life > 74)
            {
                StartCoroutine(makeBigEnemy());
            }

            if (life <= 74 && !chaseEnemy)
            {
                anim.SetTrigger("toStageTwo");
                StartCoroutine(makeChaseEnemy());
            }

            if (life <= 37 && !firedBullet)
            {
                anim.SetTrigger("toStageThree");
                StartCoroutine(shootBullet());
            }
        }

        if (life <= 0)
        {
            Destroy(gameObject);

            Instantiate(deathParticle, transform.position, Quaternion.identity);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("stopBoss"))
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

        if (other.CompareTag("bullet"))
        {
            hitSound.Play();
            Destroy(other.gameObject);
            life--;
            StartCoroutine(Flash());
        }
    }

    bool bigEnemy = false;

    IEnumerator makeBigEnemy()
    {
        //2 enemies
        for (int i = 0; i < 2; i++)
        {

            spawnSound.Play();
            Vector2 position = new Vector2(spawnEnemy.position.x, i *Random.Range (-9,9));
            GameObject enemy = Instantiate(bigEnem, position, Quaternion.identity) as GameObject;
            
        }
        bigEnemy = true;

        yield return new WaitForSeconds(6.75f);

        bigEnemy = false;
    }

    bool chaseEnemy = false;

    IEnumerator makeChaseEnemy()
    {
       // yield return new WaitForSeconds(1f);

        for (int i = 0; i < 2; i++)
        {
            spawnSound.Play();
            Vector2 position = new Vector2(spawnEnemy.position.x, i * Random.Range(-9, 9));
            GameObject enemy = Instantiate(chaseEnem, position, Quaternion.identity) as GameObject;
        }
        chaseEnemy = true;
        yield return new WaitForSeconds(2.75f);
        chaseEnemy = false;
    }

    bool firedBullet = false;

    IEnumerator shootBullet()
    {

        for (int i = 0; i < 10; i++)
        {
            shootSound.Play();
            int zRotation = i * 36;
            Quaternion rot = transform.rotation;
            rot.eulerAngles = new Vector3(0, 0, zRotation);
            GameObject newBullet = Instantiate(bullet, spawnBullet.position, rot) as GameObject;
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.right * -bulletSpeed);

        }
        firedBullet = true;

        yield return new WaitForSeconds(1.75f);

        firedBullet = false;
    }

    IEnumerator Flash()
    {
        spr.color = Color.red;
        yield return new WaitForSeconds(.1f);
        spr.color = Color.white;
    }
}
