using UnityEngine;
using System.Collections;

public class RocketBehaviour : MonoBehaviour {
    public GameObject explosion;
    private float rocketTime;

	// Use this for initialization
	void Start () {
        this.rocketTime = Time.time + 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
     
        this.transform.Translate(Vector3.forward * 20.0f * Time.deltaTime);
        if (this.rocketTime <= Time.time)
        {
            Destroy(this.gameObject);
        }

  
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Drone" && other.gameObject.tag != "AimArea")
        {
            Instantiate(this.explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
