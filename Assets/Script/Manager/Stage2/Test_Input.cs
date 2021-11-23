using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Input : MonoBehaviour
{
    public Stage2RandomTrap trapManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            trapManager.SettingTrap();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            trapManager.SettingGlass();
        }
    }
}
