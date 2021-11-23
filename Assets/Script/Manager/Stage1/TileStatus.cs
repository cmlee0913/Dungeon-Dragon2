using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStatus : MonoBehaviour
{
    public bool isRed;
    public bool isBlue;
    public bool isActivated;
    public int tileNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
            GetComponent<MeshRenderer>().material.color = Color.black;
        else
            GetComponent<MeshRenderer>().material.color = Color.white;

        if (isRed)
            GetComponent<MeshRenderer>().material.color = Color.red;
        if (isBlue)
            GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
