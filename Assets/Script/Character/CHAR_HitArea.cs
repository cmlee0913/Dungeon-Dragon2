using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_HitArea : MonoBehaviour
{
	void Damage(CHAR_AttackArea.AttackInfo attackInfo)
	{
		transform.root.SendMessage ("Damage",attackInfo);
	}
}
