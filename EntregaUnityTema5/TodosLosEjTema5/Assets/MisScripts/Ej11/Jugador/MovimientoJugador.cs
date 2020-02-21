using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour {

    public float velocidadAndar = 25F;
    public float velocidadRotacion = 40F;
    public GameObject camaraJugador;
    float posY;
    //Levantarse
    Quaternion orientacionInicial;

	// Use this for initialization
	void Start () {
        orientacionInicial = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (!ControlUI.juegoEnPausa)//Si juego en pausa es distinto de verdad o sea , no esta en pausa
        {
            //transform.Rotate(0, Input.GetAxis("Horizontal") * velocidad, 0);
            //Giro de personaje hacia los lados con el raton
            transform.Rotate(0, Input.GetAxis("Mouse X") * velocidadRotacion * Time.deltaTime, 0);
            //Giro de camara hacia arriba o abajo con el raton           
            camaraJugador.transform.Rotate(-Input.GetAxis("Mouse Y") * velocidadRotacion * Time.deltaTime, 0, 0);
            //Desplazamiendo del personaje
            transform.Translate(0, 0, Input.GetAxis("Vertical") * velocidadAndar * Time.deltaTime);
            transform.Translate(Input.GetAxis("Horizontal") * velocidadAndar * Time.deltaTime, 0,0 );


            //Boton derecho del raton para levantar el personaje cuando se cae
            if (Input.GetMouseButtonDown(1))
                Levantarse();
        }
    }
    //Colocamos el muñeco de pie
    public void Levantarse()
    {
        transform.SetPositionAndRotation(transform.position, orientacionInicial);
    }

}
