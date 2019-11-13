using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Rotacion continua usando rotate
public class RotacionContinua : MonoBehaviour {
    public float _y = 0;
    public float _x = 0;
    public float _z = 0;
    public float _velocidad = 100F;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Obcion1
        //transform.Rotate(Vector3.up * _velocidad * Time.deltaTime);
        //Obcion2:
        transform.Rotate(new Vector3(_x * _velocidad * Time.deltaTime, _y * _velocidad * Time.deltaTime, _z * _velocidad * Time.deltaTime));
        //para que rote respecto a si mismo (Space.Self)
        //transform.Rotate(new Vector3(_x * _velocidad * Time.deltaTime, _y * _velocidad * Time.deltaTime, _z * _velocidad * Time.deltaTime),Space.Self);
        //para que rote respecto a el mundo (Space.World)
        //transform.Rotate(new Vector3(_x * _velocidad * Time.deltaTime, _y * _velocidad * Time.deltaTime, _z * _velocidad * Time.deltaTime), Space.World);
    }
}
