using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giraManzanas : MonoBehaviour {
    public float _velocidad = 80F;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position.x * _velocidad * Time.deltaTime, transform.position.y * _velocidad * Time.deltaTime, transform.position.z
        transform.Rotate((Vector3.down-Vector3.left)* _velocidad*Time.deltaTime);
	}
}
