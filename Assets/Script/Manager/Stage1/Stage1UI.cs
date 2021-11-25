using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1UI : MonoBehaviour
{
    public GameObject Player;

    public GameObject TileBuffedUI;

    public int itemCount;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        itemCount = Player.GetComponent<CHAR_Item>().itemCount;

        if (itemCount > 0 && !TileBuffedUI.activeInHierarchy)
        {
            TileBuffedUI.SetActive(true);
        }
        if(itemCount == 0 && TileBuffedUI.activeInHierarchy)
        {
            TileBuffedUI.SetActive(false);
        }
    }
}
