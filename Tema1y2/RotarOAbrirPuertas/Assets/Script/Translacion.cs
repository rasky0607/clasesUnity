using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Este script pretende que un objeto gire en torno al centro de otro .
 En este caso un cubo alrededor de una esfera*/
public class Translacion : MonoBehaviour {
    public GameObject _centro;
    public float _velocidad;
	// Use this for initialization
	void Start () {
        _velocidad = 2F;
	}
	
	// Update is called once per frame
	void Update () {
        //Primero le pasamos es la posicion del centro de nuestro objeto (el que va girar,el angulo que hacia el que va mirar y la velocidad)
        //PD:En el entorno hemos añadido en la varaible centro de el entorno de el cubo,marcamos ala esfera como centro
        transform.RotateAround(_centro.transform.position, Vector3.up,_velocidad);
	}
}
