using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CHAR_CharacterStatus : MonoBehaviour {
    public CHAR_PlayerControll cHAR_PlayerControll;

    //---------- 공격 장에서 사용한다. ----------
    // 체력.
    public float HP = 100;
    public int MaxHP = 100;
    public float stamina = 100;
    // 공격력.
    public int Power = 10;
    
    // 마지막에 공격한 대상.
    public GameObject lastAttackTarget = null;
    
    //---------- GUI 및 네트워크 장에서 사용한다. ----------
    // 플레이어 이름.
    public string characterName = "Player";
    
    //--------- 애니메이션 장에서 사용한다. -----------
    // 상태.
    public bool attacking = false;

    // 공격력 강화.
    public bool powerBoost = false;
    // 공격력 강화 시간.
    float powerBoostTime = 0.0f;
    public GameObject healEffect;
    public AudioSource healSound;

    public GameObject GameOverUI;

    void Start()
    {
        healEffect.SetActive(false);
    }
 
    void Update()
    {
        if (HP <= 0 && !cHAR_PlayerControll.died) {
            HP = 0;
            cHAR_PlayerControll.died = true;
            cHAR_PlayerControll.playerAnimator.SetBool("Died", cHAR_PlayerControll.died);
            this.gameObject.tag = "DiePlayer";
            cHAR_PlayerControll.playerAnimator.SetTrigger("isDie");
            StartCoroutine(GoToLobby());
        }
    }

    void Damage(AttackArea.AttackInfo attackInfo) {
        if (!cHAR_PlayerControll.died) {
            cHAR_PlayerControll.playerAnimator.SetTrigger("getHit");
            HP -= attackInfo.attackPower;
        }
    }


    public void HealEffect()
    {
        healSound.Play();
        StartCoroutine(EffectOn());
    }

    IEnumerator EffectOn()
    {
        healEffect.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        healEffect.SetActive(false);
    }

    IEnumerator GoToLobby()
    {
        GameOverUI.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        SceneManager.LoadScene("Lobby");
    }
}
