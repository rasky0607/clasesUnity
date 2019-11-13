using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Usando el Transford y la clase Mathf  para mover objetos dentro de un area etc
 En este caso para dar movimiento a una esfera y controlar que no se salga de el plano o de un area determinada*/
public class MoverEnUnArea : MonoBehaviour {

    /*En este caso creamos dos constantes para tener controlados los maximo por los que se va mover
    (ya que es un cuadrado neceitamos 2, peor si fuera un rectangulo  por ejemplo necesitariamos 4)*/
    const float MIN = -5;
    const float MAX = 5;
    //Publica para que aparezca en el interfaz grafico y hacer comprobaciones.
    public float _posX = 0;
    public float _posZ = 0;
    float _velocidad = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //para  mover en el eje X que depende la tecla pulsda el valor y el tiempo(el tiempo para no depender de los fragmes)
        _posX += Input.GetAxis("Horizontal") * _velocidad * Time.deltaTime;
        _posZ += Input.GetAxis("Vertical") * _velocidad * Time.deltaTime;
        //controlamos el minimo y maximo con clamp
        _posX = Mathf.Clamp(_posX, MIN, MAX);
        _posZ = Mathf.Clamp(_posZ, MIN, MAX);

        //Añadimos el movimiento al transfor del objeto(en este caso la esfera del entorno a la cual a hora le añadiremos el script)
        transform.position = new Vector3(_posX, transform.position.y,_posZ);
	}
}
