using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
       
        if (gameObject.tag == "jugador")
        {
            Debug.Log("CONTACTO!");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (gameObject.tag == "jugador")
        {
            Debug.Log("CONTACTO!");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (gameObject.tag == "jugador")
        {
            Debug.Log("CONTACTO!");
        }
    }
}
