using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Item : MonoBehaviour
{
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
        if(other.tag == "Player")
        {
            Stage3Manager.instance.is_poison = false;
            StageControl.Instance.StageClear(3);
        }
    }
}
