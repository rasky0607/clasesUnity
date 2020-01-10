using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Asignado al emisor para funcionar como un faro que detecta un objeto o array de objetos*/
public class Emisor : MonoBehaviour {

    Vector3 _direccion;//La direccion
    int _alcance = 500;

    /*Ejemplo de detectar varios objetos*/
    RaycastHit[] _objetosDetectados;//Es una estructura por valor, asi para asiganrle valore slo haremos con out, si no, se lo asignara a una copia de esta, no ala original.
	// Use this for initialization
	void Start () {
        _direccion = transform.TransformDirection(Vector3.left*_alcance);
	}
	
	// Update is called once per frame
	void Update () {
        #region Ejemplo de detectar una coleccion objetos
        _objetosDetectados = Physics.RaycastAll(transform.position, _direccion);//Detecta una coleccion de objetos

        /*Esto que vamos hacer ahora, esta mal hecho deberiamos usar las corutinas,
         * pero para este ejemplo que solo mostrara 3 objetos no pasa nada, además no dimos la coorutinas aun...*/
        foreach (RaycastHit item in _objetosDetectados)
        {
            Debug.Log("DETECTADO: Tipo:" + item.GetType().ToString() +" Distancia: "+ item.distance.ToString() + " Nombre: " + item.collider.name.ToString());
        }
        #endregion

        #region Ejemplo de detectando un objeto
        if (Physics.Raycast(transform.position, _direccion,_alcance))//Cuando un rayo (Con origen en nuestro emisor) en esta direccion  impacte con algo
        {
            Debug.Log("DETECTADO");
        }
        Debug.DrawRay(transform.position, _direccion, Color.red);//Pinta el rayo

        //Girar objeto Emisor
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(new Vector3(0, 1, 0));
            //Giramos el rayo
            _direccion = transform.TransformDirection(Vector3.left * _alcance);
        }
        #endregion
    }
}
