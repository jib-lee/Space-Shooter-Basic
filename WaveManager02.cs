using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager02 : MonoBehaviour
{
    public GameObject smallEnem;
    public GameObject mediumEnem;
    public GameObject bigEnem;
    public GameObject hugeEnem;

    float minY = -4.5f;
    float maxY = 4.5f;

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

        PublicScore.speedSmall = 100;
        PublicScore.speedMedium = 101;
        PublicScore.speedBig =87;


    }

    void EnemyCheck()
    {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("enemy").Length;
        Debug.Log(enemiesLeft);

        if (waveNum == 1 && enemiesLeft <= 2)
        {
            StartCoroutine(Wave02());

        }

        if (waveNum == 2 && enemiesLeft < 1)
        {
            playerCol.enabled = false;

            //Win
            Debug.Log("WIN!!!");

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
            Vector2 position = new Vector2(i * 5 + Random.Range(15, 23) , Random.Range(minY, maxY));
            Instantiate(smallEnem, position, Quaternion.identity);
        }

        for (int i = 0; i < 3; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(15, 20), Random.Range(minY, maxY));
            Instantiate(mediumEnem, position, Quaternion.identity);
        }

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < 1; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(22, 26), Random.Range(minY, maxY));
            Instantiate(bigEnem, position, Quaternion.identity);
        }


    }

    IEnumerator Wave02()
    {
        //Wave 2

        yield return new WaitForSeconds(0.05f);

        waveNum = 2;

        for (int i = 0; i < 3; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(16, 25), Random.Range(minY, maxY));
            Instantiate(mediumEnem, position, Quaternion.identity);
        }

        for (int i = 0; i < 1; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(31, 40), Random.Range(minY, maxY));
            Instantiate(bigEnem, position, Quaternion.identity);
        }


        for (int i = 0; i < 1; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(28, 34), Random.Range(minY, maxY));
            Instantiate(hugeEnem, position, Quaternion.identity);
        }

    }

    //IEnumerator Wave03()
    //{
    //    //Wave 3

    //    yield return new WaitForSeconds(0.1f);

    //    waveNum = 3;

    //    for (int i = 0; i < 3; i++)
    //    {
    //        Vector2 position = new Vector2(i * 5 + Random.Range(15, 28), Random.Range(minY, maxY));
    //        Instantiate(mediumEnem, position, Quaternion.identity);
    //    }

    //    for (int i = 0; i < 1; i++)
    //    {
    //        Vector2 position = new Vector2(i * 5 + Random.Range(35, 38), Random.Range(minY, maxY));
    //        Instantiate(bigEnem, position, Quaternion.identity);
    //    }


    //    for (int i = 0; i < 1; i++)
    //    {
    //        Vector2 position = new Vector2(i * 5 + Random.Range(28, 34), Random.Range(minY, maxY));
    //        Instantiate(hugeEnem, position, Quaternion.identity);
    //    }

       
    //}
}
