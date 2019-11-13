using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaCorredera : MonoBehaviour {
    public GameObject _objetoDestino;
    public float velocidad = 0.05F;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Mientras la telca esta pulsada
        if (Input.GetKey(KeyCode.Space))
            transform.position = Vector3.MoveTowards(transform.position, _objetoDestino.transform.position, velocidad);
	}
}
