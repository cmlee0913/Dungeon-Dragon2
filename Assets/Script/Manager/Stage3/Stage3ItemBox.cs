using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3ItemBox : MonoBehaviour
{
    public GameObject item;

    public bool is_item = false;

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
        if(other.tag == "Player" && is_item)
        {
            Instantiate(item);
            item.transform.position = this.gameObject.transform.position;
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player" && !is_item)
        {
            Destroy(this.gameObject);
        }
    }
}
