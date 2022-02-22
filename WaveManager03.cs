using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager03 : MonoBehaviour
{
    public GameObject smallEnem;
    public GameObject mediumEnem;
    public GameObject bigEnem;
    public GameObject hugeEnem;
    public GameObject sinEnem;

    float minY = -5.55f;
    float maxY = 5.2f;

    int waveNum;

    public GameObject nextLVLbutton;
    public GameObject menuButton;
    public Collider2D playerCol;

    public AudioSource win;

    void Start()
    {
        waveNum = 1;

        //Wave 1
        StartCoroutine(Wave01());
        InvokeRepeating("EnemyCheck", 1, 0.1f);

        nextLVLbutton.SetActive(false);
        menuButton.SetActive(false);

        PublicScore.speedSmall = 122;
        PublicScore.speedMedium = 124;
        PublicScore.speedBig = 109;
        PublicScore.speedHuge = 108;

        Debug.Log(PublicScore.speedSmall);
    }

    void EnemyCheck()
    {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("enemy").Length;
        

        Debug.Log(enemiesLeft);

        if (waveNum == 1 && enemiesLeft <= 3)
        {
            StartCoroutine(Wave02());

        }

        if (waveNum == 2 && enemiesLeft <= 3)
        {
            StartCoroutine(Wave03());
        }

        if (waveNum == 3 && enemiesLeft < 1)
        {
            //Win
            Debug.Log("WIN!!!");
            playerCol.enabled = false;
            nextLVLbutton.SetActive(true);
            menuButton.SetActive(true);

            Cursor.visible = true;


            if (!win.isPlaying)
            {
                win.Play();
            }
        }

    }

    IEnumerator Wave01()
    {
        //Wave 1

        for (int i = 0; i < 1; i++)
        {
            Vector2 position = new Vector2(Random.Range(20, 23), Random.Range(minY, maxY));
            Instantiate(sinEnem, position, Quaternion.identity);
        }

        yield return new WaitForSeconds(0.2f);

        //for (int i = 0; i < 1; i++)
        //{
        //    Vector2 position = new Vector2(i * 5 + Random.Range(19.5f, 33), Random.Range(minY, maxY));
        //    Instantiate(smallEnem, position, Quaternion.identity);
        //}

        for (int i = 0; i < 4; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(25, 42), Random.Range(minY, maxY));
            Instantiate(mediumEnem, position, Quaternion.identity);
        }

        for (int i = 0; i < 1; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(30, 40), Random.Range(minY, maxY));
            Instantiate(hugeEnem, position, Quaternion.identity);
        }


    }

    IEnumerator Wave02()
    {
        //Wave 2

        yield return new WaitForSeconds(0.01f);

        waveNum = 2;

        for (int i = 0; i < 1; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(23f, 37), Random.Range(minY, maxY));
            Instantiate(smallEnem, position, Quaternion.identity);
        }

        for (int i = 0; i < 2; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(23, 38), Random.Range(minY, maxY));
            Instantiate(hugeEnem, position, Quaternion.identity);
        }

        for (int i = 0; i < 2; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(30, 40), Random.Range(minY, maxY));
            Instantiate(bigEnem, position, Quaternion.identity);
        }

        for (int i = 0; i < 3; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(24, 36), Random.Range(minY, maxY));
            Instantiate(mediumEnem, position, Quaternion.identity);
        }


    }

    IEnumerator Wave03()
    {
        //Wave 3

        yield return new WaitForSeconds(0.01f);

        waveNum = 3;

        for (int i = 0; i < 1; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(21, 24), Random.Range(minY, maxY));
            Instantiate(sinEnem, position, Quaternion.identity);
        }


        for (int i = 0; i < 3; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(36, 48), Random.Range(minY, maxY));
            Instantiate(bigEnem, position, Quaternion.identity);
        }

        for (int i = 0; i < 4; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(23, 50), Random.Range(minY, maxY));
            Instantiate(mediumEnem, position, Quaternion.identity);
        }

        //for (int i = 0; i < 1; i++)
        //{
        //    Vector2 position = new Vector2(i * 5 + Random.Range(30, 37), Random.Range(minY, maxY));
        //    Instantiate(smallEnem, position, Quaternion.identity);
        //}


    }

    //IEnumerator Wave04()
    //{
    //    //Wave 4

    //    yield return new WaitForSeconds(0.1f);

    //    waveNum = 4;

    //    for (int i = 0; i < 3; i++)
    //    {
    //        Vector2 position = new Vector2(i * 5 + Random.Range(22, 47), Random.Range(minY, maxY));
    //        Instantiate(mediumEnem, position, Quaternion.identity);
    //    }

    //    yield return new WaitForSeconds(3f);

    //    for (int i = 0; i < 1; i++)
    //    {
    //        Vector2 position = new Vector2(i * 5 + Random.Range(25, 28), Random.Range(minY, maxY));
    //        Instantiate(bigEnem, position, Quaternion.identity);
    //    }

    //    for (int i = 0; i < 1; i++)
    //    {
    //        Vector2 position = new Vector2(i * 5 + Random.Range(46, 47), Random.Range(minY, maxY));
    //        Instantiate(hugeEnem, position, Quaternion.identity);
    //    }

    //    for (int i = 0; i < 1; i++)
    //    {
    //        Vector2 position = new Vector2(i * 5 + Random.Range(33, 38), Random.Range(minY, maxY));
    //        Instantiate(smallEnem, position, Quaternion.identity);
    //    }

    //}
}
