using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_PlayerControll : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    float speed;
    public float velocity;
    public float rotateSpeed;
    bool isMove = false;
    public bool fdown;
    public bool isAttackReady = true;
    public Animator playerAnimator;
    public float eulerAnglesY;

    void Awake() {

    }

    void Start() {
        
    }

    void Update() {
        AnimatorUpdate();
        SpeedControll();
        Attack();
    }

    void FixedUpdate() {
        Move();
        Rotate();
    }

    void Move() {
        vertical = Input.GetAxis("Vertical");

        Vector3 playerDir = transform.forward * vertical;

        if (Input.GetKey(KeyCode.LeftShift)) // 대쉬 중일 때
        {
            if (4.8f <= speed && speed < 8f)
                speed += 0.2f;
            if (speed < 5f)
                if (vertical != 0)
                    speed += 0.2f;
            if(speed == 8f)
                speed = 8f;
            if (speed == 0)
                speed = 0;
        }
        else if (!Input.GetKey(KeyCode.LeftShift)) // 대쉬 아닐 때
        {
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

        if (vertical != 0)
        {
            isMove = true;
        }
        else if (vertical == 0)
        {
            isMove = false;
        }

        if (isMove) { // 이동, 회전
            transform.position += playerDir * speed * Time.deltaTime * velocity;
            isMove = false;
        }
    }

    void Rotate() {
        horizontal = Input.GetAxisRaw("Horizontal");
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

	void Attack()
	{
        if (Input.GetKeyDown(KeyCode.A) && isAttackReady) {
            playerAnimator.SetTrigger("isAttack");
		    playerAnimator.SetBool("Attacking", true);
        }        
	}

    void AnimatorUpdate() {
        playerAnimator.SetFloat("MoveSpeed", speed);
    }

    void StartMove()
	{
		Debug.Log ("StartMove");
	}

    void StartAttackHit()
	{
        isAttackReady = false;
	}

    void EndAttack()
	{
        playerAnimator.SetBool("Attacking", false);
        isAttackReady = true;
	}
}
