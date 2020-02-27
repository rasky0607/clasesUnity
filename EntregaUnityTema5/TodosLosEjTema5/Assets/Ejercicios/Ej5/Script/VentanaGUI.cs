using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentanaGUI : MonoBehaviour {
    public bool pintarMenu = false;//Cuando es falso no pinta cuando es true si
    public  bool juegoEnPausa = false;
    AudioSource sonidoFondo;
    private void Start()
    {
        sonidoFondo = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pintarMenu = true;//Empezamos a pintar el menu
        }      
           
        
    }

    private void OnGUI()
    {
        if (pintarMenu)
            Menu();
    }
    public void PausarJuego(bool pausa)
    {
        juegoEnPausa = pausa;
        if (juegoEnPausa)
            Time.timeScale = 0;//Velocidad del juego nula por lo tanto parada
        else if (!juegoEnPausa)
            Time.timeScale = 1;//Velocidad del juego normal     
    }
    private void Menu()
    {
        sonidoFondo.volume=0F;//Bajamos sonido
        PausarJuego(true);//Paramos el juego
        int ancho = 200;
        int alto = 30;
        int x = (Screen.width / 2) - (ancho / 2);//Cogemos el ancho de  la pantall lo dividimos entre 2 y  le restamos nuestro ancho entre 2
        int y = (Screen.height / 2) - (alto / 2);
        Rect areaButn2 = new Rect(x, y - 40, ancho, alto);
        Rect areaButn3 = new Rect(x, y, ancho, alto);
            //Al hacer click en este boton "Continuar" Continuamos el juego por lo que dejamos de pintar el menu y reanudamos el juego
            if (GUI.Button(areaButn2, new GUIContent("Continuar")))
            {
                sonidoFondo.volume=0.5F;//Subimos sonido
                pintarMenu = false;//Dejamos de pintar el menu GUI
                PausarJuego(false);//Al hacer click en el boton continuar reanudamos el juego.

            }
     
        //Dejamos de pintar menu y volvemos al menu
        if (GUI.Button(areaButn3, new GUIContent("Salir")))
        {
            //PausarJuego(true);//Para dejarlo a 1 y evitar problemas en otras escenas?
            SceneManager.LoadScene("Ej1Menu");
        }
     
    }


}
