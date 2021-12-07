using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform FirePos;

    public float reloading;
    public int fireCount;
    // Start is called before the first frame update
    void Start()
    {
        reloading = 0.5f;
        fireCount = 35;
    }

    // Update is called once per frame
    void Update()
    {
        reloading -= Time.deltaTime;

        if (reloading <= 0)
        {
            Instantiate(fireballPrefab, FirePos.transform.position, FirePos.transform.rotation);
            reloading = 0.5f;
            fireCount--;
        }

        if (fireCount == 0)
            gameObject.SetActive(false);
    }
}
