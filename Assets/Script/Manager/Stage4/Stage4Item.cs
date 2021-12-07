using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Item : MonoBehaviour
{
    public int item_num;

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
            Stage4Manager.instance.InputItemNumber(this.item_num);
            Destroy(this.gameObject);
        }
    }
}
