using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform target;

    public float speed = 0.1f;

    Vector3 target_pos;

    CHAR_CharacterStatus status;

    private float timer = 0;
    private float delete_time = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        target_pos = target.position;

        Vector3 vector = target.position - transform.position;
        vector.Normalize();

        Quaternion quaternion = Quaternion.LookRotation(vector);
        transform.localRotation = quaternion;

        status = FindObjectOfType<CHAR_CharacterStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target_pos, speed);

        if(timer >= delete_time)
        {
            ObjectPool.instance.PerfabQueue.Enqueue(this.gameObject);
            timer = 0;
            this.gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            status.HP -= 10;

            ObjectPool.instance.PerfabQueue.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            ObjectPool.instance.PerfabQueue.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}