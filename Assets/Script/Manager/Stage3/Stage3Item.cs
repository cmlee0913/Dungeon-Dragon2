using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3Item : MonoBehaviour
{
    [SerializeField]
    SCE_SceneChangeEffect sCE_SceneChangeEffect;
    public bool playerIn;

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

        if (sCE_SceneChangeEffect.checkFadeOut) {
            Stage3Manager.instance.is_poison = false;
            StageControl.Instance.StageClear(3);
            SceneManager.LoadScene("Lobby");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIn = true;
        }
    }
}
