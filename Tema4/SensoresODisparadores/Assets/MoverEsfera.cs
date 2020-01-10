using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**Asociado con la Esfera*/
public class MoverEsfera : MonoBehaviour {

    Rigidbody rgEsfera;
    float fuerzaEmpuje = 10;
	// Use this for initialization
	void Start () {
        rgEsfera = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rgEsfera.AddForce(new Vector3(h,0,v) * fuerzaEmpuje,ForceMode.Force);


    }
}
