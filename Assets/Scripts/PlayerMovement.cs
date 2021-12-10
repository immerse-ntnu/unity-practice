using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float speed = 500;
	[SerializeField] private float jumpForce;
	private const float RAY_LENGTH = 0.05f;
	private Rigidbody _rb;

	//Will not detect ground if 0.5f instead of 0.49f
	private bool CanJump =>
		Physics.Raycast(transform.position - new Vector3(0, 0.49f), Vector3.down, out _, RAY_LENGTH);

	private void Awake() => _rb = GetComponent<Rigidbody>();

	private void Update()
	{
		Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized);
		if (Input.GetKeyDown(KeyCode.Space) && CanJump)
			Jump();
	}

	private void Jump() => _rb.AddForce( jumpForce * Vector3.up, ForceMode.Impulse);

	public void Move(Vector3 movement) => _rb.AddForce(movement * (speed * Time.deltaTime));
}
