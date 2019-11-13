using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Asignado a la esfera planeta tierra
public class rotandoTierra : MonoBehaviour {

    public float _veRotacion = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(-Vector3.up * Time.deltaTime * _veRotacion);
	}
}
