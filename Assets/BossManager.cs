using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Phase {
    Phase0, Phase1, Phase2
};

public class BossManager : MonoBehaviour
{   
    public static BossManager instance;
    public CharacterStatus characterStatus;
    public BossAnimation bossAnimation;
    public MoveToPlayer moveToPlayer;
    public HitArea hitArea;
    public AttackRange attackRange;
    public GameObject stage1Gimmik;
    public GameObject[] monsterSpawner;
    public BossPattern3 bossPattern3;
    Phase phase = Phase.Phase0;
    public bool isUnbeatable;
    public float fireBallTime = 5.0f;

    public bool phase1Start, phase2Start, phase1End;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
        }

        hitArea = GetComponentInChildren<HitArea>();
        attackRange = GetComponentInChildren<AttackRange>();
        moveToPlayer = GetComponent<MoveToPlayer>();
        characterStatus = GetComponent<CharacterStatus>();
        bossAnimation = GetComponent<BossAnimation>();
    }

    void Start() {
        
    }

    void Update() {
        PhaseCheck();
        if (Input.GetKeyDown(KeyCode.R)) {
            phase1End = true;
        }

        
        if (stage1Gimmik.GetComponentInChildren<Boss1Pattern>().puzzleLevel == 3) {
            phase1End = true;
            if (stage1Gimmik.activeSelf == true)
                stage1Gimmik.SetActive(false);
            foreach (GameObject spawner in monsterSpawner) {
                if (spawner.activeSelf == true)
                    spawner.SetActive(false);
                phase = Phase.Phase0;
                phase2Start = true;
            }
        }
    }

    void PhaseCheck() {
        if (characterStatus.HP <= characterStatus.MaxHP / 2 && !phase1Start && !isUnbeatable) {
            UnbeatableMode();
            phase = Phase.Phase1;
            Phase1Gimmik();
        }

        if ((phase1End) && isUnbeatable) {
            phase1End = false;

            isUnbeatable = false;

            Invoke("OnInspector", 5f);

            bossAnimation.animator.SetBool("isFlying", isUnbeatable);
            bossAnimation.animator.SetTrigger("FlyingEnd");

            phase = Phase.Phase0;
            Phase0Gimmik();
        }

        if (phase2Start) {
            if (fireBallTime <= 0) {
                fireBallTime = 10f;
                bossPattern3.SpawnFireBallSpawner();
            }
            if (fireBallTime > 0)
                fireBallTime -= Time.deltaTime;
        }
    }

    void Phase0Gimmik() {
        if (phase == Phase.Phase0) {
            
        }
    }

    void Phase1Gimmik() {
        if (phase == Phase.Phase1) {
            phase1Start = true;
        }

        stage1Gimmik.SetActive(true);
        foreach (GameObject spawner in monsterSpawner) {
            spawner.SetActive(true);
        }
    }

    void UnbeatableMode() {
        isUnbeatable = true;

        OffInspector();

        bossAnimation.animator.SetBool("isFlying", isUnbeatable);
        bossAnimation.animator.SetTrigger("FlyingStart");
    }

    public void Damage(CHAR_AttackArea.AttackInfo attackInfo) {
		characterStatus.HP -= attackInfo.attackPower;

		if (characterStatus.HP <= 0) {
			characterStatus.HP = 0;
			Died();
		}
	}

    void Died() {
        characterStatus.died = true;
        isUnbeatable = true;
        phase2Start = false;
        
        OffInspector();

        bossAnimation.animator.SetTrigger("Died");
		StageControl.Instance.bossClear = true;
	}

    void OnInspector() {
        attackRange.enabled = true;
        hitArea.enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        moveToPlayer.agent.enabled = true;
    }

    void OffInspector() {
        attackRange.enabled = false;
        hitArea.enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        moveToPlayer.agent.enabled = false;
    }
}
