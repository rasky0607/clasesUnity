using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**La capsula que esta dentro del objeto Emisor lanzara un rayo para ver si detecta algun otro objeto*/
public class rayo : MonoBehaviour {

    /**Version 1*/
    Vector3 _origen;
    Vector3 _direccionRayo;
    float _longitudRayo;
    RaycastHit _informacionDelImpacto;
    /*------------------------------*/

    /*Version 2*/
    //NOTA: mascara es la que activa o desactiva las diferentes capas.
    /*NOTA: Tambien se le puede pasar la capa como entero, es decir
    cogemos el numero 2 y lo elevamos al numero de la capa. por ejemplo nuestra capa basura es la 14, si elevamos 2 a el numero de la capa en este caso 14,nos valdra en lugar de usar 0x4000*/
    int _mascaraJugador = 512; //200 en exadecimal --> ese 512 es 2 elevando a 9
    int _mascaraBasura = 0x4000; //4000 en exadecimal  , tambien podriamos poner este como dijismo antes 2 elevando a 14, ya que la capa basura es 14
    int mascaraJugadorYBasura = 0x4200; //Sumamos ambas mascaras, ya que este es el valor indicara que sean visible ambas capas.
    /*------------------------------*/

    // Use this for initialization
    void Start () {
        _direccionRayo = Vector3.forward;
        _longitudRayo = Mathf.Infinity;
        /*Para probar la teoria de que podemos pasar 2 elevado al numero de la capa y de que esto funciona para indicar la capa que queremos detectar*/
        _mascaraBasura =(int) Mathf.Pow(2, 14);

    }
	
	// Update is called once per frame
	void Update () {
        /*Version 1*/
        //DetectarTodosLosObjetos();

        /*Version 2*/
        DetectarTodosLosObjetosDeAlgunasCapas(_mascaraBasura);//En este caso so lo detectara objetos que esten en la capa basura
	}

    /**Version 1:*/
    /*Metodo para detectar objetos que estan delante del emisor*/
    void DetectarTodosLosObjetos() {
        _origen = transform.position;
        /*out por que la clase a la que llama es una estructura por lo que es
        un dato por valor y hara los cambios en una copia de este objeto, lo que lo borrara al terminar su ejecucion,
        al indicar out estamos guandando la informacion en el objeto original,
        ya que como nuestra variable _informacionDelImpacto no esta inicializada, el creara una automaticamente si no indicamos out para referisnos al objeto original */
        if (Physics.Raycast(_origen, _direccionRayo, out _informacionDelImpacto, _longitudRayo))
        {
            Debug.Log("Objeto detectado: " + _informacionDelImpacto.collider.name);
        }
    }
    /*------------------------------*/

    /**Version 2:*/
    void DetectarTodosLosObjetosDeAlgunasCapas(int capas)
    {
        _origen = transform.position;
        /*out por que la clase a la que llama es una estructura por lo que es
        un dato por valor y hara los cambios en una copia de este objeto, lo que lo borrara al terminar su ejecucion,
        al indicar out estamos guandando la informacion en el objeto original,
        ya que como nuestra variable _informacionDelImpacto no esta inicializada, el creara una automaticamente si no indicamos out para referisnos al objeto original */
        if (Physics.Raycast(_origen, _direccionRayo, out _informacionDelImpacto, _longitudRayo,capas))
        {
            Debug.Log("Objeto detectado: " + _informacionDelImpacto.collider.name);
        }
    }
    /*------------------------------*/
}
