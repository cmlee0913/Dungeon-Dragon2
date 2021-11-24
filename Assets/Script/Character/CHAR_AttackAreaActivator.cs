using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_AttackAreaActivator : MonoBehaviour
{
    Collider[] attackAreaColliders; // 공격 판정 컬라이더 배열.
    CHAR_AttackArea[] attackAreas;

    void Start()
    {
        attackAreas = GetComponentsInChildren<CHAR_AttackArea>();
        attackAreaColliders = new Collider[attackAreas.Length];

        for (int attackAreaCnt = 0; attackAreaCnt < attackAreas.Length; attackAreaCnt++) {
			// AttackArea 스크립트가 추가된 오브젝트의 컬라이더를 배열에 저장한다.
			attackAreaColliders[attackAreaCnt] = attackAreas[attackAreaCnt].GetComponent<Collider>();
			attackAreaColliders[attackAreaCnt].enabled = false;  // 초깃값은 false로 한다.
		}
    }

    void StartAttackHit()
	{
		foreach (Collider attackAreaCollider in attackAreaColliders)
			attackAreaCollider.enabled = true;
	}

	void EndAttackHit()
	{
		foreach (Collider attackAreaCollider in attackAreaColliders)
			attackAreaCollider.enabled = false;
	}
}
