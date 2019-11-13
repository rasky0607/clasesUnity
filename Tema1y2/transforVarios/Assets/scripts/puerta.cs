using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour {

    public float velocidad = 0.005F;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Rotacion para abrir una puerta
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), velocidad * Time.time);
            velocidad = 0.005F;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), velocidad * Time.time);
            velocidad = 0.005F;
        }
    }
}
