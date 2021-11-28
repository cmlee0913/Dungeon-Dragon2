using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    public bool isPlayer;
    public GameObject player;
    TileStatus tileStatus;
    CHAR_Item cHAR_Item;

    void Start() {
        player = GameObject.Find("Player");
        tileStatus = this.GetComponent<TileStatus>();
        cHAR_Item = player.GetComponent<CHAR_Item>();
    }

    void Update() {
        if (isPlayer && Input.GetKeyDown(KeyCode.Space) && (cHAR_Item.itemCount > 0)) {
            OnActive();
        }
    }

    void OnCollisionEnter(Collision other) {
        isPlayer = true;
    }

    void OnCollisionExit(Collision other) {
        isPlayer = false;
    }

    void OnActive() {
        if (tileStatus.isActivated == false) {
            cHAR_Item.itemCount--;
            tileStatus.isActivated = true;
        }
    }
}
