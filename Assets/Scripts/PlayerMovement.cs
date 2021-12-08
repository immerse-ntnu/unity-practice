using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	private Rigidbody _rb;
	private Vector3 _movement;
	[SerializeField] private float speed = 500;
	[SerializeField] private float rayLength = 0.05f;

	private void Awake() => _rb = GetComponent<Rigidbody>();

	private bool CanJump(Ray ray) => Physics.Raycast(ray, out _, rayLength);

	private void Update()
	{
		Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
		TryJump();
	}

	private void TryJump()
	{
		var ray = new Ray(transform.position + Vector3.down * 0.5f, Vector3.down);
		DebugRay(ray);
		if (!Input.GetKeyDown(KeyCode.Space))
			return;
		var jump = CanJump(ray);
		print($"jump is {jump}");
		if (jump)
			Jump();
	}

	private void DebugRay(Ray ray) => Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

	private void Jump() => _rb.AddForce( 500 * Vector3.up, ForceMode.Impulse);

	public void Move(Vector3 movement) => _rb.AddForce(movement * (speed * Time.fixedDeltaTime));
}
