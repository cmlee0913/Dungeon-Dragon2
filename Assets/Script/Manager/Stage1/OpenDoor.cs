using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool isClear;
    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isClear) return;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - 10.0f, transform.position.z), Time.deltaTime * 10);
    }

    public void Clear()
    {
        isClear = true;
    }
}
