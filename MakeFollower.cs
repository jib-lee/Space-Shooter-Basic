using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFollower : MonoBehaviour
{
    public GameObject follower;

    public Transform mainPlayer;
  

    void Start()
    {

        for (int i = 0; i < PublicScore.score; i++)
        {
            Vector2 spawnPoint = new Vector2(mainPlayer.transform.position.x + Random.Range(-3.5f, 2), mainPlayer.transform.position.y + Random.Range(1.5f,4));
            GameObject newFollower = Instantiate(follower, spawnPoint, Quaternion.identity);
        }
    }

   
    void Update()
    {

    }
}
