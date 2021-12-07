using UnityEngine;
using System.Collections;

// ĳ���͸� �̵���Ų��.

public class MonsterMove : MonoBehaviour
{
	const float GravityPower = 9.8f;
	const float StoppingDistance = 0.006f;

	Vector3 velocity = Vector3.zero;
	public bool arrived = false;

	bool forceRotate = false;

	Vector3 forceRotateDirection;

	public Vector3 destination;

	public float walkSpeed = 6.0f;

	public float rotationSpeed = 360.0f;

	void Start()
	{
		destination = transform.position;
	}

	void Update()
	{
		Vector3 destinationXZ = destination;
		destinationXZ.y = transform.position.y;

		Vector3 direction = (destinationXZ - transform.position).normalized;
		float distance = Vector3.Distance(transform.position, destinationXZ);

		Vector3 currentVelocity = velocity;

		if (distance < StoppingDistance)
		{
			arrived = true;
		}

		if (arrived)
			velocity = Vector3.zero;
		else
			velocity = direction * walkSpeed;

		velocity = Vector3.Lerp(currentVelocity, velocity, Mathf.Min(Time.deltaTime * 5.0f, 1.0f));
		velocity.y = 0;


		if (!forceRotate)
		{
			if (velocity.magnitude > 0.1f && !arrived)
			{
				Quaternion characterTargetRotation = Quaternion.LookRotation(direction);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, characterTargetRotation, rotationSpeed * Time.deltaTime);
			}
		}
		else
		{
			Quaternion characterTargetRotation = Quaternion.LookRotation(forceRotateDirection);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, characterTargetRotation, rotationSpeed * Time.deltaTime);
		}

		velocity += Vector3.down * GravityPower * Time.deltaTime;

		Vector3 snapGround = Vector3.zero;

		//if (characterController.velocity.magnitude < 0.1f)
			arrived = true;

		if (forceRotate && Vector3.Dot(transform.forward, forceRotateDirection) > 0.99f)
			forceRotate = false;
	}

	public void SetDestination(Vector3 destination)
	{
		arrived = false;
		this.destination = destination;
	}

	public void SetDirection(Vector3 direction)
	{
		forceRotateDirection = direction;
		forceRotateDirection.y = 0;
		forceRotateDirection.Normalize();
		forceRotate = true;
	}

	public void StopMove()
	{
		destination = transform.position;
	}

	public bool Arrived()
	{
		return arrived;
	}
}
