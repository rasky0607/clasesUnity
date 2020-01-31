using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//añadido
using UnityEngine.SceneManagement;


public class ControlEscena2 : MonoBehaviour {

    public GameObject figura1;
    public GameObject figura2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("Principal");

        figura1.transform.RotateAround(figura1.transform.position, Vector3.one,4*Time.deltaTime);
        figura2.transform.RotateAround(figura2.transform.position, Vector3.up, 4 * Time.deltaTime);
    }
}
