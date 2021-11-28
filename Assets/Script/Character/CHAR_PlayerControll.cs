using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_PlayerControll : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float speed;
    public float velocity;
    public float rotateSpeed;
    public bool isMove = false;
    public bool fdown;
    public bool isAttackReady = true;
    public bool died = false;
    public bool isDrained = false;
    public Animator playerAnimator;
    public float eulerAnglesY;
    public float stamina = 100f; 
    public float RecoveryTime = 0;

    public AudioSource AttackSound;
    public AudioSource WalkSound;
    public ImgsFillDynamic imgsFillDynamic;
    CHAR_CharacterStatus cHAR_CharacterStatus;

    void Awake() {
        cHAR_CharacterStatus = GetComponent<CHAR_CharacterStatus>();
    }

    void Start() {
        WalkSound.mute = true;
        if (imgsFillDynamic)
            imgsFillDynamic.SetValue(1f, false, 0.3f);
    }

    void Update() {
        imgsFillDynamic.SetValue(stamina / 100, false, 4F);
        AnimatorUpdate();
        SpeedControll();
        Attack();
        playerSound();
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
                if (Input.GetKey(KeyCode.LeftShift) && stamina > 0) {
                RecoveryTime = 0;
                stamina -= 0.4f;
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

                else if (!Input.GetKey(KeyCode.LeftShift) || stamina <= 0) {
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
        if (stamina <= 0) {
            stamina = 0;
        }
        if (stamina >= 100) {
            stamina = 100;
        }
    }
    
    void Recovery() {
        if (stamina >= 100) {
            RecoveryTime = 0;
            return;
        }
        RecoveryTime += Time.fixedDeltaTime;
        if (RecoveryTime > 2)
            stamina += 0.6f;
    }

	void Attack()
	{
        if (Input.GetKeyDown(KeyCode.A) && isAttackReady) {
            StartCoroutine(attackSoundOn());
            playerAnimator.SetTrigger("isAttack");
		    playerAnimator.SetBool("Attacking", true);
        }
        else if (Input.GetKeyDown(KeyCode.S) && isAttackReady) {
            StartCoroutine(attackSoundOn());
            playerAnimator.SetTrigger("isPowerAttack");
		    playerAnimator.SetBool("Attacking", true);
        }    
	}

    void AnimatorUpdate() {
        playerAnimator.SetBool("isMove", isMove);
        playerAnimator.SetFloat("MoveSpeed", speed * vertical);
        playerAnimator.SetFloat("stamina", stamina);
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
		isAttackReady = false;
        cHAR_CharacterStatus.Power = 20;
        stamina -= 10;
        RecoveryTime = 0;
	}

	void EndPowerAttack()
	{
		playerAnimator.SetBool("Attacking", false);
        cHAR_CharacterStatus.Power = 10;
        isAttackReady = true;
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
