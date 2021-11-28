using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_SkillUI : MonoBehaviour
{
    public GameObject Skill1;
    public GameObject Skill2;
    public GameObject Skill3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StageControl.Instance.CheckStageClear(1) && Skill1.activeSelf)
            Skill1.SetActive(false);

        if (StageControl.Instance.CheckStageClear(2) && Skill2.activeSelf)
            Skill2.SetActive(false);

        if (StageControl.Instance.CheckStageClear(2) && Skill3.activeSelf)
            Skill3.SetActive(false);
    }
}
