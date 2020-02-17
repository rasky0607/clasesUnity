using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour {

    public float velocidad = 0.5F;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, Input.GetAxis("Horizontal") * velocidad, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical")  * velocidad);
    }
}
