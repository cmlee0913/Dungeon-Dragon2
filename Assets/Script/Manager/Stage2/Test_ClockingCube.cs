using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ClockingCube : MonoBehaviour
{
    public bool isClocking;

    public bool hasGlass;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        isClocking = false;
        hasGlass = false;
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGlass)
        {
            if (isClocking)
            {
                this.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                this.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.tag == "Player")
        {
            StartCoroutine(ResetPosition());
        }
    }

    IEnumerator ResetPosition()
    {

        yield return new WaitForSeconds(2.0f);

        Player.transform.position = new Vector3(-35.0f, 0.0f, 16.5f);
    }
}
