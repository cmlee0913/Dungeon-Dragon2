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

    public GameObject prefab_poison;
    public GameObject prefab_arrow;

    public int count = 5;
    private float timer = 0;

    public GameObject item_box;
    private int item_count = 0;

    public GameObject respawn_range;
    private BoxCollider range_coll;

    // Start is called before the first frame update
    void Start()
    {
        range_coll = respawn_range.GetComponent<BoxCollider>();

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

        if(Input.GetKeyDown(KeyCode.Z))
        {
            CreatePoison();
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            RemovePoison();
        }

        if(StageControl.Instance.CheckStageClear(3))
        {
            SceneManager.LoadScene("Lobby");
        }
    }

    public void CreatePoison()
    {
        prefab_poison.SetActive(true);
    }

    public void RemovePoison()
    {
        prefab_poison.SetActive(false);
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

        new_item_box.transform.position = RandomPosition();
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
}
