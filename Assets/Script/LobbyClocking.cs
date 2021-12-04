using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyClocking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Test_ClockingCube>().isClocking == false)
        {
            this.GetComponent<Test_ClockingCube>().isClocking = true;
        }
    }
}
