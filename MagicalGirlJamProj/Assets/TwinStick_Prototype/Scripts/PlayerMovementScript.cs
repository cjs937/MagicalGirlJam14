using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovementScript : MonoBehaviour
{
	Rigidbody rb;
	Vector2 input;
	Vector2 inputDirection;

	Camera mainCamera;
	float currentSpeed;

	public bool swinging;
	public float walkSpeed;

	public bool dashing;
	public float dashTime;
	public float dashSpeed;
	float currentDashTime;

	void Start()
	{
		mainCamera = Camera.main;
		currentSpeed = walkSpeed;
		rb = GetComponent<Rigidbody>();
	}

	void OnMove(InputValue inputValue)
	{
		inputDirection = inputValue.Get<Vector2>();
	}

	void OnLook(InputValue inputValue)
	{
		if (swinging) return;

		input = inputValue.Get<Vector2>();
	}

	private void FixedUpdate()
	{
		MoveCharacter();
		AimCharacter();
	}

	void MoveCharacter()
	{
		rb.linearVelocity = new Vector3(inputDirection.x, 0, inputDirection.y) * currentSpeed;
	}

	void AimCharacter()
	{
		Ray ray = mainCamera.ScreenPointToRay(input);
		Plane plane = new Plane(Vector3.up, Vector3.zero);

		if (plane.Raycast(ray, out float distance))
		{
			Vector3 mousePos = ray.GetPoint(distance);
			mousePos.y = transform.position.y;
		
			Vector3 normal=Vector3.Normalize(mousePos - transform.position);
			transform.rotation=Quaternion.Euler(
				0, Mathf.Atan2(normal.x, normal.z) * Mathf.Rad2Deg, 0);
		}
	}
}