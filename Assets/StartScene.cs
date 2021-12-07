using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public BossAnimation bossAnimation;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            bossAnimation.animator.SetTrigger("Start");
            bossAnimation.screaming = true;
            Destroy(this.gameObject);
        }
    }
}
