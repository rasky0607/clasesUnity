using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Añadido
using UnityEngine.UI;

/*Este script asociado a el Canvas, regula la intensidad de la luz "luzGeneral" entre 0 y 1
 y las lamparas o estan encendidas 5 o estan apagadas 0  clicando en el Toogle "Lamparas On/Off*/

public class controlLuz : MonoBehaviour {

    public Slider reguladorDeLuz;
    public Light luzGeneral;//Luz general de la escena
    public Light luzLamp1;//Luz de lampara 1 
    public Light luzLamp2;//Luz de lampara 2 
    public Toggle encenderLampara;

    public Renderer bombilla1;
    public Renderer bombilla2;

    // Use this for initialization
    void Start () {
        //Iniciamos luz de escena encendida
        luzGeneral.intensity = 1;
        reguladorDeLuz.value = 1;
        luzGeneral.intensity = reguladorDeLuz.value;

        //Iniciamos lamparas apagadas
        luzLamp1.intensity = 0;
        luzLamp2.intensity = 0;

    }
	
	// Update is called once per frame
	void Update () {
        //Cambiamos intensidad de la luz de la escena
        luzGeneral.intensity = reguladorDeLuz.value;
        if (encenderLampara.isOn)
        {
            luzLamp1.intensity = 5;
            luzLamp2.intensity = 5;
        }
        else {
            luzLamp1.intensity = 0;
            luzLamp2.intensity = 0;
        }
       
              
	}
    public void SalirDePrograma() {
        //Salir del programa
        Application.Quit();
        Debug.Log("Fuera!");
    }
}
