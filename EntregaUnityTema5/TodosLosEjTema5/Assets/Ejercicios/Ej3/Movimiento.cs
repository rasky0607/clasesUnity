using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Script asociado a la esfera*/
public class Movimiento : MonoBehaviour {
    public float velocidad = 0.4f;
    private Vector3 posInicial;
    private Quaternion rotacionInicial;
    private bool enLaZona = false;//Este determina si la esfera esta en contacto con el cubo o no, para permitir su movimiento o no

    private void Start()
    {
        posInicial = transform.position;
        rotacionInicial = transform.rotation;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            if (!enLaZona)//Si no esta en la zona, podemos moverla
                transform.position = new Vector3(transform.position.x - velocidad, transform.position.y, transform.position.z);   
        
        if (Input.GetKeyDown(KeyCode.RightArrow))//Devolvemos la esfera ala posicion de origen
        {
            transform.position = posInicial;
            transform.rotation = rotacionInicial;
            enLaZona = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        enLaZona = true;
    }
}
