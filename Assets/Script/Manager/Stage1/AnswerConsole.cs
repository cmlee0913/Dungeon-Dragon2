using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerConsole : MonoBehaviour
{
    public Stage1Pattern patternManager;
    public bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        isPlayer = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            patternManager.TakeAnswerPuzzle(patternManager.CheckPuzzleAnswer());
        }
        this.GetComponent<MeshRenderer>().materials[0].color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }

    void OnCollisionEnter(Collision other)
    {
        isPlayer = true;
    }

    void OnCollisionExit(Collision other)
    {
        isPlayer = false;
    }
}
