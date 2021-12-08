using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAnimation : MonoBehaviour
{
    public Animator animator;
    NavMeshAgent navMeshAgent;
    MoveToPlayer moveToPlayer;
    CharacterStatus characterStatus;
    AttackRange attackRange;
    public bool screaming;
    public float fireAttackCoolTime = 15.0f;
    public bool fireAttackReady;
    public GameObject fireEffect;

    void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        moveToPlayer = GetComponent<MoveToPlayer>();
        characterStatus = GetComponent<CharacterStatus>();
        attackRange = GetComponentInChildren<AttackRange>();
    }

    void Update()
    {
        fireAttackCoolTime -= Time.deltaTime;

        if (fireAttackCoolTime <= 0) {
            fireAttackCoolTime = 0;
            fireAttackReady = true;
        }

        animator.SetBool("Screaming", screaming);
        animator.SetBool("isMove", moveToPlayer.isMove);
        animator.SetBool("isDie", characterStatus.died);
    }

    void Pause0Start() {
        screaming = false;
        navMeshAgent.enabled = true;
    }

    public void AttackStartAnimation() {
        int attackForm = Random.Range(0, 3);

        switch (attackForm) {
            case 0:
                animator.SetTrigger("Attack1");
                return;
            case 1:
                animator.SetTrigger("Attack2");
                return;
            case 2:
                if (fireAttackReady) {
                    fireAttackReady = false;
                    fireAttackCoolTime = 15.0f;
                    animator.SetTrigger("FireAttack");
                    StartCoroutine(FireAttack());
                }
                else {
                    animator.SetTrigger("Attack1");
                }
                return;
        }
    }

    void AttackStart() {
        attackRange.attacking = true;
    }

    void AttackEnd() {
        attackRange.attacking = false;
    }

    IEnumerator FireAttack()
    {
        yield return new WaitForSeconds(0.2f);
        fireEffect.SetActive(true);
        yield return new WaitForSeconds(2.3f);
        fireEffect.SetActive(false);
    }
}
