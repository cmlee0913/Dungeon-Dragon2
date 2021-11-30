using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_SkillUI : MonoBehaviour
{
    public GameObject Skill1;
    public GameObject Skill2;
    public GameObject Skill3;

    public GameObject Skill1_CoolTime_UI; //��Ÿ�� UI
    public GameObject Skill2_CoolTime_UI;
    public GameObject Skill3_CoolTime_UI;

    public bool Skill1_able; // ��밡�� �Ǻ�����
    public bool Skill2_able;
    public bool Skill3_able;

    float Skill1_CoolTime; // ��Ÿ�� ����
    float Skill2_CoolTime;
    float Skill3_CoolTime;

    // Start is called before the first frame update
    void Start()
    {
        Skill1_able = false;
        Skill2_able = false;
        Skill3_able = false;

        Skill1_CoolTime = 7.0f;
        Skill2_CoolTime = 7.0f;
        Skill3_CoolTime = 7.0f;
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

        if(Input.GetKeyDown(KeyCode.Q) && Skill1_able)
        {
            Active_Skill1();
        }

        if(Input.GetKeyDown(KeyCode.W) && Skill2_able)
        {
            Active_Skill2();
        }

        if(Input.GetKeyDown(KeyCode.E) && Skill3_able)
        {
            Active_Skill3();
        }

        if(!Skill1_CoolTime_UI.activeSelf)
        {
            Skill1_able = true;
        }

        if (!Skill2_CoolTime_UI.activeSelf)
        {
            Skill2_able = true;
        }

        if (!Skill3_CoolTime_UI.activeSelf)
        {
            Skill3_able = true;
        }

    }

    public void Active_Skill1()
    {
        Skill1_CoolTime_UI.SetActive(true);
        Skill1_CoolTime_UI.GetComponent<CHAR_CoolTimeUI>().SettingCoolTime(Skill1_CoolTime);
        Skill1_able = false;
    }

    public void Active_Skill2()
    {
        Skill2_CoolTime_UI.SetActive(true);
        Skill2_CoolTime_UI.GetComponent<CHAR_CoolTimeUI>().SettingCoolTime(Skill2_CoolTime);
        Skill2_able = false;
    }

    public void Active_Skill3()
    {
        Skill3_CoolTime_UI.SetActive(true);
        Skill3_CoolTime_UI.GetComponent<CHAR_CoolTimeUI>().SettingCoolTime(Skill3_CoolTime);
        Skill3_able = false;
    }
}
