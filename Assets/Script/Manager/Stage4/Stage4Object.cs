using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Object : MonoBehaviour
{
    public static bool stage4_object_check = false;

    Vector3 pos;

    public float speed = 0.1f;
    private float timer = 0;
    public float reflect_time = 20f;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(transform.position.x, 0.47f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(stage4_object_check)
        {
            Activate();
        }

        timer += Time.deltaTime;

        if(timer >= reflect_time)
        {
            Reflect();
            timer = 0;
        }
    }

    public void Activate()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, speed);
    }

    public void Reflect()
    {
        // 공격 반사
    }
}
