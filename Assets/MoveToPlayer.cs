using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour {
    NavMeshAgent agent; 
    Transform target;
    public bool isMove;
    public float distance;

    void Awake() { 
        agent = GetComponent<NavMeshAgent>(); 
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);

        if (!agent.pathPending) {
            if (distance > 20f) {
                agent.isStopped = false;
                agent.SetDestination(target.position);
            }
            else if (distance < 20f) {
                agent.isStopped = true;
            }
        }   

        if (!agent.isStopped && agent.SetDestination(target.position)) {
            isMove = true;
        }
        else {
            isMove = false;
        }

        if (BossManager.instance.characterStatus.died) {
            this.enabled = false;
        }
    }
}
