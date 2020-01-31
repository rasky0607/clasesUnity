using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Movimiento  horizontal de la nave2*/
public class MovimientoNave2 : MonoBehaviour {

    // Use this for initialization
    private float _velocidad = 2.00F;
    private float posX;
    Vector3 posicionOriginal;

    void Start()
    {
        posicionOriginal = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        //posX += transform.position.x * _velocidad *Time.deltaTime;
        //Velocidad constante
        // posX -= 1 * Time.deltaTime;
        //transform.position =  new Vector3(posX, transform.position.y, transform.position.z);
        //x 150.6  /comienzo x-503
        if (transform.position.x >= 200.00F)
        {          
            transform.position = posicionOriginal;           
        }
        else if (transform.position.x < 200.00F)
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), _velocidad*Time.deltaTime);


        //rotaciones
        //transform.RotateAround(_centro.transform.position, Vector3.down, _velocidad);
     
    }
}
