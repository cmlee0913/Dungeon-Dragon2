using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4ItemBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StageControl.Instance.StageClear(4);
        }
    }
}
