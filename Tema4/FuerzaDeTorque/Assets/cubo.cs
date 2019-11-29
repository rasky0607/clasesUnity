using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Posicionar un objeto con el componente Rigibody usando su metodo position*/
public class cubo : MonoBehaviour {
    Quaternion q1;
    public Vector3 _posicionInicial;
	// Use this for initialization
	void Start () {
        _posicionInicial = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().position = _posicionInicial;
       
        
    }
}
