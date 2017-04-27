using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DroneAttacker : MonoBehaviour {
    public GameObject proyectil;
    public GameObject lanzadera;
    private float retardo;
    private List<GameObject> objetivos; // Creamos una lista para poder trabajar con ella dinamicamente en el script y le asignamos un valor
    private int numeroObjetivos;
    private GameObject objetivoActual;
    private float[] distancias; // Array que almacenará las distancias entre drones
    private float distanciaCorta = 10.0f; // Distancia máxima a la que los drones atacarán
    private int indexObjetivo;

	// Use this for initialization
	void Start () {
        this.objetivos = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Drone") // Si un Drone entra en el Collider...
        {
            this.objetivos.Add(other.gameObject);  // ...lo añadimos a la lista de posibles objetivos
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Drone") // Si un Drone sale de nuestro rango...
        {
            this.objetivos = new List<GameObject>(); // ... reiniciamos la lista
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Drone" && !this.objetivos.Contains(other.gameObject)) // Si el Drone no esta en nuestra lista...
        {
            this.objetivos.Add(other.gameObject); // ...lo añadimos
        }
        if (other.gameObject.tag == "Drone" && this.objetivos.Contains(other.gameObject)) // Si el Drone si está en nuestra lista
        {
            this.numeroObjetivos = this.objetivos.Count; // Calculamos la longitud de la lista
            this.distancias = new float[this.numeroObjetivos]; // Creamos un array para las distancias con una longitud igual a la de la lista de GameObjects
            if (this.retardo <= Time.time) // Si se cumple el retardo
            {
                for (int i = 0; i > numeroObjetivos; i++) // Creamos una rutina de repetición de tantos ciclos como posibles objetivos
                {
                    if (this.objetivos[i].gameObject != null) // Comprobamos que el item de la lista con el que trabajamos exista
                    {
                        this.distancias[i] = Vector3.Distance(this.transform.position, this.objetivos[i].transform.position); // Calculamos la distancia del item de la lista hasta nuestro Drone
                        if (this.distancias[i] >= 0.1f)
                        {
                            this.distanciaCorta = Mathf.Min(this.distanciaCorta, this.distancias[i]); // Comparamos si la nueva distancia es menor que la existente
                            if (this.distanciaCorta == this.distancias[i]) // Si lo es...
                            {
                                this.indexObjetivo = i; // ... elegimos este Gameobject como objetivo mediante su posición en la lista
                            }
                        }
                    }
                }
                this.objetivoActual = this.objetivos[indexObjetivo]; // Fijamos el GameObject elegido en el FOR como objetivo
                if (this.objetivoActual) // Si existe un objetivo actual
                {
                    this.transform.LookAt(this.objetivoActual.transform); // Enfocamos el transform de nuestro Drone hacia el objetivo
                }
                this.lanzadera.transform.position = this.transform.position; // Centramos la posicion y...
                this.lanzadera.transform.rotation = this.transform.rotation; // ... angulo de nuestro disparador
                this.lanzadera.transform.Rotate(Vector3.up * Random.Range(22.5f, -22.5f)); // Añadimos un angulo de disparo aleatorio para no acertar siempre
                this.lanzadera.transform.Translate(Vector3.forward * 2.0f); // Adelantamos ligeramente el disparador para que los proyectiles no nos den al disparar
                Instantiate(this.proyectil, this.lanzadera.transform.position, this.lanzadera.transform.rotation); // Instanciamos el proyectil
                this.retardo = Time.time + 2.0f; // Asignamos un retardo de 2s entre disparos
            }
        }
    }
}
