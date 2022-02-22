using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager01 : MonoBehaviour
{
    public GameObject smallEnem;
    public GameObject mediumEnem;
    public GameObject bigEnem;

    float minY = -3.1f;
    float maxY = 3.1f;

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
    }


    void EnemyCheck()
    {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("enemy").Length;
        Debug.Log(enemiesLeft);

        if(waveNum == 1 && enemiesLeft < 1)
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
            Vector2 position = new Vector2(i * 5 + Random.Range(11, 20), Random.Range(minY, maxY));
            Instantiate(smallEnem, position, Quaternion.identity);
        }

        yield return new WaitForSeconds(0.05f);

        for (int i = 0; i < 2; i++)
        {
            Vector2 position = new Vector2(i * 5 +  Random.Range(20, 22), Random.Range(minY, maxY));
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
            Vector2 position = new Vector2(i * 5 + Random.Range(16, 28), Random.Range(minY, maxY));
            Instantiate(bigEnem, position, Quaternion.identity);
        }

        //for (int i = 0; i < 1; i++)
        //{
        //    Vector2 position = new Vector2(i * 5 + Random.Range(11, 25), Random.Range(minY, maxY));
        //    Instantiate(smallEnem, position, Quaternion.identity);

        //}

        for (int i = 0; i < 3; i++)
        {
            Vector2 position = new Vector2(i * 5 + Random.Range(12, 26), Random.Range(minY, maxY));
            Instantiate(mediumEnem, position, Quaternion.identity);
        }
    }

}
