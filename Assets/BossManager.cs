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
    Phase phase = Phase.Phase0;
    public bool isUnbeatable;

    bool phase1Start, phase2Start, phase1End, phase2End;

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
            phase2End = true;
        }
    }

    void PhaseCheck() {
        if (characterStatus.HP <= (characterStatus.MaxHP * 2) / 3 && !phase1Start && !isUnbeatable) {
            UnbeatableMode();
            phase = Phase.Phase1;
            Phase1Gimmik();
        }
        if (characterStatus.HP <= characterStatus.MaxHP / 3 && !phase2Start && !isUnbeatable) {
            UnbeatableMode();
            phase = Phase.Phase2;
            Phase2Gimmik();
        }

        if ((phase1End || phase2End) && isUnbeatable) {
            phase1End = false;
            phase2End = false;

            isUnbeatable = false;

            Invoke("OnInspector", 5f);

            bossAnimation.animator.SetBool("isFlying", isUnbeatable);
            bossAnimation.animator.SetTrigger("FlyingEnd");

            phase = Phase.Phase0;
            Phase0Gimmik();
        }
    }

    void Phase0Gimmik() {
        if (phase == Phase.Phase0) {
            // 페이즈 1, 2 기믹 삭제하기
            // if (기믹1 or 기믹2)
            //    Destroy(기믹1 or 기믹2);
        }
    }

    void Phase1Gimmik() {
        if (phase == Phase.Phase1) {
            phase1Start = true;
        }

        // if (기믹 조건이 완료된다면) {
        //    phase1End = true;
        //}
    }

    void Phase2Gimmik() {
        if (phase == Phase.Phase2) {
            phase2Start = true;
        }

        // if (기믹 조건이 완료된다면) {
        //    phase2End = true;
        //}
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
        
        OffInspector();

        bossAnimation.animator.SetTrigger("Died");
		StageControl.Instance.bossClear = true;
	}

    void OnInspector() {
        attackRange.enabled = true;
        hitArea.enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        moveToPlayer.enabled = true;
    }

    void OffInspector() {
        attackRange.enabled = false;
        hitArea.enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        moveToPlayer.enabled = false;
    }
}
