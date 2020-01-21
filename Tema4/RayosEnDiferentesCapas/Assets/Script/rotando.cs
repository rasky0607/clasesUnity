using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**Asignado ala esfera praa que rote su nariz*/
public class rotando : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * 2);
	}
}
