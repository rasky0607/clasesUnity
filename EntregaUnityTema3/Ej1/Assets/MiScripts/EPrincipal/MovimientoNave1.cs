using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Movimiento  horizontal de la nave1*/
public class MovimientoNave1 : MonoBehaviour {
    // Use this for initialization

    private float _velocidad=2.00F;
    private float posX;
    Vector3 posicionOriginal;
    void Start () {
       
        posicionOriginal = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
     
          if(-150.6F > transform.position.x && transform.position.x < -150.9)
            transform.position =posicionOriginal;
          else
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x - 10, transform.position.y, transform.position.z), _velocidad * Time.deltaTime);
       
    }
}
