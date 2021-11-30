using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage4Manager : MonoBehaviour
{
    public static Stage4Manager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject[] monsters;
    public GameObject[] pillar;

    public GameObject door;

    // 올바른 기둥 순서 저장
    public List<int> answer;
    public List<int> pillar_number;

    private bool is_check = true;

    // Start is called before the first frame update
    void Start()
    {
        answer = new List<int>();
        pillar_number = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        if(monsters.Length == 0)
        {
            Stage4Object.stage4_object_check = true;
        }

        pillar = GameObject.FindGameObjectsWithTag("Pillar");
        if(pillar.Length == 0)
        {
            CheckAnswer();
        }

        if(StageControl.Instance.CheckStageClear(4))
        {
            SceneManager.LoadScene("Lobby");
        }
    }

    public void ResetStage()
    {
        Stage4Object.stage4_object_check = false;
        SceneManager.LoadScene("Stage4");
    }

    public void InputItemNumber(int _item)
    {
        answer.Add(_item);
    }

    public void InputPillarNumber(int _number)
    {
        pillar_number.Add(_number);
    }

    public void CheckAnswer()
    {
        for (int i = 0; i < answer.Count; i++)
        {
            if(answer[i] != pillar_number[i])
            {
                is_check = false;
            }
        }

        if(is_check)
        {
            door.GetComponent<OpenDoor>().Clear();
        }
        else
        {
            ResetStage();
        }
    }
}
