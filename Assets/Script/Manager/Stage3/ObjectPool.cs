using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInfo
{
    public GameObject prefab;
    public int count;
    public Transform PoolParent;
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField] ObjectInfo[] obj_info = null;

    public static ObjectPool instance;

    public Queue<GameObject> PerfabQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PerfabQueue = InsertQueue(obj_info[0]);
    }

    Queue<GameObject> InsertQueue(ObjectInfo obj)
    {
        Queue<GameObject> queue = new Queue<GameObject>();

        for (int i = 0; i < obj.count; i++)
        {
            GameObject clone = Instantiate(obj.prefab, transform.position, Quaternion.identity);
            clone.SetActive(false);

            if(obj.PoolParent != null)
            {
                clone.transform.SetParent(obj.PoolParent);
            }
            else
            {
                clone.transform.SetParent(this.transform);
            }

            queue.Enqueue(clone);
        }

        return queue;
    }
}
