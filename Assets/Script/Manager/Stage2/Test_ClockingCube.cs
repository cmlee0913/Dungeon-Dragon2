using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ClockingCube : MonoBehaviour
{
    public bool isClocking;

    public bool hasGlass;
    // Start is called before the first frame update
    void Start()
    {
        isClocking = false;
        hasGlass = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGlass)
        {
            if (isClocking)
            {
                this.GetComponent<MeshRenderer>().materials[0].color = new Color(1f, 0f, 0f, 0.02f);
            }
            else
            {
                this.GetComponent<MeshRenderer>().materials[0].color = new Color(1f, 0f, 0f, 1f);
            }
        }
        else
        {
            this.GetComponent<MeshRenderer>().materials[0].color = new Color(1f, 0f, 0f, 1f);
        }
    }
}
