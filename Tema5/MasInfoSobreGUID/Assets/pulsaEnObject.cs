using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/** Ejemplo 1 Controla cuando el raton esta encima de un objeto o le hace click,script asociado al cubo*/
public class pulsaEnObject : MonoBehaviour {
    int i = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      
		
	}


    //Ejemplo 1:Evento del sistema que controla cuando se hace click con el raton encima del objeto que tiene asociado el scrit
    void OnMouseDown() {

        Debug.Log("Pulsado " + i++);
    }
}
