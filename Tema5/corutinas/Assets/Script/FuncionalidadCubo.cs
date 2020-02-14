using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionalidadCubo : MonoBehaviour {

    public float velocidadRotacion=3F;
    Vector3 anguloRotacion = new Vector3(0.33F, 0.33F, 0.33F);
    float fuerzaDeImpulso = 0F;

	// Use this for initialization
	void Start () {
        fuerzaDeImpulso = 10F;
        GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaDeImpulso, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddTorque(Vector3.up * fuerzaDeImpulso, ForceMode.Impulse);
      
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0.33F, 0.33F, 0.33F)*3);
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
	}
}
