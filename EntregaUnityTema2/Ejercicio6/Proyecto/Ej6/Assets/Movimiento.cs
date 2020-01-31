
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    /*Posiciones maxima y minimas de mi plano (La ponemos en 4 en lugar de 5 para que las piernas del muñeco se ajusten al espacio,
     *ya que el GameObject que controla su posicion real es un EmtyObject que esta justo de bajo del muñeco, en el suelo)*/
    const float MIN = -4;
    const float MAX = 4;

    //Posiciones

    float velocidad = 4.00F;
    // Use this for initialization
    float _postX = 0.0F;
    float _postZ = 0.0F;
    //Para el salto
    float _postY = 0.0F;
    float _postYInicial = 0.0F;

    void Start () {
        _postYInicial = transform.position.y;
       
	}
	
	// Update is called once per frame
	void Update () {
        
        _postX +=Input.GetAxis("Horizontal") * velocidad*Time.deltaTime;
        _postZ +=Input.GetAxis("Vertical") * velocidad * Time.deltaTime;

        //controlamos los margenes del plano con el minimo y maximo usando Clamp
        _postX = Mathf.Clamp(_postX, MIN, MAX);
        _postZ = Mathf.Clamp(_postZ, MIN, MAX);

        /*Añadimos el movimiento al transfor del objeto
         * (en este caso el muñeco al cual le añadiremos el script"todo el muñeco cuelga
         * de un objeto vacio en la pierna Izquierda,(La que esta atras)")*/
        transform.position = new Vector3(_postX, transform.position.y, _postZ);

        //Salto
        if (Input.GetButtonDown("Jump"))
        {
            _postY = _postYInicial;
            _postY += Input.GetAxis("Jump") * velocidad * Time.deltaTime;
            //Desplazamos el objeto hacia arriba en el eje Y
            transform.position = new Vector3(transform.position.x, _postY*10, transform.position.z);          
        }
        //Caer del salto ->Devolvemos el objeyo a su posicion inicial en el eje Y
        if (Input.GetButtonUp("Jump"))
            transform.position = new Vector3(transform.position.x, _postYInicial, transform.position.z);
 


    }
}
