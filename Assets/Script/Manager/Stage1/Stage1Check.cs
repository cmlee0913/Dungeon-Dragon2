using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Check : MonoBehaviour
{
    public Stage1Pattern stage1Pattern;
 
    void Start()
    {
        for (int i = 0; i < stage1Pattern.GroundTile.Count; i++) {
            transform.GetChild(i).gameObject.AddComponent<CheckPlayer>();
        }
    }
}
