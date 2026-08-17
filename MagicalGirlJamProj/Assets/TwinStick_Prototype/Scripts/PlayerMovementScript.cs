using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody rb;
	Vector2 input;
	Vector3 mousePos;
    Camera mainCamera;
	float currentSpeed;
	public float walkSpeed;

    void Start()
    {
        mainCamera=Camera.main;
		currentSpeed = walkSpeed;
        rb = GetComponent<Rigidbody>();  
    }

    void OnMove(InputValue inputValue)
    {
		Vector2 inputDirection = inputValue.Get<Vector2>();
		rb.linearVelocity = new Vector3(inputDirection.x, 0, inputDirection.y) * currentSpeed;
    }

    void OnLook(InputValue inputValue)
    {
      input = inputValue.Get<Vector2>();
		Ray ray = mainCamera.ScreenPointToRay(input);
		Plane plane = new Plane(Vector3.up, Vector3.zero);

		if (plane.Raycast(ray, out float distance))
		{
			Vector3 mousePos = ray.GetPoint(distance);
			transform.LookAt(new Vector3(mousePos.x, transform.position.y, mousePos.z));
		}
	}
}
