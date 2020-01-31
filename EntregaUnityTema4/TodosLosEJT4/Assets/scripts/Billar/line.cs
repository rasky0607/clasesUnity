using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(new Vector3(Input.mousePosition.x,transform.position.y,Input.mousePosition.y));
	}
}
