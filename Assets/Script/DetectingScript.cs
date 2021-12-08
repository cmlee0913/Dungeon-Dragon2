using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectingScript : MonoBehaviour
{

    public Text remainTimeText;

    public float glassTime;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] ClockingObject = GameObject.FindGameObjectsWithTag("Clocking");
        if (glassTime > 0.0f)
        {
            
            for (int i = 0; i < ClockingObject.Length; i++)
            {
                if (ClockingObject[i] == null) return;
                ClockingObject[i].GetComponent<FireballClocking>().hasGlass = true;
            }
            glassTime -= Time.deltaTime;
        }


        if (glassTime <= 0.0f)
        {
            for (int i = 0; i < ClockingObject.Length; i++)
            {
                if (ClockingObject[i] == null) return;
                ClockingObject[i].GetComponent<FireballClocking>().hasGlass = false;
            }
            this.gameObject.SetActive(false);
        }

        remainTimeText.text = glassTime.ToString("F1");
    }

    public void ActivaitingGlass()
    {
       

        glassTime = 15.0f;

    }

  
}
