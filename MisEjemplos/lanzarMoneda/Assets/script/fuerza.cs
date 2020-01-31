using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuerza : MonoBehaviour {
	public Rigidbody rg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Fire1") != 0)
		{
			rg.AddForce(Vector3.up * 10F, ForceMode.Impulse);
			rg.AddTorque(Vector3.left * 5F, ForceMode.Impulse);
		}
	}
}
