using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_AttackArea : MonoBehaviour
{
    CHAR_CharacterStatus status;

    void Start()
    {
        status = transform.root.GetComponent<CHAR_CharacterStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

		
	public class AttackInfo
	{
		public int attackPower; // 이 공격의 공격력.
		public Transform attacker; // 공격자.
	}

	AttackInfo GetAttackInfo()
	{			
		AttackInfo attackInfo = new AttackInfo();
		attackInfo.attackPower = status.Power;
		
		attackInfo.attacker = transform.root;
		
		return attackInfo;
	}
	
	// 맞았다.
	void OnTriggerEnter(Collider other)
	{
		// 공격 당한 상대의 Damage 메시지를 보낸다.
		other.SendMessage("Damage",GetAttackInfo());
		status.lastAttackTarget = other.transform.root.gameObject;
	}

    void OnAttack()
	{
		GetComponent<Collider>().enabled = true;
	}
	
	void OnAttackTermination()
	{
		GetComponent<Collider>().enabled = false;
	}
}
