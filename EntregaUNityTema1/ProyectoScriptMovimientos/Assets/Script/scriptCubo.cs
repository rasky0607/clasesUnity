using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enganchado al Cubo


public class scriptCubo : MonoBehaviour {
    float velocidad = 0.2F;
    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        //transform.Translate(1, 1, 0);
        //Se mueve a la derecha al pulsar la tecla flecha derecha
        transform.Translate(Input.GetAxis("Horizontal") * velocidad, 0, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * velocidad);
        //Escribir en la consola para depurar
        if (Input.GetAxis("Fire1")!=0) { 
            Debug.Log("Disparando");
        }
    }
}
