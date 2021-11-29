using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3Manager : MonoBehaviour
{
    public static Stage3Manager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    CHAR_CharacterStatus status;

    public GameObject prefab_arrow;

    public int count = 5;
    private float timer = 0;

    public GameObject item_box;
    private int item_count = 0;

    public GameObject respawn_range;
    private BoxCollider range_coll;

    public bool is_poison = false;
    public bool is_cure = false;

    // Start is called before the first frame update
    void Start()
    {
        range_coll = respawn_range.GetComponent<BoxCollider>();
        status = FindObjectOfType<CHAR_CharacterStatus>();

        for (int i = 0; i < count; i++)
        {
            RespawnItemBox();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 5)
        {
            RespawnArrow();

            timer = 0;
        }

        if(StageControl.Instance.CheckStageClear(3))
        {
            SceneManager.LoadScene("Lobby");
        }

        Poison();
    }

    public void Poison()
    {
        if(is_poison && !is_cure)
        {
            status.HP -= 1;
        }
    }

    public void RespawnArrow()
    {
        GameObject new_arrow = ObjectPool.instance.PerfabQueue.Dequeue();
        new_arrow.transform.position = RandomPosition();
        new_arrow.SetActive(true);
    }

    public void RespawnItemBox()
    {
        GameObject new_item_box = Instantiate(item_box);

        if (item_count == 0)
        {
            new_item_box.GetComponent<Stage3ItemBox>().is_item = true;
            item_count = 1;
        }
        else
        {
            new_item_box.GetComponent<Stage3ItemBox>().is_item = false;
        }

        new_item_box.transform.position = RandomBoxPosition();
    }

    Vector3 RandomPosition()
    {
        Vector3 pos = respawn_range.transform.position;

        float range_x = range_coll.bounds.size.x;
        float range_z = range_coll.bounds.size.z;

        range_x = Random.Range((range_x / 2) * -1, range_x / 2);
        range_z = Random.Range((range_z / 2) * -1, range_z / 2);

        Vector3 new_pos = new Vector3(range_x, 0f, range_z);
        Vector3 respawn_pos = pos + new_pos;

        return respawn_pos;
    }

    Vector3 RandomBoxPosition()
    {
        Vector3 pos = respawn_range.transform.position;

        float range_x = Random.Range(-100, 210);
        float range_z = Random.Range(105, -220);

        Vector3 new_pos = new Vector3(range_x, 1f, range_z);

        return new_pos;
    }
}
