using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Phase {
    Phase0, Phase1, Phase2, Phase3
};

public class BossManager : MonoBehaviour
{   
    public static BossManager instance;
    public CharacterStatus characterStatus;
    public BossAnimation bossAnimation;
    Phase phase = Phase.Phase0;
    public bool isUnbeatable;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
        }

        characterStatus = GetComponent<CharacterStatus>();
        bossAnimation = GetComponent<BossAnimation>();
    }

    void Start() {
        
    }

    void Update() {
        
    }

    void PhaseCheck() {
        
    }

    void Phase1Gimmik() {
        if (phase == Phase.Phase1) {

        }
    }

    void Phase2Gimmik() {
        if (phase == Phase.Phase2) {
            
        }
    }

    void Phase3Gimmik() {
        if (phase == Phase.Phase3) {
            
        }
    }

    void UnbeatableMode() {
        if (isUnbeatable) {

        }
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
		StageControl.Instance.bossClear = true;
	}
}
