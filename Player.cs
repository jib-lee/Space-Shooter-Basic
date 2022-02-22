using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string sceneName;

    private float speed = 7.55f;
    private Rigidbody2D rb;
    //private int rotationSpeed = -5;

    public GameObject bullet;
    private int bulletSpeed = 460;
    public Transform spawnPoint;

    //private int direction = 1;

    private GameObject[] enemy;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public GameObject restartLVLButton;

    public GameObject menuButton;

    public GameObject deathParticle;

    public Animator anim;

    public AudioSource shootSound;

    void Start()
    {
        Cursor.visible = false;

        rb = GetComponent<Rigidbody2D>();

        restartLVLButton.SetActive(false);
        menuButton.SetActive(false);

    }

    void Update()
    {
        Debug.Log("The infected cell number is " + PublicScore.score);
        
        // no rotate
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector2(xSpeed, ySpeed);

        //boundary
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY));

        /*
        if (xSpeed > 0)
        {            
            direction = 1;
        } 
        if (xSpeed < 0)
        {
            //flip sprite
            direction = -1;
        }
        */
        //rotate
        //transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -rotationSpeed);

        //rb.AddForce(transform.up * Input.GetAxis("Vertical") * speed);

        //if (Input.GetKeyDown("space"))
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
        {
            shootSound.Play();

            GameObject newBullet = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);

            anim.SetTrigger("isShooting");
        }

        /*
        enemy = GameObject.FindGameObjectsWithTag("enemy");
        if (enemy.Length == 0)
        {
            //complete lvl
            Debug.Log("WIN!!!");
        }
        */

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemyBullet"))
        {
            Destroy(other.gameObject);

            Destroy(gameObject);

            //restart infected number
            //PublicScore.score = 1;

            restartLVLButton.SetActive(true);
            menuButton.SetActive(true);

            Cursor.visible = true;

            Instantiate(deathParticle, transform.position, Quaternion.identity);

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);

            //restart infected number
            //PublicScore.score = 1;

            restartLVLButton.SetActive(true);
            menuButton.SetActive(true);

            Cursor.visible = true;

            Instantiate(deathParticle, transform.position, Quaternion.identity);
        }
    }
}
