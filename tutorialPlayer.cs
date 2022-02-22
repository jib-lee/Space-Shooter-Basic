using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialPlayer : MonoBehaviour
{ 

    private float speed = 7.55f;
    private Rigidbody2D rb;
    
    public GameObject bullet;
    private int bulletSpeed = 470;
    public Transform spawnPoint;

    private GameObject[] enemy;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public GameObject deathParticle;

    public Animator anim;

    public AudioSource shootSound;

    void Start()
    {
     
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        // no rotate
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector2(xSpeed, ySpeed);

        //boundary
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY));

    
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
        {
            shootSound.Play();
            GameObject newBullet = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);

            anim.SetTrigger("isShooting");
        }


        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("enemy"))
    //    {
    //        Destroy(gameObject);

    //        Instantiate(deathParticle, transform.position, Quaternion.identity);
    //    }
    //}
}
