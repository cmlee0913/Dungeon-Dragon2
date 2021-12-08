using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public bool isAttack;
    public bool attacking;
    BossAnimation bossAnimation;
    Vector3 zero = Vector3.zero;
    void Awake() {
        bossAnimation = transform.root.GetComponent<BossAnimation>();
    }

    void OnTriggerStay(Collider other) {
        if (!isAttack && other.tag == "Player" && !BossManager.instance.isUnbeatable) {
            isAttack = true;
            bossAnimation.AttackStartAnimation();
            Invoke("AttackDelay", Random.Range(3, 5));
        }
        if (!attacking && other.tag == "Player") {
            transform.root.LookAt(other.gameObject.transform.position);
        }
    }

    void AttackDelay() {
        isAttack = false;
    }
}
