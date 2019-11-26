using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Eventos de colisiones Parametro Other es el objeto con el que ha colisionado,gracias a est epodemos acceder a toda su informacion

    //Cuando comienza la colision
    void OnCollisionEnter(Collision other) {
        Debug.LogFormat("OnCollisionEnter: Comienza la colision con {0}", other.collider.name);    
    }


    //Mientras dure la colision
    void OnCollisionStay(Collision other)
    {
        Debug.LogFormat("OnCollisionStay: colision en curso con {0}", other.collider.name);
    }

    //Cuando finaliza la colision(osea pierde el contacto)
    void OnCollisionExit(Collision other)
    {
        Debug.LogFormat("OnCollisionExit: colision con {0}", other.collider.name+" finalizada");
    }
}
