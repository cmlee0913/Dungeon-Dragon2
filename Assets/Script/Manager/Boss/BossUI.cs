using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public GameObject Boss;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float bossHP = (float)Boss.GetComponent<CharacterStatus>().HP;
        float bossMaxHP = (float)Boss.GetComponent<CharacterStatus>().MaxHP;

        float value = bossHP/bossMaxHP;
        this.GetComponent<Image>().fillAmount = value;
    }
}
