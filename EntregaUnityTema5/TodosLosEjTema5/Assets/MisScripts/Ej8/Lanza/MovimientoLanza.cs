using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoLanza : MonoBehaviour
{

    public GameObject jugador;
    bool activar = false;//bandera que activa o desactiva el movimiento de la lanza
    //Rotacion
    float maximo = 0;
    float minimo = 0;
    float tiempoA = 0.00F;
    float velocidad = 2.25F;

    Vector3 destino;
    // Use this for initialization
    void Start()
    {
          destino = new Vector3(transform.position.x, transform.position.y, transform.position.z+ 1);
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            activar = true;
            StartCoroutine(DesplazarLanza());
            
        }
    }
    //Movimiento de ataque de la lanza, hacia adelante y regresar a pos original
    IEnumerator DesplazarLanza()
    {
        minimo = transform.position.z;
        maximo = jugador.transform.position.z + 1;
        int nvueltas = 1;
        while (activar)
        {
          
            while (nvueltas <= 2)//2 vueltas, ya que tiene que hacer 1 ciclo para el recorrido de ida hacia delante y otro para el recorrido de ida hacia atras
            {
                transform.position =  new Vector3(transform.position.x,transform.position.y, Mathf.MoveTowards(minimo, maximo, tiempoA));
                tiempoA += velocidad * Time.deltaTime;//el tiempo del que dispone para hacer el movimiento (ya sea hacia atras o hacia adelante
                Debug.Log("minimo -->" + minimo + "\n maximo--> " + maximo);
                if (tiempoA > 1)
                {
                    /*Variable temporal para cambiar el minimo por el maximo y el maximo por el minimo
                    (Ya que cuando el objeto se encuentre en el destino, el minimo pasara  a ser el maximo y viceversa*/
                    float temp = maximo;
                    maximo = minimo;
                    minimo = temp;
                    tiempoA = 0.0F;
                    nvueltas++;

                }
                activar = false;//Esta bandera evita que el bucle de nvueltas vuelva a iniciarse

                yield return null;
            }

        }

       
    }



}
