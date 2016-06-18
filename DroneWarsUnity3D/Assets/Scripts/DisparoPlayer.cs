using UnityEngine;
using System.Collections;

public class DisparoPlayer : MonoBehaviour {
    public GameObject proyectil;
    public GameObject apuntado;
    private float retardo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.retardo <= Time.time)
        {
            this.apuntado.transform.rotation = this.transform.rotation;
            this.apuntado.transform.position = this.transform.position;

            if (Input.GetButtonDown("D"))
            {
                this.apuntado.transform.Rotate(Vector3.up * 90.0f);
                this.apuntado.transform.Translate(Vector3.forward * 1.5f);
                Instantiate(this.proyectil, this.apuntado.transform.position, this.apuntado.transform.rotation);
                this.retardo = Time.time + 1.0f;
            }

            if (Input.GetButtonDown("A"))
            {
                this.apuntado.transform.Rotate(-Vector3.up * 90.0f);
                this.apuntado.transform.Translate(Vector3.forward * 1.5f);
                Instantiate(this.proyectil, this.apuntado.transform.position, this.apuntado.transform.rotation);
                this.retardo = Time.time + 1.0f;
            }

            if (Input.GetButtonDown("S"))
            {
                this.apuntado.transform.Rotate(Vector3.right * 180.0f);
                this.apuntado.transform.Translate(Vector3.forward * 1.5f);
                Instantiate(this.proyectil, this.apuntado.transform.position, this.apuntado.transform.rotation);
                this.retardo = Time.time + 1.0f;
            }

            if (Input.GetButtonDown("W"))
            {
                this.apuntado.transform.Translate(Vector3.forward * 1.5f);
                Instantiate(this.proyectil, this.apuntado.transform.position, this.apuntado.transform.rotation);
                this.retardo = Time.time + 1.0f;
            }
        }

    }

}
