using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleDie : MonoBehaviour
{
    public AudioSource pop;
    
    // Start is called before the first frame update
    void Start()
    {
        pop.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.9f);
    }
}
