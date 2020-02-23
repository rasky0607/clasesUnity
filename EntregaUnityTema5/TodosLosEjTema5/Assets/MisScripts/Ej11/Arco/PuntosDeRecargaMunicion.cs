using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosDeRecargaMunicion : MonoBehaviour {

    int cantidadRecargada = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="jugador")
        {            
            GameObject.FindGameObjectWithTag("UI").SendMessage("RecargarMunicion", cantidadRecargada);
            Destroy(gameObject, 0.2F);
        }
    }
}
