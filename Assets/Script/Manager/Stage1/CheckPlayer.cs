using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    public bool isPlayer;
    TileStatus tileStatus;

    void Start() {
        tileStatus = this.GetComponent<TileStatus>();
    }

    void Update() {
        if (isPlayer && Input.GetKeyDown(KeyCode.Space))
            OnActive();
    }

    void OnCollisionEnter(Collision other) {
        isPlayer = true;
    }

    void OnCollisionExit(Collision other) {
        isPlayer = false;
    }

    void OnActive() {
        tileStatus.isActivated = true;
    }
}
