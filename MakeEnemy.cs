using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemy : MonoBehaviour
{
    public GameObject enemy;
    public int enemyCount;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    public float speed;

    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            //Rigidbody2D enemyInstance;
            Vector2 spawnPoint = new Vector2(Random.Range(minX,maxX), Random.Range(minY, maxY));
            GameObject newEnemy = Instantiate(enemy, spawnPoint, Quaternion.identity);
            newEnemy.GetComponent<Rigidbody2D>().AddForce(transform.right * -speed);
        }
    }

    
    void Update()
    {
        
    }
}
