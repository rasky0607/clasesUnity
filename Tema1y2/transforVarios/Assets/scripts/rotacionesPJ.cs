using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacionesPJ : MonoBehaviour {
    Quaternion origen;
    Quaternion destino;
    //Publico para controlar la velocidad desde el entorno grafico como una propiedad mas
    //La velocidad tiene que ser entre 0-1
    public float velocidad = 0.001F;
	// Use this for initialization
	void Start () {
        origen = transform.rotation;
        destino = Quaternion.Euler(0, 90, 0);
        
        
    }
	
	// Update is called once per frame
	void Update () {
        
        /*leer tecla pulsada(y en casode que sea la Z hace algo)
         ya que cuando la tecla pulsada es esa, devuelve verdad.*/
        //if (Input.GetKeyDown(KeyCode.Z))//
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,90, 0), velocidad*Time.time);


	}
}
