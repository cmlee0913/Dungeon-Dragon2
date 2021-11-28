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
        if(isPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            patternManager.TakeAnswerPuzzle(patternManager.CheckPuzzleAnswer());
        }

        if(Input.GetKeyDown(KeyCode.R)) // µð¹ö±ë¿ë
        {
            patternManager.puzzleLevel = 5;
            patternManager.ClearPuzzle();
        }
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
