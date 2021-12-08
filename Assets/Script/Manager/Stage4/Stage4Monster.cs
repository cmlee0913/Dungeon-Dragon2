using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage4Monster : MonoBehaviour
{
    CharacterStatus status;
    CharacterAnimation characterAnimation;
    MonsterMove monsterMove;

    Transform attackTarget;

    public float waitBaseTime = 2.0f;
    float waitTime;
    public float walkRange = 5.0f;
    public Vector3 basePosition;
    public GameObject dropItemPrefab;

    public float StartHealth;
    public GameObject HealthBar;

    enum State
    {
        Walking,
        Chasing,
        Attacking,
        Died
    };

    [SerializeField]
    State state = State.Walking;
    State nextState = State.Walking;

    public AudioClip deathSeClip;
    AudioSource deathSeAudio;

    // Start is called before the first frame update
    void Start()
    {
        status = GetComponent<CharacterStatus>();
        characterAnimation = GetComponent<CharacterAnimation>();
        monsterMove = GetComponent<MonsterMove>();

        basePosition = transform.position;
        waitTime = waitBaseTime;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.Walking:
                Walking();
                break;
            case State.Chasing:
                Chasing();
                break;
            case State.Attacking:
                Attacking();
                break;
        }

        if(state != nextState)
        {
            state = nextState;
            switch (state)
            {
                case State.Walking:
                    WalkStart();
                    break;
                case State.Chasing:
                    ChaseStart();
                    break;
                case State.Attacking:
                    AttackStart();
                    break;
                case State.Died:
                    Died();
                    break;
            }
        }
		HealthBar.GetComponent<Image>().fillAmount = status.HP / StartHealth;
    }

    void ChangeState(State nextState)
    {
        this.nextState = nextState;
    }

    void WalkStart()
    {
        StateStartCommon();
    }

	void Walking()
	{
		if (waitTime > 0.0f)
		{
			waitTime -= Time.deltaTime;

			if (waitTime <= 0.0f)
			{
				Vector2 randomValue = Random.insideUnitCircle * walkRange;
				Vector3 destinationPosition = basePosition + new Vector3(randomValue.x, 0.0f, randomValue.y);

				SendMessage("SetDestination", destinationPosition);
			}
		}
		else
		{
			if (monsterMove.Arrived())
			{
				waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
			}
			if (attackTarget)
			{
				ChangeState(State.Chasing);
			}
		}
	}

	void ChaseStart()
	{
		StateStartCommon();
	}

	void Chasing()
	{
		SendMessage("SetDestination", attackTarget.position);

		if (Vector3.Distance(attackTarget.position, transform.position) <= 2.0f)
		{
			ChangeState(State.Attacking);
		}
	}

	void AttackStart()
	{
		StateStartCommon();
		status.attacking = true;

		Vector3 targetDirection = (attackTarget.position - transform.position).normalized;
		SendMessage("SetDirection", targetDirection);

		SendMessage("StopMove");
	}

	void Attacking()
	{
		if (characterAnimation.IsAttacked())
			ChangeState(State.Walking);

		waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);

		attackTarget = null;
	}

	void dropItem()
	{
		Instantiate(dropItemPrefab, new Vector3(transform.position.x, 2.0f, transform.position.z), Quaternion.Euler(-90f, 0, 0));
	}

	void Died()
	{
		status.died = true;
		dropItem();
		Destroy(this.gameObject);

		AudioSource.PlayClipAtPoint(deathSeClip, transform.position);
	}

	public void Damage(CHAR_AttackArea.AttackInfo attackInfo)
	{
		status.HP -= attackInfo.attackPower;
		if (status.HP <= 0)
		{
			status.HP = 0;

			ChangeState(State.Died);
		}
	}

	void StateStartCommon()
	{
		status.attacking = false;
		status.died = false;
	}

	public void SetAttackTarget(Transform target)
	{
		attackTarget = target;
	}
}
