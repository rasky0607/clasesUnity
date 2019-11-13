using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Asignadoa a la captusala para ir del punto A
 al punto B y (volver que es una ampliacion de lo anterior)
 Es decir hacerun efecto pinpon de manera manual
     */
public class irDeAaByDeBaA : MonoBehaviour {
    float _minimo = -5;
    float _maximo=5;

    //Valor inicial del tiempo (la cual la necesitamos para usar el memtodo pinpon)
    public float _tiempo = 0.0F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Ir desde A a B en un tiempo
        //Esto es lo importante: Mathf.Lerp(_minimo,_maximo,_tiempo)
        transform.position = new Vector3(Mathf.Lerp(_minimo,_maximo,_tiempo),transform.position.y,transform.position.z);
        /*El tiempo debe cambiar, por que si esta en 0 no se mueve, pero si lo dejamos a 1 esta al final,
         * IMPORTANTE:ya que este es el tiempo maximo permitido para el movimeinto.
         Obcion1 para modificar el tiempo*/
        _tiempo += 0.25F * Time.deltaTime;
        /*Obcion2 para modificar el tiempo*/
        //_tiempo = Time.time*025F;

        //Para que el objeto vuelva a su destino
        if (_tiempo > 1)
        {
            //ahora el antiguo mazimo es el minimo y el minimo el antiguo maximo(le damos la vuelta)
            float temp = _maximo;
            _maximo = _minimo;
            _minimo = temp;
            //Reiniciamos el tiempo para comenzar de nuevo el movimiento
            _tiempo = 0.0F;
        }
	}
}
