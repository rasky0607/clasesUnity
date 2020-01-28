using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Asociado al objeto abstracto
public class objetoAbstrac : MonoBehaviour {

    // Use this for initialization
    public Vector3 _rotacion;
    public float _velocidadRotacion;
	void Start () {
        _velocidadRotacion = 10;
        _rotacion = Vector3.one *_velocidadRotacion;

	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(_rotacion);
	}
}
