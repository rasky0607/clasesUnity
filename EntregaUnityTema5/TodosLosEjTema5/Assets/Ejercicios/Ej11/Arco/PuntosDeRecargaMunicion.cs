using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosDeRecargaMunicion : MonoBehaviour {

    int cantidadRecargada = 20;
    public AudioSource sonidoRecarga;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="jugador")
        {            
            GameObject.FindGameObjectWithTag("UI").SendMessage("RecargarMunicion", cantidadRecargada);
            sonidoRecarga.Play();//Reproducimos el sonido
            Destroy(gameObject, 0.2F);
        }
    }
}
