using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    public bool isPlayer;
    public int CurrentStage;
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
            StageControl.Instance.StageClear(CurrentStage);
            SceneManager.LoadScene("Lobby");
            
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
