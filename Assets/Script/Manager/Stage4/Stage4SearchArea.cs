using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4SearchArea : MonoBehaviour
{
    Stage4Monster monster;

    // Start is called before the first frame update
    void Start()
    {
        monster = transform.root.GetComponent<Stage4Monster>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            monster.SetAttackTarget(other.transform);
        }
    }
}
