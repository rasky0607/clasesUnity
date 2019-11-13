using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//añadido
using TMPro;
/*
 Este ejemplo de como dar zoom aun objeto agrandando este y como aplicar texto a un textMeshPro
     */
public class textoEnTextMshPro : MonoBehaviour {
    public TextMeshPro _textoPosicionDeRaton;
    float _valor = 0;//Valor que se incrementara al hacer click con la rueda del raton

    //para que el zoom no se haga muy rapido
    float _incrementotamanio=0.01F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Obtine la posicion del raton
        //_textoPosicionDeRaton.text = Input.mousePosition.ToString();

        /*Por que ya sabemos dela  teoria 
         0- boton izqu
         1 boton derech
         2 boton rueda del raton*/
        if (Input.GetMouseButtonDown(0))
        {
            _textoPosicionDeRaton.text = "Boton Izquierdo";
            transform.localScale = Vector3.one;//Resetea el zoom osea a la escala 1
        }

        if (Input.GetMouseButtonDown(1))
            _textoPosicionDeRaton.text = "Boton Derecho";

        if (Input.GetMouseButtonDown(2))
        {
            _textoPosicionDeRaton.text = "Boton Rueda del raton";
           
            _textoPosicionDeRaton.text = _valor.ToString("0000");
            _valor += Input.mouseScrollDelta.y;
            //Aumenta el zoom o disminuye de la camara
            transform.localScale += new Vector3(_valor * _incrementotamanio, _valor * _incrementotamanio, _valor * _incrementotamanio);
        }
       
    }
}
