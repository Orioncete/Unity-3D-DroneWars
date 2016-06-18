using UnityEngine;
using System.Collections;

// Script básico de búsqueda y seguimiento de caminos. Para ello he creado primero un NavMesh con las paredes y obstáculos.
public class Navigator : MonoBehaviour {

    public Transform target;
    private NavMeshAgent agent;

    private float dimensionAncho;
    private float dimensionLargo;
    private float posicionXAleatorio;
    private float posicionZAleatorio;
    private float retardo;
    public GameObject terreno;

	void Start () {
        this.agent = this.transform.GetComponent<NavMeshAgent>();
        this.dimensionAncho = this.terreno.GetComponent<Renderer>().bounds.size.x;
        this.dimensionLargo = this.terreno.GetComponent<Renderer>().bounds.size.z;
	}

	void Update () {
        if (this.agent.transform.position == this.target.transform.position)
        {
            this.retardo = Time.time;
        }

        if (this.retardo <= Time.time)
        {
            this.posicionXAleatorio = Random.Range((dimensionAncho / 2.0f), -(dimensionAncho / 2.0f));
            this.posicionZAleatorio = Random.Range((dimensionLargo / 2.0f), -(dimensionLargo / 2.0f));
            this.target.position = new Vector3(this.posicionXAleatorio, 1.0f, this.posicionZAleatorio);
            this.retardo = Time.time + 4.0f;
        }
        
        this.agent.SetDestination(this.target.transform.position);
	}

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag =="Fence")
        {
            this.retardo = Time.time;
        }
    }
}
