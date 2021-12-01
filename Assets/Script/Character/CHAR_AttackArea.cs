using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_AttackArea : MonoBehaviour
{
    CHAR_CharacterStatus status;
	public GameObject hitEffect;
	public GameObject rooot;
	
    void Start()
    {
        status = transform.root.GetComponent<CHAR_CharacterStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        rooot = transform.root.gameObject;
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
		Debug.Log("들어갔다");
		other.SendMessage("Damage",GetAttackInfo());

        Debug.Log("보내졌다");
		GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
        effect.transform.localPosition = transform.position + new Vector3(0.5f, 0.5f, 0.0f);
        Destroy(effect, 0.3f); //이펙트
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
