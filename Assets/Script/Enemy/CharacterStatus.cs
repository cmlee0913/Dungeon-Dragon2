using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    //---------- ���� �忡�� ����Ѵ�. ----------
    // ü��.
    public int HP = 100;
    public int MaxHP = 100;

    // ���ݷ�.
    public int Power = 10;

    // �������� ������ ���.
    public GameObject lastAttackTarget = null;

    //---------- GUI �� ��Ʈ��ũ �忡�� ����Ѵ�. ----------
    // �÷��̾� �̸�.
    public string characterName = "Player";

    //--------- �ִϸ��̼� �忡�� ����Ѵ�. -----------
    // ����.
    public bool attacking = false;
    public bool died = false;

    // ���ݷ� ��ȭ.
    public bool powerBoost = false;
    // ���ݷ� ��ȭ �ð�.
    float powerBoostTime = 0.0f;

    // ���ݷ� ��ȭ ȿ��.
    ParticleSystem powerUpEffect;

    //������ ȹ��.
    public void GetItem(DropItem.ItemKind itemKind)
    {
        switch (itemKind)
        {
            case DropItem.ItemKind.Heal:
                // MaxHP�� ���� ȸ��.
                HP = Mathf.Min(HP + MaxHP / 2, MaxHP);
                break;
            case DropItem.ItemKind.Object:
                //������Ʈ ������ ȹ��.

                break;
        }
    }

    void Start()
    {
        /*if (gameObject.tag == "Player")
        {
            powerUpEffect = transform.Find("PowerUpEffect").GetComponent<ParticleSystem>();
        }*/
    }

    void Update()
    {
        if (gameObject.tag != "Player")
        {
            return;
        }
        /*powerBoost = false;
        if (powerBoostTime > 0.0f)
        {
            powerBoost = true;
            powerBoostTime = Mathf.Max(powerBoostTime - Time.deltaTime, 0.0f);
        }
        else
        {
            powerUpEffect.Stop();
        }*/
    }

}
