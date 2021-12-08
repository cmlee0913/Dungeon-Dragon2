using UnityEngine;
using System.Collections;

// ĳ���͸� �̵���Ų��.

public class MonsterMove : MonoBehaviour
{
	// �߷°�.
	const float GravityPower = 9.8f;
	//���������� �����ߴٰ� ���� ���� �Ÿ�.
	const float StoppingDistance = 0.006f;

	// ���� �̵� �ӵ�.
	Vector3 velocity = Vector3.zero;
	// ĳ���� ��Ʈ�ѷ��� ĳ��.
	CharacterController characterController;
	// �����ߴ°�(�����ߴ� true / �������� �ʾҴ� false).
	public bool arrived = false;

	// ������ ������ �����ϴ°�.
	bool forceRotate = false;

	// ������ ���ϰ� �ϰ� ���� ����.
	Vector3 forceRotateDirection;

	// ������.
	public Vector3 destination;

	// �̵� �ӵ�.
	public float walkSpeed = 6.0f;

	// ȸ�� �ӵ�.
	public float rotationSpeed = 360.0f;



	// Use this for initialization
	void Start()
	{
		characterController = GetComponent<CharacterController>();
		destination = transform.position;
	}

	// Update is called once per frame
	void Update()
	{

		// �̵� �ӵ� velocity�� �����Ѵ�.
		if (characterController.isGrounded)
		{
			// ����鿡�� �̵��� ����ϹǷ� XZ�� �ٷ��.
			Vector3 destinationXZ = destination;
			// �������� ���� ��ġ ���̸� �Ȱ��� �Ѵ�.
			destinationXZ.y = transform.position.y;

			//********* ���⼭���� XZ������ �����Ѵ�. ********
			// ���������� �Ÿ��� ������ ���Ѵ�.
			Vector3 direction = (destinationXZ - transform.position).normalized;
			float distance = Vector3.Distance(transform.position, destinationXZ);

			// ���� �ӵ��� �����Ѵ�.
			Vector3 currentVelocity = velocity;

			//���������� ������ ������ ����.
			if (distance < StoppingDistance)
			{
				arrived = true;
				//Debug.Log($"��ġ �Ÿ���:{distance }");
			}


			// �̵� �ӵ��� ���Ѵ�.
			if (arrived)
				velocity = Vector3.zero;
			else
				velocity = direction * walkSpeed;


			// �ε巴�� ���� ó��.
			velocity = Vector3.Lerp(currentVelocity, velocity, Mathf.Min(Time.deltaTime * 5.0f, 1.0f));
			velocity.y = 0;


			if (!forceRotate)
			{
				// �ٲٰ� ���� �������� �����Ѵ�. 
				if (velocity.magnitude > 0.1f && !arrived)
				{
					// �̵����� �ʾҴٸ� ������ �������� �ʴ´�.
					Quaternion characterTargetRotation = Quaternion.LookRotation(direction);
					transform.rotation = Quaternion.RotateTowards(transform.rotation, characterTargetRotation, rotationSpeed * Time.deltaTime);
				}
			}
			else
			{
				// ������ ������ �����Ѵ�.
				Quaternion characterTargetRotation = Quaternion.LookRotation(forceRotateDirection);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, characterTargetRotation, rotationSpeed * Time.deltaTime);
			}

		}

		// �߷�.
		velocity += Vector3.down * GravityPower * Time.deltaTime;

		// ���� ��� �ִٸ� ������ �� ������.
		// (����Ƽ�� CharactorController Ư�� ������).
		Vector3 snapGround = Vector3.zero;
		if (characterController.isGrounded)
			snapGround = Vector3.down;

		// CharacterController�� ����ؼ� �����δ�.
		characterController.Move(velocity * Time.deltaTime + snapGround);

		if (characterController.velocity.magnitude < 0.1f)
			arrived = true;

		// ������ ���� ������ �����Ѵ�.
		if (forceRotate && Vector3.Dot(transform.forward, forceRotateDirection) > 0.99f)
			forceRotate = false;


	}

	// �������� �����Ѵ�. �μ� destination�� ������.
	public void SetDestination(Vector3 destination)
	{
		arrived = false;
		this.destination = destination;
	}

	// ������ �������� ���Ѵ�.
	public void SetDirection(Vector3 direction)
	{
		forceRotateDirection = direction;
		forceRotateDirection.y = 0;
		forceRotateDirection.Normalize();
		forceRotate = true;
	}

	// �̵��� �׸��д�.
	public void StopMove()
	{
		// ���� ������ �������� �Ѵ�.
		destination = transform.position;
	}

	// �������� �����ߴ��� �����Ѵ�(�����ߴ� true / �������� �ʾҴ� false).
	public bool Arrived()
	{
		return arrived;
	}


}
