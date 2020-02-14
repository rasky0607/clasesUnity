using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptor : MonoBehaviour {

    bool mostrarTexto = false;

    //Ejemplo 2(para usar un  metodo con parametros)
    string texto;

    //Ejemplo 1 (metodo sin  parametros)
    /*public void Accion()
    {
        mostrarTexto = true;
      
        AplicarCambios();
    }*/

    //Ejemplo 1 (metodo sin parametros)
    /* private void OnGUI()
     {
         if (mostrarTexto)
         {
             //Mostrar Texto
             GUI.color = Color.red;
             GUIStyle estilo = new GUIStyle();
             estilo.fontSize = 40;
             GUILayout.Label("Hola caracola", estilo);           
         }
     }*/
    public void Accion(string texto)
    {
        mostrarTexto = true;
        this.texto = texto;
        AplicarCambios();
    }

    private void OnGUI()
    {
        if (mostrarTexto)
        {
            //Mostrar Texto
            GUI.color = Color.red;
            GUIStyle estilo = new GUIStyle();
            estilo.fontSize = 40;
            //GUILayout.Label("Hola caracola", estilo);
            GUILayout.Label(texto, estilo);
        }
    }

    private void AplicarCambios()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        gameObject.AddComponent(typeof(Rigidbody));
    }
}
