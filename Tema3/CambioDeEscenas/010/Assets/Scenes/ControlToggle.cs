using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Asignado al GameObject ControlToggle
public class ControlToggle : MonoBehaviour {

    GameObject _interruptorLuz; //Para el Toggle
    GameObject _luz;            //Para la Luz Direccional
    GameObject _interruptorSonido;
    GameObject _sonido;

	// Use this for initialization
	void Start () {
        //Asignaciones
        _interruptorLuz = GameObject.Find("TgLuz");
        _luz = GameObject.Find("DirectionalLight");

        _interruptorSonido = GameObject.Find("TgSonido");
        _sonido = GameObject.Find("MainCamera");
    }
	
	// Update is called once per frame
	void Update () {
        InterruptorLuz();
        InterruptorSonido();
	}

    //Control de On/Off de la luz
    public void InterruptorLuz()
    {
        _luz.SetActive(_interruptorLuz.GetComponent<Toggle>().isOn); //Coge la propiedad del Toggle para ver si está activado o no.
    }

    public void InterruptorSonido()
    {
        _sonido.SetActive(_interruptorSonido.GetComponent<AudioSource>().playOnAwake);
    }
}
