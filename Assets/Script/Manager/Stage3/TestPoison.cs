using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPoison : MonoBehaviour
{
    public static bool is_poison = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == false)
        {
            is_poison = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            is_poison = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            is_poison = false;
        }
    }   
}
