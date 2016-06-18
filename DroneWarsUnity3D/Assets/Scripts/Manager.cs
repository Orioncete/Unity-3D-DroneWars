using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    
    [HideInInspector]
	public Drone[] drones; // list of drones
	
	public static Manager instance; // static var to make a pseudo-singleton class
    
	void Awake()
	{
		instance = this;
		drones = FindObjectsOfType<Drone>(); // find the drones in the scene

	} 

}
