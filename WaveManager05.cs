using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager05 : MonoBehaviour
{
    public GameObject smallEnem;
    public GameObject mediumEnem;
    public GameObject bigEnem;
    public GameObject hugeEnem;
    public GameObject sinEnem;

    public GameObject boss;

    float minY = -8f;
    float maxY = 8f;

    int waveNum;

    public GameObject endButton;
    public Collider2D playerCol;
    public GameObject youWin;

    public AudioSource win;

    public AudioSource bgm;

    public AudioSource bossBGM;

    void Start()
    {
        waveNum = 1;

        //Wave 1
        StartCoroutine(Wave01());
        InvokeRepeating("EnemyCheck", 1, 0.1f);

        PublicScore.speedSmall = 175;
        PublicScore.speedMedium = 179;
        PublicScore.speedBig = 171;
        PublicScore.speedHuge = 164;

        //boss.SetActive(false);

        endButton.SetActive(false);
        youWin.SetActive(false);
    }



    void Update()
    {
        int bossLeft = GameObject.FindGameObjectsWithTag("boss").Length;

        if (waveNum == 4 && bossLeft < 1)
        {
            //Win
            Debug.Log("WIN!!!");

            endButton.SetActive(true);
            playerCol.enabled = false;
            youWin.SetActive(true);
            Cursor.visible = true;


            if (!win.isPlaying)
            {
                win.Play();
            }

        }
    }

    void EnemyCheck()
    {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("enemy").Length;
       // int bossLeft = GameObject.FindGameObjectsWithTag("boss").Length;

        Debug.Log(enemiesLeft);

        if (waveNum == 1 && enemiesLeft <= 3)
        {
            StartCoroutine(Wave02());

        }

        if (waveNum == 2 && enemiesLeft <= 4)
        {
            StartCoroutine(Wave03());
        }

        if (waveNum == 3 && enemiesLeft < 1)
        {
            StartCoroutine(Wave04());
        }

        //if (waveNum == 4 && bossLeft < 1)
        //{
        //    //Win
        //    Debug.Log("WIN!!!");

        //    menuButton.SetActive(true);
        //    playerCol.enabled = false;

        //}
    }

    IEnumerator Wave01()
    {
        //Wave 1

        for (int i = 0; i < 3; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(23.5f, 46.9f), Random.Range(minY, maxY));
            Instantiate(hugeEnem, position, Quaternion.identity);
        }

        for (int i = 0; i <4; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(35, 55), Random.Range(minY, maxY));
            Instantiate(bigEnem, position, Quaternion.identity);
        }


        for (int i = 0; i < 1; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(23.8f, 45), Random.Range(minY, maxY));
            Instantiate(smallEnem, position, Quaternion.identity);

        }

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < 5; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(43, 57), Random.Range(minY, maxY));
            Instantiate(mediumEnem, position, Quaternion.identity);
        }



    }

    IEnumerator Wave02()
    {
        //Wave 2

        yield return new WaitForSeconds(0.01f);

        waveNum = 2;

        for (int i = 0; i < 2; i++)
        {
            Vector2 position = new Vector2(Random.Range(24, 29), Random.Range(minY, maxY));
            Instantiate(sinEnem, position, Quaternion.identity);
        }

        for (int i = 0; i < 1; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(29, 48), Random.Range(minY, maxY));
            Instantiate(smallEnem, position, Quaternion.identity);
        }

        for (int i = 0; i < 5; i++)
        {
          Vector2 position = new Vector2(i * 5 + Random.Range(30, 49), Random.Range(minY, maxY));
          Instantiate(mediumEnem, position, Quaternion.identity);
        }


        for (int i = 0; i < 5; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(40, 60), Random.Range(minY, maxY));
            Instantiate(bigEnem, position, Quaternion.identity);
        }


    }

    IEnumerator Wave03()
    {
        //Wave 3

        yield return new WaitForSeconds(0.01f);

        waveNum = 3;

        for (int i = 0; i < 5; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(25f, 56), Random.Range(minY, maxY));
            Instantiate(bigEnem, position, Quaternion.identity);
        }

        for (int i = 0; i < 5; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(24f, 62), Random.Range(minY, maxY));
            Instantiate(mediumEnem, position, Quaternion.identity);
        }

        yield return new WaitForSeconds(3f);

        for (int i = 0; i < 1; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(24, 50), Random.Range(minY, maxY));
            Instantiate(smallEnem, position, Quaternion.identity);
        }

        for (int i = 0; i < 3; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(35, 55), Random.Range(minY, maxY));
            Instantiate(hugeEnem, position, Quaternion.identity);
        }


    }

    IEnumerator Wave04()
    {
        //Wave 4
        waveNum = 4;

        StartCoroutine(AudioFadeOut.FadeOut(bgm, 0.1f));

        bossBGM.Play();

        //boss

        for (int i = 0; i < 1; i++)
        {
            Vector2 position = new Vector2(29.2f, 0);
            Instantiate(boss, position, Quaternion.identity);
        }

        //boss.SetActive(true);

        yield return new WaitForSeconds(0.1f);

    }


}
