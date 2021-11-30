using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_SkillUI : MonoBehaviour
{
    public GameObject Skill1;
    public GameObject Skill2;
    public GameObject Skill3;

    public GameObject Skill1_CoolTime_UI; //쿨타임 UI
    public GameObject Skill2_CoolTime_UI;
    public GameObject Skill3_CoolTime_UI;

    bool Skill1_able; // 사용가능 판별변수
    bool Skill2_able;
    bool Skill3_able;

    float Skill1_CoolTime; // 쿨타임 변수
    float Skill2_CoolTime;
    float Skill3_CoolTime;

    // Start is called before the first frame update
    void Start()
    {
        Skill1_able = false;
        Skill2_able = false;
        Skill3_able = false;

        Skill1_CoolTime = 0.0f;
        Skill2_CoolTime = 0.0f;
        Skill3_CoolTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (StageControl.Instance.CheckStageClear(1) && Skill1.activeSelf)
        {
            Skill1_able = true;
            Skill1.SetActive(false);
        }

        if (StageControl.Instance.CheckStageClear(2) && Skill2.activeSelf)
        {
            Skill2_able = true;
            Skill2.SetActive(false);
        }

        if (StageControl.Instance.CheckStageClear(3) && Skill3.activeSelf)
        {
            Skill3_able = true;
            Skill3.SetActive(false);
        }
    }

    public void Active_Skill1()
    {

    }

    public void Active_Skill2()
    {

    }

    public void Active_Skill3()
    {

    }
}
