using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Asignado al cubo para el movimiento de PinPon
 usando el metodo PinPon()*/
public class CuboPinPon : MonoBehaviour {

    float _minimo = -5;
    float _maximo = 5;
    float _velocidad = 10;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Lo importante: PingPong(Time.time*_velocidad,_maximo)

        //transform.position = new Vector3(transform.position.x,transform.position.y,Mathf.PingPong(Time.time*_velocidad,_maximo));
        /*Para que pinpong mueva entre 5 y -5 ya que son las coordenadas de mi plano
         Para esto en lugar de tener el maximo en 5, lo tendremos en 10, de hay que sea Mathf.PingPong(Time.time * _velocidad, _maximo+5) y lo que devuelva la funcion de PinPOng le restamos de nuevo el maximo de ahi (Mathf.PingPong(Time.time * _velocidad, _maximo+5)) - _maximo)*/
        transform.position = new Vector3(transform.position.x, transform.position.y, (Mathf.PingPong(Time.time * _velocidad, _maximo+5)) - _maximo);

    }
}
