using UnityEngine;
using System.Collections;

public class BarraVidaAzul : MonoBehaviour {

    private float anchoBarra;
    private float altoBarra;
    private int vidaLeft;

	// Use this for initialization
	void Start () {
        this.vidaLeft = StatsController.vidaBlue;
        this.anchoBarra = this.gameObject.GetComponent<RectTransform>().rect.width;
        this.altoBarra = this.gameObject.GetComponent<RectTransform>().rect.height;

    }
	
	// Update is called once per frame
	void Update () {
        if (this.vidaLeft != StatsController.vidaBlue)
        {
            this.vidaLeft = StatsController.vidaBlue;
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(this.vidaLeft * (this.anchoBarra / 100), altoBarra);
        }
	}
}
