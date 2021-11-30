using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Pattern : MonoBehaviour
{
    public Stage2RandomTrap trapManager;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<CHAR_Item>().itemCount > 0)
        {
            Player.GetComponent<CHAR_Item>().itemCount--;
            trapManager.SettingGlass();
        }
    }
}
