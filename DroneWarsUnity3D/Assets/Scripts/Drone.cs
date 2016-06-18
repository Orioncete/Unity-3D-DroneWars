using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
	public enum InputMode { Human, CPU };
	
	public InputMode	inputMode = InputMode.CPU; // input mode for this drone
	public float		speed = 4f; // max speed
	public float		floatHeight = 2.5f; // desired floating height
	public LayerMask	floatOverLayers; // layers considered as ground
	public float		life = 1f; // health
	
	Vector3	dirForce = Vector3.zero; // direction force
	
	float				propForce = 0f; // propellers force
	RaycastHit			groundHit; // hit info struct
	
	[HideInInspector]
	public Rigidbody	rigidbody; // associated rigidbody (harmless warning)
	
	void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update()
	{
		// take input from human or cpu according to input mode
		switch (inputMode)
		{
			case InputMode.Human:
				GetHumanInput();
				break;
			case InputMode.CPU:
				GetCPUInput();
				break;
		}
	}
	
	void FixedUpdate()
	{
		// detect ground and calculate propellers force against it
		if (Physics.Raycast(transform.position, Vector3.down, out groundHit, floatHeight, floatOverLayers.value))
			propForce = Mathf.InverseLerp(floatHeight, 0f, groundHit.distance) * 2f;
		else
			propForce = 0f; // ground not detected: free fall
		
		// add forces (direction + propellers)
		rigidbody.AddForce(dirForce - propForce * rigidbody.mass * Physics.gravity);
		
		// limit speed
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, speed);
	}
	
	void GetHumanInput()
	{
		// direction force
		dirForce.x = Input.GetAxis("Horizontal") * speed * 10f;
		dirForce.z = Input.GetAxis("Vertical") * speed * 10f;
	}
	
	void GetCPUInput()
	{
		dirForce = Vector3.zero;
	}
}
