using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_MainCamera : MonoBehaviour
{
    GameObject mainCamera;
    GameObject pivot;
    public float distance;
    Vector3 velocity = Vector3.zero;
    public float SmoothTime = 0.2f;
    public bool isGround;
    void Awake() {
        mainCamera = GameObject.FindWithTag("MainCamera");
        pivot = GameObject.FindWithTag("Player");
    }

    void Start() {
        distance = Vector3.Distance(transform.position, pivot.transform.position);
    }

    void Update() {
        ScrollWheel();
        AvoidGround();
    }

    void ScrollWheel()
    {
        if (!isGround) {
            Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);
            transform.position = Vector3.SmoothDamp(
                                    transform.position,
                                    pivot.transform.position - transform.rotation * reverseDistance + new Vector3(0.0f, 1.5f, 0.0f),
                                    ref velocity,
                                    SmoothTime);
        }
    }

    void AvoidGround() {
        RaycastHit hitInfo;
		if (Physics.Linecast(pivot.transform.position,
                            transform.position,
                            out hitInfo,
                            1<<LayerMask.NameToLayer("Ground"))) 
        {
            isGround = true;
            transform.position = hitInfo.point;
        }

        else if (!Physics.Linecast(pivot.transform.position,
                                    transform.position - (transform.rotation * new Vector3(0,0,2)),
                                    out hitInfo,
                                    1<<LayerMask.NameToLayer("Ground"))) 
        {
            isGround = false;
        }
    }
}