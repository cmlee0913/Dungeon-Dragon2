using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3ItemBox : MonoBehaviour
{
    public GameObject item;

    public bool is_item = false;

    CharacterStatus status;

    // Start is called before the first frame update
    void Start()
    {
        status = GetComponent<CharacterStatus>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(CHAR_AttackArea.AttackInfo attackInfo)
    {
        status.HP -= attackInfo.attackPower;
        if(status.HP <= 0)
        {
            status.HP = 0;
            ItemDrop();
        }
    }

    public void ItemDrop()
    {
        if (is_item)
        {
            Instantiate(item);
            item.transform.position = this.gameObject.transform.position;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
