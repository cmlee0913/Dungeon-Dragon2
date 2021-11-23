using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4TestMonster : MonoBehaviour
{
    public bool is_dead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        is_dead = true;
    }
}
