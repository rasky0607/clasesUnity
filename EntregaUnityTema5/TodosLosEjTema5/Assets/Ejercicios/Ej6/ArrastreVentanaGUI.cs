using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class ArrastreVentanaGUI : MonoBehaviour
{
    int margenX = 5;
    static int anchoVentana = 665;
    static int altoVentana = 350;
    Rect rectVentana = new Rect(20, 20, anchoVentana, altoVentana);

    private void Start()
    {             

    }
    private void OnGUI()
    {
        rectVentana = GUI.Window(0, rectVentana, PintaVentana, "Ventana arrastable");        
    }
    
    private void PintaVentana(int id)
    {
        int ancho = 200;
        int alto = 30;
        int x = (anchoVentana / 2) - (ancho / 2);//Cogemos el ancho de  la pantall lo dividimos entre 2 y  le restamos nuestro ancho entre 2
        int y = (altoVentana / 2) - (alto / 2);
        Rect arealabel = new Rect(x, y - 100, ancho, alto+30);
        Rect areaButn2 = new Rect(x, y - 40, ancho, alto);
        Rect areaButn3 = new Rect(x, y , ancho, alto);
        Rect areaButn4 = new Rect(x, y+40, ancho, alto);
        Rect areaButn5 = new Rect(x, y + 80, ancho, alto);
        GUI.Label(new Rect(arealabel), "¿Quieres ir a alguna escena?");

        if (GUI.Button(new Rect(areaButn2), "Ejercicio 2"))
        {
            SceneManager.LoadScene("Ej2");
        }

        if (GUI.Button(new Rect(areaButn3), "Ejercicio 3"))
        {
            SceneManager.LoadScene("Ej3");
        }

        if (GUI.Button(new Rect(areaButn4), "Ejercicio 4"))
        {
            SceneManager.LoadScene("Ej4");
        }

        if (GUI.Button(new Rect(areaButn5), "Salir"))
        {
            SceneManager.LoadScene("Ej1Menu");
        }

        GUI.DragWindow();//Nos permite desplazar la ventana, de otro modo solo la pintaria
        
    }
}
