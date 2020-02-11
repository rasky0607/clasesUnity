using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**Asociado a objeto vacio controlador GUI*/
public class MiGUIWindow : MonoBehaviour {
    //Variables para  la funcion MostrarVentana()
    float ancho = 400;
    float alto = 200;
    Rect area;
    float x;
    float y;

    //Variables para la FuncionVentana()
    public float xfuncVentana;
    public float yfuncVentana;
    public float anchofuncVentana = 140;
    public float altofuncVentana = 60;

    //Boleado para mostrar o no la ventana
    bool mostrar = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//si se pùlsa space no se pintara la ventana
            mostrar = !mostrar;//camiara el valo al contrario de el que contenga la variable, es decir si es falso lo cambiara a true y viceversa
    }
    private void OnGUI() {
        if(mostrar)
            MostrarVentana("Hola caracola");
    }
    //Pinta la ventana
    void MostrarVentana(string contenido) { 
        x = (Screen.width / 2)-(ancho/2);//Cogemos el ancho de  la pantall lo dividimos entre 2 y  le restamos nuestro ancho entre 2
        y = (Screen.height / 2) - (alto / 2);
        area = new Rect(x,y,ancho,alto);
        //cuando se cargue la ventana, se dirigira a FuncionVentana  para ver que tiene que pintar en el interior de esta ventana
        area = GUI.Window(0, area, FuncionVentana, contenido);
    }

    //Lo que vamos a pintar dentro de la ventana
    void FuncionVentana(int id) {
        xfuncVentana = (area.width / 2) - (anchofuncVentana / 2);
        yfuncVentana = (area.height / 2) - (altofuncVentana / 2);
        //Escribir el boton
        Rect areaBoton = new Rect(xfuncVentana, yfuncVentana, anchofuncVentana, altofuncVentana);
        if(GUI.Button(areaBoton,"Boton Window OK"))
            Debug.Log("Haz clicado en la ventana de ID"+id);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	
}
