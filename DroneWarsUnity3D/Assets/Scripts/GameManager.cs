using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private string ganador;
    

	// Use this for initialization
	void Start () {
        this.ganador = "";
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameObject.FindGameObjectsWithTag("Drone").Length == 1)
        {
            this.ganador = GameObject.FindGameObjectWithTag("Drone").transform.parent.name;
            Time.timeScale = 0;
            StatsController.mensajeFinal = this.ganador + " WINS!! \n Press any key to restart";
            if (Input.anyKeyDown)
            {
                StatsController.mensajeFinal = "";
                SceneManager.LoadScene("Arena");
                Time.timeScale = 1;
            }
        }
	}
}
