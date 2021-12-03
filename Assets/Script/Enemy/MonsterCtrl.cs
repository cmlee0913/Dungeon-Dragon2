using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterCtrl : MonoBehaviour
{
	CharacterStatus status;
	CharacterAnimation charaAnimation;
	MonsterMove characterMove;
	Transform attackTarget;
	public EnemyGeneratorCtrl enemyGeneratorCtrl;
	public EnemyObjectPool objectPool;
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

	[SerializeField]
	State state = State.Walking;        // ���� ������Ʈ.
	State nextState = State.Walking;    // ���� ������Ʈ.

	public AudioClip deathSeClip;
	AudioSource deathSeAudio;


	void Awake() {
		enemyGeneratorCtrl = transform.root.gameObject.GetComponent<EnemyGeneratorCtrl>();
		objectPool = transform.parent.gameObject.GetComponent<EnemyObjectPool>();
	}
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
		HealthBar.GetComponent<Image>().fillAmount = status.HP / StartHealth;
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
			if (characterMove.Arrived())
			{
				waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
				//waitTime = 2.0f;
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
		// 시험 중
		// // else if (Vector3.Distance(enemyGeneratorCtrl.gameObject.transform.position, transform.position) >= 20.0f) {
		// // 	SendMessage("SetDestination", enemyGeneratorCtrl.gameObject.transform.position);
		// // 	ChangeState(State.Walking);
		// // }
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
		if (charaAnimation.IsAttacked())
			ChangeState(State.Walking);
		waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
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
		//status.died = true;
		dropItem();
		DestroyEnemy(); // Destroy(gameObject);

		if (gameObject.tag == "Boss")
		{
			//gameRuleCtrl.GameClear();
		}

		AudioSource.PlayClipAtPoint(deathSeClip, transform.position);
	}

	void DestroyEnemy()
    {
		// 부활
		status.HP = status.MaxHP;
		attackTarget = null;
		ChangeState(State.Walking);

		enemyGeneratorCtrl.enemyCount--;
		objectPool.ReturnObject(this);
	}

	public void Damage(CHAR_AttackArea.AttackInfo attackInfo)
	{
		//GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
		//effect.transform.localPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
		//Destroy(effect, 0.3f);

		status.HP -= attackInfo.attackPower;

		// Update로 이동.
		// HealthBar.GetComponent<Image>().fillAmount = status.HP / StartHealth;
		if (status.HP <= 0)
		{
			status.HP = 0;
			Died();
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
