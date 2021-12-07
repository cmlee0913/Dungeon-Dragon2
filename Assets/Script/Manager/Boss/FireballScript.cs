using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    float fireTime;
    // Start is called before the first frame update
    void Start()
    {
        fireTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 1f);

        fireTime -= Time.deltaTime;

        if (fireTime <= 0)
            Destroy(gameObject);
    }
}
