using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHAR_CoolTimeUI : MonoBehaviour
{
    public float CoolTime;
    public float value;

    public Image CoolTimePanel;
    public Text CoolTimeText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (value <= 0)
        {
            this.gameObject.SetActive(false);
            return;
        }

        CoolTimePanel.fillAmount = value / CoolTime;
        CoolTimeText.text = value.ToString("F1");
        value -= Time.deltaTime;

    }

    public void SettingCoolTime(float coolTime)
    {
        CoolTime = coolTime;
        value = coolTime;
    }


}
