using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern3 : MonoBehaviour
{
    public List<GameObject> fireballSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFireBallSpawner();
        }
    }

    public void SpawnFireBallSpawner()
    {
        for(int i = 0; i < fireballSpawner.Count; i++)
        {
            int rand = Random.Range(0, 3);
            if(rand != 1)
            {
                fireballSpawner[i].SetActive(true);
            }
        }
    }
}
