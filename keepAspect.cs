using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepAspect : MonoBehaviour
{
    public Camera LetteboxBgCamera;
    private Camera MainCamera;

    void Start()
    {
        MainCamera = Camera.main;
        CalculateMainCameraDimensions();
    }

   
    void Update()
    {
        
    }

    public void CalculateMainCameraDimensions()
    {
        float aspect16x9 = 16f / 9f;

        if(LetteboxBgCamera.aspect < aspect16x9)
        {
            MainCamera.rect = new Rect(0f, (1.0f - LetteboxBgCamera.aspect / aspect16x9) / 2.0f, 1.0f, LetteboxBgCamera.aspect / aspect16x9);
        } else
        {
            MainCamera.rect = new Rect((1.0f - aspect16x9/LetteboxBgCamera.aspect)/2.0f,0,aspect16x9/LetteboxBgCamera.aspect,1.0f);
        }
    }
}
