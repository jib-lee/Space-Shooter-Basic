using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_destroy : MonoBehaviour
{
    
    void Start()
    {
        
    }
    
    void Update()
    {
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("destroyBullet"))
        {
            Destroy(gameObject);
        }
    }
}
