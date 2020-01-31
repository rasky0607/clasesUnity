using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntraEnLaZona : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /*Disparador que se lanza cuando la esfera entra en contacto con algo que tenga como tag "Item"
     Estamos usando el tag mas que nada para evitar que desaparezca el terreno.
     De otro modo, este desapareceria ya que la bola esta pegada el , por lo tanto lanzaria el Trigger*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            Debug.Log("Entroo: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
  

}
