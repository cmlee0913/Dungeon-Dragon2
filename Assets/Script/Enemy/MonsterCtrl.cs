using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterCtrl : MonoBehaviour
{
	CharacterStatus status;
	CharacterAnimation charaAnimation;
	MonsterMove characterMove;
	Transform attackTarget;
	//public GameObject hitEffect;

	// ��� �ð��� 2�ʷ� �����Ѵ�.
	public float waitBaseTime = 2.0f;
	// ���� ��� �ð�.
	float waitTime;
	// �̵� ���� 5����.
	public float walkRange = 5.0f;
	// �ʱ� ��ġ�� ������ �� ����.
	public Vector3 basePosition;
	// ������ �������� ������ �� �ִ� �迭�� �Ѵ�.
	public GameObject[] dropItemPrefab;

    public float StartHealth;

    public GameObject HealthBar;
	// ������Ʈ ����.
	enum State
	{
		Walking,    // Ž��.
		Chasing,    // ����.
		Attacking,  // ����.
		Died,       // ���.
		Shooting,	
	};

	State state = State.Walking;        // ���� ������Ʈ.
	State nextState = State.Walking;    // ���� ������Ʈ.

	public AudioClip deathSeClip;
	AudioSource deathSeAudio;


	// Use this for initialization
	void Start()
	{
		status = GetComponent<CharacterStatus>();
		charaAnimation = GetComponent<CharacterAnimation>();
		characterMove = GetComponent<MonsterMove>();
		// �ʱ� ��ġ�� �����Ѵ�.
		basePosition = transform.position;
		// ��� �ð�.
		waitTime = waitBaseTime;
	}

	// Update is called once per frame
	void Update()
	{
		switch (state)
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

		if (state != nextState)
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
	}


	// ������Ʈ�� �����Ѵ�.
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
		// ��� �ð��� ���� ���Ҵٸ�.
		if (waitTime > 0.0f)
		{
			// ��� �ð��� ���δ�.
			waitTime -= Time.deltaTime;
			// ��� �ð��� ��������.
			if (waitTime <= 0.0f)
			{
				// ���� ���� ���.
				Vector2 randomValue = Random.insideUnitCircle * walkRange;
				// �̵��� ���� �����Ѵ�.
				Vector3 destinationPosition = basePosition + new Vector3(randomValue.x, 0.0f, randomValue.y);
				// �������� �����Ѵ�.
				SendMessage("SetDestination", destinationPosition);
			}
		}
		else
		{
			// �������� �����Ѵ�.
			if (characterMove.Arrived())
			{
				// ��� ���·� ��ȯ�Ѵ�.
				waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
				//waitTime = 2.0f;
			}
			// Ÿ���� �߰��ϸ� �����Ѵ�.
			if (attackTarget)
			{
				ChangeState(State.Chasing);
			}
		}
	}
	// ���� ����. 
	void ChaseStart()
	{
		StateStartCommon();
	}
	// ���� ��. 
	void Chasing()
	{
		// �̵��� ���� �÷��̾ �����Ѵ�.
		SendMessage("SetDestination", attackTarget.position);
		// 2���� �̳��� �����ϸ� �����Ѵ�.
		if (Vector3.Distance(attackTarget.position, transform.position) <= 2.0f)
		{
			ChangeState(State.Attacking);
		}
	}

	// ���� ������Ʈ�� ���۵Ǳ� ���� ȣ��ȴ�.
	void AttackStart()
	{
		StateStartCommon();
		status.attacking = true;

		// ���� �ִ� �������� ���ƺ���.
		Vector3 targetDirection = (attackTarget.position - transform.position).normalized;
		SendMessage("SetDirection", targetDirection);

		// �̵��� �����.
		SendMessage("StopMove");
	}

	// ���� �� ó��.
	void Attacking()
	{
		if (charaAnimation.IsAttacked())
			ChangeState(State.Walking);
		// ��� �ð��� �ٽ� �����Ѵ�.
		waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
		// Ÿ���� �����Ѵ�.
		attackTarget = null;
	}

	void dropItem()
	{
		if (dropItemPrefab.Length == 0) { return; }
		GameObject dropItem = dropItemPrefab[Random.Range(0, dropItemPrefab.Length)];
		Instantiate(dropItem, transform.position, Quaternion.identity);
	}

	void Died()
	{
		status.died = true;
		dropItem();
		Destroy(gameObject);
		if (gameObject.tag == "Boss")
		{
			//gameRuleCtrl.GameClear();
		}

		// ����� ���.
		AudioSource.PlayClipAtPoint(deathSeClip, transform.position);
	}

	public void Damage(CHAR_AttackArea.AttackInfo attackInfo)
	{
		//GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
		//effect.transform.localPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
		//Destroy(effect, 0.3f);

		status.HP -= attackInfo.attackPower;
        HealthBar.GetComponent<Image>().fillAmount = status.HP / StartHealth;
		if (status.HP <= 0)
		{
			status.HP = 0;
			// ü���� 0�̹Ƿ� ��� ������Ʈ�� ��ȯ�Ѵ�.
			ChangeState(State.Died);
		}
	}

	// ������Ʈ�� ���۵Ǳ� ���� �������ͽ��� �ʱ�ȭ�Ѵ�.
	void StateStartCommon()
	{
		status.attacking = false;
		status.died = false;
	}
	// ���� ����� �����Ѵ�. 
	public void SetAttackTarget(Transform target)
	{
		attackTarget = target;
	}
}
