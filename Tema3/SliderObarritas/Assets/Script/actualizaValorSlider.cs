using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//añadido
using UnityEngine.UI;

public class actualizaValorSlider : MonoBehaviour {
    //Podria ser un text, pero  luego lo buscamos(otra forma de hacerlo)
    public GameObject _texto;
    public GameObject _slider;
	// Use this for initialization
	void Start () {
        _texto.GetComponent<Text>().text = _slider.GetComponent<Slider>().value.ToString("000");
	}
	
	// Update is called once per frame
	void Update () {
        Actualizar();
	}
    //No es obligatorio que sea public,(en este caso si por que el object al que asigno el script no es el mismo  que los que uso en el)
    public void Actualizar()
    {
        _texto.GetComponent<Text>().text = _slider.GetComponent<Slider>().value.ToString("000");
    }
}
