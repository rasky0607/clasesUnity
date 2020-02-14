﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Asociado a cubo llamado Emisor:
 Este se comunicara con un metodo en el Script llamado Receptor, que esta asignado en el objeto Receptor que tiene asignado el tag "GoReceptor"  y lo ejecutara*/
public class Emisor : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            //Llama al metodo Acccion que no tiene parametros,este para metro "SendMessageOptions.DontRequireReceiver"  indica que si no encuentra el metodo, no lance excepcion(por defecto si no se indica, lo lanza)
            //GameObject.FindWithTag("GoReceptor").SendMessage("Accion",SendMessageOptions.DontRequireReceiver);
            //Ejemplo 1(para usar un  metodo Sin parametros)
            //GameObject.FindWithTag("GoReceptor").SendMessage("Accion");
            //Ejemplo 2(para usar un  metodo con parametros)
            GameObject.FindWithTag("GoReceptor").SendMessage("Accion", "Soy el emisor");
        }
    }
}
