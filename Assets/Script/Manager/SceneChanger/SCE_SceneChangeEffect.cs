using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCE_SceneChangeEffect : MonoBehaviour

{
    GameObject SplashObj;               
    Image image;      
    public bool startFadeOut = false;                       
    public bool checkFadeOut = false;     
    public bool checkFadeIn = false;
    
    

    void Awake()
    {
        SplashObj = this.gameObject;                         
        image = SplashObj.GetComponent<Image>();    
    }

    void Update()
    {
        if (!checkFadeIn)
            StartFadeIn();

        if (startFadeOut) {
            StartFadeOut();
        }
    }

    public void StartFadeOut()
    {
        StartCoroutine("FadeOut");                        
        if (checkFadeOut)                                          
        {
            Debug.Log("checkFadeOutTrue");                         
        }
    }

    public void StartFadeIn()
    {
        StartCoroutine("FadeIn");                        
        if (checkFadeIn)                                            
        {
            Debug.Log("FadeInSetActivefalse");
            this.gameObject.SetActive(false);                       
        }
    }
 

    public IEnumerator FadeOut()
    {
        Color color = image.color;                           

        for (int i = 100; i >= 0; i--)                            
        {
            color.a += Time.deltaTime * 0.01f;               
            image.color = color;                               
 
            if (image.color.a >= 1)                      
            {
                checkFadeOut = true;                          
            }
        }
        yield return null;                                     
    }

    public IEnumerator FadeIn()
    {
        Color color = image.color;                          

        for (int i = 100; i >= 0; i--)                            
        {
            color.a -= Time.deltaTime * 0.01f;               
            image.color = color;                               
 
            if (image.color.a <= 0)                       
            {
                checkFadeIn = true;                           
            }
        }
        yield return null;                                   
    }
}
