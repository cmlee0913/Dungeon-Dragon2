using UnityEngine;
using System.Collections;

public class HitArea : MonoBehaviour {

	public void Damage(CHAR_AttackArea.AttackInfo attackInfo)
	{
		transform.root.SendMessage("Damage", attackInfo);
		Debug.Log("공격받았다");
	}
}
