using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    public bool isPlayer;
    public int CurrentStage;
    SCE_SceneChangeEffect sCE_SceneChangeEffect;

    void Awake() {
        sCE_SceneChangeEffect = FindObjectOfType<SCE_SceneChangeEffect>().GetComponent<SCE_SceneChangeEffect>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            sCE_SceneChangeEffect.gameObject.SetActive(true);
            sCE_SceneChangeEffect.startFadeOut = true;
        }
        
        if (sCE_SceneChangeEffect.checkFadeOut) {
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
