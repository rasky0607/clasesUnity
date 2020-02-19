using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlUI : MonoBehaviour
{

    public Text textNumMunicion;
    public static int numMunicion;
    public GameObject panel; 

    //Pintar OnGUI
    bool pintarMenu = false;//Cuando es falso no pinta cuando es true si
    // Use this for initialization
    void Start()
    {
        numMunicion = 10;
        textNumMunicion.text = numMunicion.ToString(); ;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.K))
        {
            RecargarMunicion();
        }

        //Cuando se pulsa escape pintamos un menu con GUI
        if (Input.GetKey(KeyCode.Escape))
        {
            pintarMenu = true;
        }
    }

    private void OnGUI()
    {
        if (pintarMenu)
        {
            Menu();
        }
    }

    private void Menu() {
        int ancho = 200;
        int alto = 30;
        int x = (Screen.width / 2) - (ancho / 2);//Cogemos el ancho de  la pantall lo dividimos entre 2 y  le restamos nuestro ancho entre 2
        int y = (Screen.height / 2) - (alto / 2);
        Rect areaButn2 = new Rect(x, y - 40, ancho, alto);
        Rect areaButn3 = new Rect(x, y, ancho, alto);
        Rect areaButn4 = new Rect(x, y + 40, ancho, alto);
        Rect areaButn5 = new Rect(x, y + 80, ancho, alto);
        //Continuamos el juego por l o que dejamos de pintar el menu
        if (GUI.Button(areaButn2, new GUIContent("Continuar"))) {
            pintarMenu = false;
        }
        //Dejamos de pintar menu y pintamos una ventana nueva de ayuda sobre el juego
        if (GUI.Button(areaButn3, new GUIContent("Ayuda")))
        {
            panel.SetActive(true);
        }
        //Reiniciamos la escena Ej8 para reiniciar el juego 
        if (GUI.Button(areaButn4, new GUIContent("Reiniciar"))) {
            SceneManager.LoadScene("Ej8");

        }
        //Salimos del juego y cargamos la escena del Menu Ej1Menu
        if (GUI.Button(areaButn5, new GUIContent("Salir"))) {
            SceneManager.LoadScene("Ej1Menu");
        }
    }

    private void DescontarMunicion()
    {
        numMunicion = numMunicion - 1;
        textNumMunicion.text = numMunicion.ToString();
    }
    private void RecargarMunicion()
    {
        numMunicion = 5;
        textNumMunicion.text = numMunicion.ToString();
    }


}
