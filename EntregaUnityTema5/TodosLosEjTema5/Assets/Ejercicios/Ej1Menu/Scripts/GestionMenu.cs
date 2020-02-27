using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionMenu : MonoBehaviour {

   string escena;//Este recogera el nombre de la escena a la que se va dirigir al dar a jugar por defecto el Ej2
   public Image imagenDemuestra;
   public Text textExplicativo;
	// Use this for initialization
	void Start () {
        imagenDemuestra.sprite = null;
        imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/mando");//Accedemos al recurso que va a reproducirse
        escena = "Ej2";
        textExplicativo.text = "Hola";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Salir()
    {
        Application.Quit();
    }
    public void Jugar()
    {
        if(escena!=null || escena!=string.Empty)
            SceneManager.LoadScene(escena);
        else
            imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/mando");//Accedemos al recurso que va a reproducirse
    }

    public void clickEj2()
    {
        //imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/escenaEj2");//Accedemos al recurso que va a reproducirse
        escena = "Ej2";
    }

    public void clickEj3()
    {
    }

    public void clickEj4()
    {
    }

    public void clickEj5()
    {
    }

    public void clickEj6()
    {
    }

    public void clickEj7()
    {
    }

    public void clickEj8()
    {
    }

    public void clickEj9()
    {
    }

    public void clickEj10()
    {
    }

    public void clickEj11()
    {
        imagenDemuestra.sprite=  Resources.Load<Sprite>("Ej1Menu/img/escenaEj11");//Accedemos al recurso que va a reproducirse
        escena = "Ej11";
        textExplicativo.text = "Ej11: Juego de supervivencia en el que el jugador debe enfrentarse a numerosos enemigos con su arco recorriendo un laberinto con cofres que pueden dotarle de salud extra cuando ha sido dañado, con municion, vida  y tiempo limitados";     
    }



}
