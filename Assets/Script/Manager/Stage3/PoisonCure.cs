using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCure : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -0.2f, this.gameObject.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Stage3Manager.instance.is_cure = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Stage3Manager.instance.is_cure = false;
        }
    }
}
