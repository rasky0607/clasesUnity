using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//-----------------------------------
using UnityEngine.SceneManagement;

public class IrAEscena2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Salir();
        }
	}

    public void IrADos() //No es obligatorio que sea público, depende a quién le asigne el script
    {
        SceneManager.LoadScene("Dos");
    }

    public void IrAUno()
    {
        SceneManager.LoadScene("Una");
    }

    public void IrAEscena(string Escena) //Se le pasa la escena desde Unity. 
    {
        SceneManager.LoadScene(Escena);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
