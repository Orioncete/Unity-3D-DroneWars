using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{
	public Vector3 offset = new Vector3(0f, 15f, -4f);
	
	Drone drone; // drone that will be followed
	Vector3 targetPos; // calculate a position based on the followed drone
	
	void Start()
	{
		// find the first drone with human input mode
		for (int i = 0; i < Manager.instance.drones.Length; i++)
			if (Manager.instance.drones[i].inputMode == Drone.InputMode.Human)
			{
				drone = Manager.instance.drones[i];
				break;
			}
	}
	
	void FixedUpdate()
	{
        if (!drone)
        {
            this.transform.position = new Vector3(0.0f, 27.0f, -8.9f);
            return;
        }
		
		targetPos = drone.transform.position + drone.rigidbody.velocity * 0.5f; // take an advanced position
		targetPos.y = 0f;
		
		// adapt camera position to newly calculated one + offset
		transform.position =
			Vector3.Lerp(
				transform.position,
				targetPos + offset,
				Time.deltaTime * 4f);
	}
}
