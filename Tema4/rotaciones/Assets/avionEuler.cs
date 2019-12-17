using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Asignado al avion euler para controlar sus rotacion de ladeo
 * Este ejemplo se usara el metodo Euler con Vectores3 para ver como 
 * el uso de vectores3 con Euler en ocasiones puede dar error con las rotaciones
 * ya que al coincidr los angulos, puede haber una perdida de rotacion de un grado,
 * por lo que podria volverla rotacion loca
 */
public class avionEuler : MonoBehaviour {

    public float _velocidadRotacion = 90F;

    //Estos miembros se heredan en la otra clase, de hay que sean protegidos.
    protected float _rotadcionEjeX;
    protected float _rotadcionEjeY;
    protected float _rotadcionEjeZ;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Asignar los valores en funcion de la tecla pulsada
        _rotadcionEjeZ = Input.GetAxis("Vertical");
        _rotadcionEjeY = Input.GetAxis("Horizontal");
        //Usaremos las teclas y z y x 
        _rotadcionEjeX = Input.GetAxis("EjeX");//Nueva entrada creada en el Input Manager

        AplicarRotacion();

    }

    /*Virtual para que se  pueda sobreescribir, ya quelo vamos a compartir con otra clase*/
    protected virtual void AplicarRotacion() {
        Vector3 rotacionActual = transform.localEulerAngles; //Rotacion desde la que vamos a empezar
        //Modifico la rotacion actual, con los valores que lea desde el teclado
        rotacionActual.x += _rotadcionEjeX * _velocidadRotacion * Time.deltaTime;
        rotacionActual.y += _rotadcionEjeY * _velocidadRotacion * Time.deltaTime;
        rotacionActual.z += _rotadcionEjeZ * _velocidadRotacion * Time.deltaTime;

        //Aplicamos la rotaciones al transform
        transform.eulerAngles = rotacionActual;

    }

    void OnGUI() {
        GUI.color = Color.blue;
        //Mostramos la rotacion
        GUILayout.Label("Rotacion X " + _rotadcionEjeX);
        GUILayout.Label("Rotacion Y " + _rotadcionEjeY);
        GUILayout.Label("Rotacion Z " + _rotadcionEjeZ);
    }
}
