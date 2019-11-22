using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Añadido
using TMPro;

public class trasladar : MonoBehaviour {

    public TextMeshPro _magnitud;
    public Transform _origen;
    public Transform _destino;
    Vector3 _direccion;
    float _velocidad;
    Vector3 _distancia;
    bool _estaTrasladando=false;

	// Use this for initialization
	void Start () {
        _velocidad = 0.1F;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))//para que empiece a ejecutar la tralacion        
            _estaTrasladando = true;

        Translacion();
        
	}
    //Modo CINEMATICO(es decir sin Fisica)
    void Translacion() {
        _distancia = _destino.position;
        if (_estaTrasladando)
        {
            //igualmente ya esta en ditancia, peor asi lo dejamos mas claro
            _direccion = _destino.position - _origen.position;
            //Se puede indicar el espacio(pero solo si un objeto es hijo de otro quizas sea necesario
            _origen.Translate(_direccion * _velocidad);
        }

        _magnitud.text = _distancia.magnitude.ToString();

        //Comprobar la distancia entre origien y destino, para que se pare
        if (_distancia.magnitude < 0.2F)
            _estaTrasladando = false;
    }
}
