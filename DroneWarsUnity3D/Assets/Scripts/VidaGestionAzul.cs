using UnityEngine;
using System.Collections;

public class VidaGestionAzul : MonoBehaviour
{
    public int salud;
    private int golpe;
    public GameObject explosion;
    private bool destruir;
    private float retardo;
    private bool explosioncounter = true;

    // Use this for initialization
    void Start()
    {
        this.golpe = this.salud / 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.salud <= 0.0f && this.explosioncounter == true)
        {
            Instantiate(this.explosion, this.transform.position, this.transform.rotation);
            this.explosioncounter = false;
            this.transform.parent.position = new Vector3(this.transform.parent.position.x, -50.0f, this.transform.parent.position.z);
            this.destruir = true;
            this.retardo = Time.time + 1.0f;
        }
        if (this.destruir == true && this.retardo <= Time.time)
        {
            Destroy(this.transform.parent.gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rocket")
        {
            this.salud = this.salud - this.golpe;
            StatsController.vidaBlue = this.salud;
            Destroy(other.gameObject);
            Instantiate(this.explosion, this.transform.position, this.transform.rotation);

        }
    }
}