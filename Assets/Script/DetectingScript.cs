using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectingScript : MonoBehaviour
{
    public List<GameObject> ClockingObject;

    public Text remainTimeText;

    public float glassTime;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (glassTime > 0.0f)
            glassTime -= Time.deltaTime;

        if (glassTime <= 0.0f)
        {
            for (int i = 0; i < ClockingObject.Count; i++)
            {
                ClockingObject[i].GetComponent<Test_ClockingCube>().hasGlass = false;
            }
            ResetClockingObject();
            this.gameObject.SetActive(false);
        }

        remainTimeText.text = glassTime.ToString("F1");
    }

    public void ActivaitingGlass()
    {
        ClockingObject.Add(GameObject.FindWithTag("Clocking"));

        glassTime = 15.0f;

        for (int i = 0; i < ClockingObject.Count; i++)
        {
            ClockingObject[i].GetComponent<Test_ClockingCube>().hasGlass = true;
        }
    }

    public void ResetClockingObject()
    {
        ClockingObject.Clear();
    }
}
