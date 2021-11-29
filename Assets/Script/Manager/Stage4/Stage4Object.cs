using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Object : MonoBehaviour
{
    CHAR_CharacterStatus status;
    CharacterStatus obj_status;

    public static bool stage4_object_check = false;

    public GameObject reflect_effect;

    Vector3 pos;

    public float speed = 0.1f;
    private float timer = 0;
    public float reflect_time = 10f;

    public float reflect_damage_time = 3f;
    private float reflect_timer = 0;

    public bool is_active = false;
    public bool is_reflect = false;

    enum State
    {
        Ready,
        Activating,
        Breaked
    };

    State state = State.Ready;
    State next_state = State.Ready;

    // Start is called before the first frame update
    void Start()
    {
        status = FindObjectOfType<CHAR_CharacterStatus>();
        obj_status = GetComponent<CharacterStatus>();
        pos = new Vector3(transform.position.x, 0.67f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Ready:
                Ready();
                break;
            case State.Activating:
                Activate();
                break;
            case State.Breaked:
                Break();
                break;
        }

        if(state != next_state)
        {
            state = next_state;
            switch(state)
            {
                case State.Ready:
                    Ready();
                    break;
                case State.Activating:
                    Activate();
                    break;
                case State.Breaked:
                    Break();
                    break;
            }
        }

        if (is_active)
        {
            timer += Time.deltaTime;
        }
        if (is_reflect)
        {
            reflect_timer += Time.deltaTime;
        }


        if(timer >= reflect_time)
        {
            is_reflect = true;
        }
        if(reflect_timer >= reflect_damage_time)
        {
            is_reflect = false;
            timer = 0;
            reflect_timer = 0;
        }
    }

    private void ChangeState(State _state)
    {
        this.next_state = _state;
    }

    private void Ready()
    {
        is_active = false;

        if(stage4_object_check)
        {
            ChangeState(State.Activating);
        }
    }

    private void Damage(CHAR_AttackArea.AttackInfo attackInfo)
    {
        if (is_active)
        {
            if (is_reflect)
            {
                status.HP -= obj_status.Power;

                // ¿Ã∆Â∆Æ √ﬂ∞°
            }
            else
            {
                obj_status.HP -= attackInfo.attackPower;
            }

            if (status.HP <= 0)
            {
                status.HP = 0;
                ChangeState(State.Breaked);
            }
        }
    }

    private void Activate()
    {
        is_active = true;

        transform.position = Vector3.MoveTowards(transform.position, pos, speed);
    }

    private void Break()
    {
        Destroy(this.gameObject);
    }
}
