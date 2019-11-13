using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//añadido 
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*Asignado al objeto vacio ControlDeUI**/
public class contador : MonoBehaviour {

    public Text _texto = null;
    float _tiempo=0.00F;
    float _velocidad=10;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _tiempo += Time.deltaTime*_velocidad;
        _texto.text = _tiempo.ToString("0000");
        
	}

   public void PonerA0() {
        _tiempo = 0.00F;
    }

    public void CambioEscena()
    {
        //Pasar de escena
    }
}
