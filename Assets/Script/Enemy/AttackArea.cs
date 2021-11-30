using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour {
	CharacterStatus status;
	
	void Start()
	{
		status = transform.root.GetComponent<CharacterStatus>();
	}
	
	
	public class AttackInfo
	{
		public int attackPower; // 이 공격의 공격력.
		public int shootPower;
		public Transform attacker; // 공격자.
	}
	
	
	// 공격 정보를 가져온다.
	AttackInfo GetAttackInfo()
	{			
		AttackInfo attackInfo = new AttackInfo();
		// 공격력 계산.
		attackInfo.attackPower = status.Power;
		attackInfo.attacker = transform.root;
		
		return attackInfo;
	}
	
	// 맞았다.
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("들어갔다");
		other.SendMessage("Damage",GetAttackInfo());

        Debug.Log("보내졌다");
		status.lastAttackTarget = other.transform.root.gameObject;
	}
	
	
	// 공격 판정을 유효로 한다.
	void OnAttack()
	{
		GetComponent<Collider>().enabled = true;
	}
	
	
	// 공격 판정을 무효로 한다.
	void OnAttackTermination()
	{
		GetComponent<Collider>().enabled = false;
	}
}
