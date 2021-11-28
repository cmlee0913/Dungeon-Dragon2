using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHAR_HPBar : MonoBehaviour
{
    public GameObject Player;
    public Image hpBar;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHPBar();
    }

    void PlayerHPBar()
    {
        float HP = Player.GetComponent<CHAR_CharacterStatus>().HP;
        hpBar.fillAmount = HP / 100f;
    }
}
