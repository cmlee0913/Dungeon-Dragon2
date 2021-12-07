using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    EnemyObjectPool instance;
    EnemyGeneratorCtrl enemyGeneratorCtrl;
    GameObject poolingObjectPrefeb;
    Queue<MonsterCtrl> poolingObjectQueue = new Queue<MonsterCtrl>();

    public float minimum = -20f;
    public float maximum = 20f;
    void Awake()
    {
        instance = this;
        enemyGeneratorCtrl = transform.root.gameObject.GetComponent<EnemyGeneratorCtrl>();
        poolingObjectPrefeb = enemyGeneratorCtrl.enemyPrefab;
        Initialize(enemyGeneratorCtrl.maxEnemy);
    }

    MonsterCtrl CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefeb, transform).GetComponent<MonsterCtrl>();
        newObj.gameObject.SetActive(false);
        return newObj;
    }

    void Initialize(int count)
    {
        for(int i = 0; i < count; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    public MonsterCtrl GetObject()
    {
        if(instance.poolingObjectQueue.Count > 0)
        {
            var obj = instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.transform.position = transform.position + new Vector3(Random.Range(minimum, maximum), 0 , Random.Range(minimum, maximum));
            obj.gameObject.SetActive(true);

            return obj;
        }
        else
        {
            var newObj = instance.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.transform.position = transform.position + new Vector3(Random.Range(minimum, maximum), 0 , Random.Range(minimum, maximum));
            newObj.gameObject.SetActive(true);

            return newObj;
        }
    }

    public void ReturnObject(MonsterCtrl monsterCtrl)
    {
        monsterCtrl.gameObject.SetActive(false);
        monsterCtrl.transform.SetParent(instance.transform);
        instance.poolingObjectQueue.Enqueue(monsterCtrl);
    }
}
