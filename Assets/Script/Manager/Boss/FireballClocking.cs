using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballClocking : MonoBehaviour
{
    public bool hasGlass;

    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGlass)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            // µ¥¹ÌÁö

            Destroy(gameObject);
        }
    }
}
