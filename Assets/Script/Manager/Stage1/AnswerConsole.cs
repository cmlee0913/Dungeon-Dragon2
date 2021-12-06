using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerConsole : MonoBehaviour
{
    public Stage1Pattern patternManager;
    public bool isPlayer;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        isPlayer = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            patternManager.TakeAnswerPuzzle(patternManager.CheckPuzzleAnswer());
            Player.GetComponent<CHAR_CharacterStatus>().HP = Player.GetComponent<CHAR_CharacterStatus>().MaxHP;
            Player.GetComponent<CHAR_CharacterStatus>().HealEffect();
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
