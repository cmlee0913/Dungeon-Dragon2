using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1PlayerCheck : MonoBehaviour
{
    public Boss1Pattern boss1Pattern;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < boss1Pattern.GroundTile.Count; i++)
        {
            transform.GetChild(i).gameObject.AddComponent<CheckPlayer>();
        }
    }
}
