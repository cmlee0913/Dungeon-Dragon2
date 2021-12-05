using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHead : MonoBehaviour
{
    private Transform target;
    Vector3 target_pos;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        target_pos = target.position;

        Vector3 vector = target.position - transform.position;
        vector.Normalize();

        Quaternion quaternion = Quaternion.LookRotation(vector);
        transform.localRotation = quaternion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
