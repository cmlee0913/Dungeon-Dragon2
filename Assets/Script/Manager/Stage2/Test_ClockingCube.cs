using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_ClockingCube : MonoBehaviour
{
    public bool isClocking;

    public bool hasGlass;

    public GameObject Player;
    GameObject DeadPanel;
    Image Panel;
    float time = 0f;
    float F_time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        isClocking = false;
        hasGlass = false;
        Player = GameObject.FindWithTag("Player");
        DeadPanel = GameObject.FindWithTag("deadPanel");
        Panel = DeadPanel.GetComponent<Image>();
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
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;

        yield return new WaitForSeconds(0.5f);
        Player.transform.position = new Vector3(-35.0f, 0.0f, 16.5f);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
    }

}
