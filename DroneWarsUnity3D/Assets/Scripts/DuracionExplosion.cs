using UnityEngine;
using System.Collections;

public class DuracionExplosion : MonoBehaviour {

    private float duracion;

	// Use this for initialization
	void Start () {
        this.duracion = Time.time + 2.5f;
	}
	
	// Update is called once per frame
	void Update () {
	    if (this.duracion <= Time.time)
        {
            Destroy(this.gameObject);
        }
	}
}
