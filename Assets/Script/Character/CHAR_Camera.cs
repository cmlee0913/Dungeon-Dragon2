using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_Camera : MonoBehaviour
{
    public GameObject player;
    public Vector3 offSet;
    CHAR_PlayerControll cHAR_PlayerControll;
    public bool isGround;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AvoidGround();
    }

    void AvoidGround() {
        RaycastHit hitInfo;
		if (Physics.Linecast(player.transform.position,transform.position,out hitInfo,1<<LayerMask.NameToLayer("Ground"))) {
            isGround = true;
            transform.position = hitInfo.point;
        }
        else {
            isGround = false;
        }
    }
}
