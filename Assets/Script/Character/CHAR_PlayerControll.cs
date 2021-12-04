using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_PlayerControll : MonoBehaviour
{
    float horizontal;
    float vertical;
    public float speed;
    public float velocity;
    public float rotateSpeed;
    bool isMove = false;
    public bool isAttackReady = true;
    public bool died = false;
    public bool isDrained = false;
    public Animator playerAnimator;
    public float eulerAnglesY; 
    public float RecoveryTime = 0;
    public bool s1check;
    public bool s1ready;

    public AudioSource AttackSound;
    public AudioSource WalkSound;
    public ImgsFillDynamic imgsFillDynamic;
    CHAR_CharacterStatus cHAR_CharacterStatus;
    public CHAR_SkillUI cHAR_SkillUI;

    void Awake() {
        cHAR_CharacterStatus = GetComponent<CHAR_CharacterStatus>();
    }

    void Start() {
        WalkSound.mute = true;
        if (imgsFillDynamic)
            imgsFillDynamic.SetValue(1f, false, 0.3f);
    }

    void Update() {
        s1ready = cHAR_SkillUI.Skill1_able;
        s1check = StageControl.Instance.stage1Clear;
        imgsFillDynamic.SetValue(cHAR_CharacterStatus.stamina / 100, false, 4F);
        AnimatorUpdate();
        SpeedControll();
        Attack();
        playerSound();
        SkillQ();
    }

    void FixedUpdate() {
        Move();
        Rotate();
        Stamina();
    }

    void Move() {
        vertical = died ? 0 : Input.GetAxis("Vertical");

        Vector3 playerDir = transform.forward * vertical;

        if (!died) {
            if (vertical != 0) {
                if (Input.GetKey(KeyCode.LeftShift) && cHAR_CharacterStatus.stamina > 0) {
                RecoveryTime = 0;
                cHAR_CharacterStatus.stamina -= 0.4f;
                if (4.8f <= speed && speed < 8f)
                    speed += 0.2f;
                if (speed < 5f)
                    if (vertical != 0)
                        speed += 0.2f;
                if (speed == 8f)
                    speed = 8f;
                if (speed == 0)
                    speed = 0;
                }

                else if (!Input.GetKey(KeyCode.LeftShift) || cHAR_CharacterStatus.stamina <= 0) {
                Recovery();
                if (speed < 5f)
                    if (vertical != 0)
                        speed += 0.2f;
                if (speed > 5f)     
                    speed -= 0.2f;
                if (speed == 5f)
                    speed = 5f;
                if (speed == 0)
                    speed = 0;
                }
            }
            else if (vertical == 0) {
                Recovery();
            }
        }

        if (vertical != 0) {
            isMove = true;
        }
        else if (vertical == 0) {
            isMove = false; 
        }

        if (isMove) {
            transform.position += playerDir * speed * Time.deltaTime * velocity;
        }
    }

    void playerSound()
    {
        if (vertical != 0)
        {
            WalkSound.mute = false;
        }
        else if (vertical == 0)
        {
            WalkSound.mute = true;
        }
    }

    void Rotate() {
        horizontal = died ? 0 : Input.GetAxisRaw("Horizontal");
        Vector3 playerRotation = transform.rotation.eulerAngles;
        eulerAnglesY = playerRotation.y + (horizontal * rotateSpeed);

        transform.rotation = Quaternion.Euler(0, eulerAnglesY, 0);
    }

    void SpeedControll()
    {
        if (Input.GetAxisRaw("Vertical") == 0)
        {
            if (speed > 0)
                speed -= 0.3f;
            if (speed < 0)
                speed = 0;
            if (speed == 0)
                speed = 0;
        }
    }

    void Stamina() {
        if (cHAR_CharacterStatus.stamina <= 0) {
            cHAR_CharacterStatus.stamina = 0;
        }
        if (cHAR_CharacterStatus.stamina >= 100) {
            cHAR_CharacterStatus.stamina = 100;
        }
    }
    
    void Recovery() {
        if (cHAR_CharacterStatus.stamina >= 100) {
            RecoveryTime = 0;
            return;
        }
        RecoveryTime += Time.fixedDeltaTime;
        if (RecoveryTime > 2)
            cHAR_CharacterStatus.stamina += 0.6f;
    }

	void Attack()
	{
        if (Input.GetKeyDown(KeyCode.A) && isAttackReady) {
            StartCoroutine(attackSoundOn());
            playerAnimator.SetTrigger("isAttack");
		    playerAnimator.SetBool("Attacking", true);
        }
        else if (Input.GetKeyDown(KeyCode.S) && isAttackReady && StageControl.Instance.stage4Clear) {
            StartCoroutine(attackSoundOn());
            playerAnimator.SetTrigger("isPowerAttack");
		    playerAnimator.SetBool("Attacking", true);
        }    
	}

    void AnimatorUpdate() {
        playerAnimator.SetBool("isMove", isMove);
        playerAnimator.SetFloat("MoveSpeed", speed * vertical);
        playerAnimator.SetFloat("stamina", cHAR_CharacterStatus.stamina);
    }

    void StartMove()
	{
		Debug.Log ("StartMove");
	}

    void StartAttack()
	{
        isAttackReady = false;
	}

    void EndAttack()
	{
        playerAnimator.SetBool("Attacking", false);
        isAttackReady = true;
	}

    void StartPowerAttack()
	{
        Debug.Log ("UsePowerAttack");
		isAttackReady = false;
        cHAR_CharacterStatus.Power = 50;
        cHAR_CharacterStatus.stamina -= 20;
        RecoveryTime = 0;
	}

	void EndPowerAttack()
	{
		playerAnimator.SetBool("Attacking", false);
        cHAR_CharacterStatus.Power = 20;
        isAttackReady = true;
	}

    void SkillQ() {
        if (s1check && Input.GetKeyDown(KeyCode.Q) && s1ready) {
            Debug.Log("Skill Q");
            cHAR_CharacterStatus.stamina = 100;
        }
    }

    IEnumerator attackSoundOn()
    {
        yield return new WaitForSeconds(0.1f);
        if (AttackSound.isPlaying != true)
        {
            AttackSound.Play();
        }
        yield return new WaitForSeconds(2f);
    }
}
