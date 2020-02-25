using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour {

    public float velocidadAndar = 5F;
    public float velocidadRotacion = 40F;
    float posXArribaOAbajo = 0F;//Posicion de al rotar la camara hacia arriba o abajo con el raton
    //prueba
    //------//
   public float posXArribaOAbajoMAX=-15F;
   public float posXArribaOAbajoMIN=20F;
    float limitRotacion;
    public float LIMITMAX=20f;
    public float LIMITMIN=-30f;
    //--------------//
    public GameObject camaraJugador;
    //Levantarse
    Quaternion orientacionInicial;


    // Use this for initialization
    void Start () {
        velocidadAndar = 5F;
        orientacionInicial = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

        //transform.Rotate(0, Input.GetAxis("Horizontal") * velocidad, 0);
        //Giro de personaje hacia los lados con el raton
        transform.Rotate(0, Input.GetAxis("Mouse X") * velocidadRotacion * Time.deltaTime, 0);

        //-Giro de camara hacia arriba o abajo con el raton con limite    --//
        posXArribaOAbajo = Input.GetAxis("Mouse Y") * velocidadRotacion * Time.deltaTime;
        limitRotacion -= posXArribaOAbajo;
        limitRotacion = Mathf.Clamp(limitRotacion, LIMITMIN, LIMITMAX);
        camaraJugador.transform.localEulerAngles = new Vector3(limitRotacion, 0, 0);
        //------------//

        //Giro de camara hacia arriba o abajo con el raton             
        //camaraJugador.transform.Rotate(-Input.GetAxis("Mouse Y") * velocidadRotacion * Time.deltaTime, 0, 0);


        //Desplazamiendo del personaje
        transform.Translate(0, 0, Input.GetAxis("Vertical") * velocidadAndar * Time.deltaTime);
        transform.Translate(Input.GetAxis("Horizontal") * velocidadAndar * Time.deltaTime, 0,0 );
    
        //Boton derecho del raton para levantar el personaje cuando se cae
       /* if (Input.GetMouseButtonDown(1))
                Levantarse();*/
        
    }
    //Colocamos el muñeco de pie
    public void Levantarse()
    {
        transform.SetPositionAndRotation(transform.position, orientacionInicial);
    }




}
