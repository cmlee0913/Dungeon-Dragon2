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

    public GameObject Skill2_GlassEffect;
    CHAR_CharacterStatus cHAR_CharacterStatus;
    public float resistTime;

    void Awake() 
    {
        cHAR_CharacterStatus = transform.root.GetComponent<CHAR_CharacterStatus>();
    }

    void Start()
    {
        resistTime = 15.0f;

        Skill1_able = false;
        Skill2_able = false;
        Skill3_able = false;

        Skill1_CoolTime = 7.0f;
        Skill2_CoolTime = 30.0f;
        Skill3_CoolTime = 30.0f;
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

        if (!Skill1_CoolTime_UI.activeSelf)
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

        if(!StageControl.Instance.CheckStageClear(1))
        {
            Skill1_able = false;
        }

        if (!StageControl.Instance.CheckStageClear(2))
        {
            Skill2_able = false;
        }

        if (!StageControl.Instance.CheckStageClear(3))
        {
            Skill3_able = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && Skill1_able)
        {
            Active_Skill1();
        }

        if (Input.GetKeyDown(KeyCode.W) && Skill2_able)
        {
            Active_Skill2();
        }

        if (Input.GetKeyDown(KeyCode.E) && Skill3_able)
        {
            Active_Skill3();
        }

        // skill E 임시 저장
        if (resistTime > 0.0f) {
            resistTime -= Time.deltaTime;
            if (Stage3Manager.instance)
                Stage3Manager.instance.posionDamage = 5;
        }
        else {
            resistTime = 0f;
            if (Stage3Manager.instance)
                Stage3Manager.instance.posionDamage = 10;
        }
    }

    public void Active_Skill1()
    {
        Skill1_CoolTime_UI.SetActive(true);
        Skill1_CoolTime_UI.GetComponent<CHAR_CoolTimeUI>().SettingCoolTime(Skill1_CoolTime);

        Debug.Log("Skill Q");
        cHAR_CharacterStatus.stamina = 100;

        Skill1_able = false;
    }

    public void Active_Skill2()
    {
        Skill2_CoolTime_UI.SetActive(true);
        Skill2_CoolTime_UI.GetComponent<CHAR_CoolTimeUI>().SettingCoolTime(Skill2_CoolTime);

        Debug.Log("Skill W");
        Skill2_GlassEffect.SetActive(true);

        Skill2_GlassEffect.GetComponent<DetectingScript>().ActivaitingGlass();

        Skill2_able = false;
    }

    public void Active_Skill3()
    {
        Skill3_CoolTime_UI.SetActive(true);
        Skill3_CoolTime_UI.GetComponent<CHAR_CoolTimeUI>().SettingCoolTime(Skill3_CoolTime);

        Debug.Log("Skill E");
        cHAR_CharacterStatus.HP = cHAR_CharacterStatus.MaxHP;

        Skill3_able = false;
    }
}
