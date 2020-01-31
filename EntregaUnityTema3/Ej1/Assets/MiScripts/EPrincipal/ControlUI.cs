using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//añadido
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlUI : MonoBehaviour {

    public Toggle miCheckMusica;
    public AudioSource objMusica;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    
    public void CerrarAplicacion()
    {
        Application.Quit();
        Debug.Log("CERRADO!");
    }
    public void OnOffMusica()
    {
        if (miCheckMusica.isOn)
            objMusica.volume = 1;
        else
        {          
            objMusica.volume = 0;
        }
    }

    public void CambiarEscena(Button btn) {

        switch (btn.name) {
            case "btn1":
                
                SceneManager.LoadScene("una");
                break;
            case "btn2":
                SceneManager.LoadScene("dos");
                break;
            case "btn3":
                SceneManager.LoadScene("tres");
                break;
            case "btn4":
                SceneManager.LoadScene("cuatro");
                break;
            case "btn5":
                SceneManager.LoadScene("cinco");
                break;

        }

    }
}
