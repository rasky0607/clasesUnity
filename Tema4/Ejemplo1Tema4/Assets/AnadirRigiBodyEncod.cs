using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnadirRigiBodyEncod : MonoBehaviour {


    float _tiempoTotal;
    Rigidbody rgb0;
    bool _estasDurmiendo;
         
	// Use this for initialization
	void Start () {
        //asignamos un RigiBody desde codigo al gameobject
        rgb0 = gameObject.AddComponent<Rigidbody>();
        rgb0.mass = 10;
        Physics.gravity = new Vector3(0, -20, 0);
        _estasDurmiendo = false;
        _tiempoTotal = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (_tiempoTotal > 1)
        {
            if (_estasDurmiendo)
            {
                rgb0.WakeUp();
                Debug.Log("Despierto.... WakeUp()");
            }
            else {
                rgb0.Sleep();
                Debug.Log("Dormido... con Sleep()");
            }
            if (_estasDurmiendo =! _estasDurmiendo)//Cambia el valor
                _tiempoTotal = 0;
        }

        _tiempoTotal += Time.deltaTime;


	}
}
