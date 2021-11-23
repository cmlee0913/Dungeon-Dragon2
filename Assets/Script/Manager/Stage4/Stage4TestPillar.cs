using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4TestPillar : MonoBehaviour
{
    CHAR_CharacterStatus status;

    public static bool stage4_pillar_check = false;

    public GameObject reflect_effect;

    Vector3 pos;

    public float speed = 0.1f;
    private float timer = 0;
    public float reflect_time = 20f;
    public float reflect_damage_time = 10f;
    private float reflect_timer = 0;

    public bool is_active = false;
    private bool is_damaged = false;
    private bool is_reflect = false;

    // Start is called before the first frame update
    void Start()
    {
        status = GetComponent<CHAR_CharacterStatus>();
        pos = new Vector3(transform.position.x, 0.47f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(stage4_pillar_check)
        {
            Activate();
        }

        if (is_active)
        {
            timer += Time.deltaTime;
        }

        if (timer >= reflect_time && is_active)
        {
            Reflect();
        }

        if(status.HP <= 0)
        {
            status.HP = 0;
            Break();
        }
    }

    /*private void Damage(CHAR_AttackArea.AttackInfo attackInfo)
    {
        if (is_active)
        {
            status.HP -= attackInfo.attackPower;
            if (status.HP <= 0)
            {
                status.HP = 0;
                Break();
            }
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {     
        if(is_active && other.tag == "Sword")
        {
            status.HP -= 10;
            is_damaged = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(is_active && other.tag == "Sword")
        {
            is_damaged = false;
        }
    }

    private void Activate()
    {
        is_active = true;

        transform.position = Vector3.MoveTowards(transform.position, pos, speed);
    }

    private void Reflect()
    {
        if (!is_reflect)
        {
            GameObject effect = Instantiate(reflect_effect, transform.position, Quaternion.identity) as GameObject;
            effect.transform.position = new Vector3(transform.position.x, 0.44f, transform.position.z);
            Destroy(effect, reflect_time);

            is_reflect = true;
        }

        if(is_damaged)
        {
            CHAR_CharacterStatus player_status = GameObject.Find("Player").GetComponent<CHAR_CharacterStatus>();
            player_status.HP -= 10;
        }

        reflect_timer += Time.deltaTime;
        if (reflect_timer >= reflect_time)
        {
            reflect_timer = 0;
            timer = 0;
            is_reflect = false;
        }
    }

    private void Break()
    {
        StageControl.Instance.StageClear(4);
        Destroy(this.gameObject);
    }
}