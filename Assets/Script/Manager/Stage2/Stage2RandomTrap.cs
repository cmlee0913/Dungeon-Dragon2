using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2RandomTrap : MonoBehaviour
{
    public List<GameObject> TrapList;

    public float glassTime;

    public GameObject glassEffect;

    public Text remainTimeText;
    // Start is called before the first frame update
    void Start()
    {
        glassTime = 0.0f;
        SettingTrap();
    }

    // Update is called once per frame
    void Update()
    {
        if (glassTime > 0.0f)
            glassTime -= Time.deltaTime;

        if (glassTime <= 0.0f)
        {
            for(int i = 0; i < TrapList.Count; i++)
            {
                TrapList[i].GetComponent<Test_ClockingCube>().hasGlass = false;
            }
            glassEffect.SetActive(false);
        }

        remainTimeText.text = glassTime.ToString("F1");
    }

    public void SettingTrap()
    {
        for(int i = 0; i < TrapList.Count; i++)
        {

            int Rand = Random.Range(0, 2);

            Debug.Log(Rand);
            if(Rand == 0)
                TrapList[i].GetComponent<Test_ClockingCube>().isClocking = true;
            if(Rand == 1)
                TrapList[i].GetComponent<Test_ClockingCube>().isClocking = false;
        }
    }

    public void SettingGlass()
    {
        glassTime = 30.0f;

        for (int i = 0; i < TrapList.Count; i++)
        {
            TrapList[i].GetComponent<Test_ClockingCube>().hasGlass = true;
        }

        glassEffect.SetActive(true);
    }
}
