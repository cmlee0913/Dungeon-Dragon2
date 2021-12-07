using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Lobby : MonoBehaviour
{
    public int stageNumber;
    SCE_SceneChangeEffect sCE_SceneChangeEffect;
    bool playerIn;

    void Awake() {
        sCE_SceneChangeEffect = FindObjectOfType<SCE_SceneChangeEffect>().GetComponent<SCE_SceneChangeEffect>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn) {
            sCE_SceneChangeEffect.gameObject.SetActive(true);
            sCE_SceneChangeEffect.startFadeOut = true;
        }

        if (sCE_SceneChangeEffect.checkFadeOut && playerIn)
            SceneChange();
    }

    public void SceneChange()
    {
       switch(stageNumber)
       {
            case 1:
                Debug.Log("LoadStage1");
                SceneManager.LoadScene("Stage1");
                break;
            case 2:
                Debug.Log("LoadStage2");
                SceneManager.LoadScene("Stage2");
                break;
            case 3:
                Debug.Log("LoadStage3");
                SceneManager.LoadScene("Stage3");
                break;
            case 4:
                Debug.Log("LoadStage4");
                SceneManager.LoadScene("Stage4");
                break;
            case 5:
                SceneManager.LoadScene("Boss");
                break;
        }
            
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            playerIn = true;
        }
    }
}
