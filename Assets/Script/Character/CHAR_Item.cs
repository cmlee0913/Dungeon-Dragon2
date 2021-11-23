using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_Item : MonoBehaviour
{
    public int itemCount;

    void OnTriggerEnter(Collider item) {
        if (item.tag == "Item") {
            Destroy(item.gameObject);
            itemCount++;
        }
    }
}
