using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage4Manager : MonoBehaviour
{
    public List<GameObject> monster_list;
    public GameObject[] monsters;

    // 올바른 기둥 순서 저장
    public List<int> answer;

    // Start is called before the first frame update
    void Start()
    {
        monster_list = new List<GameObject>();
        monsters = GameObject.FindGameObjectsWithTag("Monster");

        answer = new List<int>();

        for (int i = 0; i < monsters.Length; i++)
        {
            monster_list.Add(monsters[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < monster_list.Count; i++) 
        {
            if(monster_list[i].GetComponent<Stage4TestMonster>().is_dead)
            {
                Destroy(monster_list[i]);
                monster_list.RemoveAt(i);
                answer.Add(i);
            }
        }
    
        if(monster_list.Count == 0)
        {
            Stage4Object.stage4_object_check = true;
        }

        if(StageControl.Instance.CheckStageClear(4))
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}
