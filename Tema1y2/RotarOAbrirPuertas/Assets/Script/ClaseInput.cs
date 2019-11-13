using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Horizontal"))
            Debug.Log("Flecha Izq/Drcha");
        if (Input.GetMouseButtonDown(0))
            print("Has pulsado el boton izquierdo del raton");
        if (Input.GetMouseButtonDown(1))
            print("Has pulsado el boton derecho del boton");
        if (Input.GetMouseButtonDown(2))
            print("Has pulsado la rueda del raton");
    }
}
