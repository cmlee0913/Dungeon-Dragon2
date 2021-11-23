using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Object : MonoBehaviour
{
    CHAR_CharacterStatus status;

    public static bool stage4_object_check = false;

    public GameObject reflect_effect;

    Vector3 pos;

    public float speed = 0.1f;
    private float timer = 0;
    public float reflect_time = 20f;

    public float reflect_damage_time = 10f;

    public bool is_active = false;

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
        status = GetComponent<CHAR_CharacterStatus>();
        pos = new Vector3(transform.position.x, 0.47f, transform.position.z);
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

        if(timer >= reflect_time && is_active)
        {
            Reflect();
            timer = 0;
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
            status.HP -= attackInfo.attackPower;
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

    private void Reflect()
    {
        GameObject effect = Instantiate(reflect_effect, transform.position, Quaternion.identity) as GameObject;
        effect.transform.position = new Vector3(transform.position.x, 0.44f, transform.position.z);
        Destroy(effect, reflect_time);
    }

    private void Break()
    {
        Destroy(this.gameObject);
    }
}
