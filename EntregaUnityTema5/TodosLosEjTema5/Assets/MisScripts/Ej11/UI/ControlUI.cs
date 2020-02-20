using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*Este script esta asignado al  objeto Canvas de la jerarquia y desde el controlamos toda la interfaz del usuario,
 como la vida, el dinero, el tiempo, municion, y menu GUI para salir parar el juego o optener ayuda*/
public class ControlUI : MonoBehaviour
{
    public static bool juegoEnPausa = false;//Esta variable es accesible desde cualquier script y sirve para indicar cuando el juego esta parado o no, como cuando termina o se muestra algun menu.
    public Text textNumMunicion;
    public static int numMunicion;
    public GameObject panelAyuda1; 

    //Pintar OnGUI
    public static bool pintarMenu = false;//Cuando es falso no pinta cuando es true si

    //Reloj de tiempo del juego
    int tiempoInicial;
    public float velocidadDelTiempo = 1;//puede se velocidad normal 1, el doble de velocidad normal 2 o parado 0.
    float escalaDeTiempo = 0f;//Escala de tiempo  obtenida del tiempo transcurrido en cada frame por TimeDeltaTime
    float tiempoAMostrarEnSegundos =0f;

    public Text textContadorTiempo;
   
    string textoDeReloj;
    // Use this for initialization
    void Start()
    {
        numMunicion = 10;
        textNumMunicion.text = numMunicion.ToString();

        //Reloj
        tiempoInicial = 300;
        tiempoAMostrarEnSegundos = tiempoInicial;
    }

    private void FixedUpdate()
    {
        //Reloj
        if (textContadorTiempo.text != "00:00")
        {
            escalaDeTiempo = Time.deltaTime * velocidadDelTiempo;
            tiempoAMostrarEnSegundos -= escalaDeTiempo;
            RelojTiempoJuego(tiempoAMostrarEnSegundos);
        }
        else {//Se para el juego por que el tiempo llego a 00:00
            juegoEnPausa = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.K))//Recarga municion temporalmente con la K
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
        juegoEnPausa = true;//Ponemos en pausa el juego
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
            pintarMenu = false;//Dejamos de pintar el menu GUI
            juegoEnPausa = false;//Quitamos pausa del juego
               
        }
        //Dejamos de pintar menu y pintamos una ventana nueva de ayuda sobre el juego
        if (GUI.Button(areaButn3, new GUIContent("Ayuda")))
        {
            panelAyuda1.SetActive(true);
            //Desactivamos el menu GUI para mostrar los paneles de ayuda
            pintarMenu = false;
        }
        //Reiniciamos la escena Ej8 para reiniciar el juego 
        if (GUI.Button(areaButn4, new GUIContent("Reiniciar"))) {
            SceneManager.LoadScene("Ej11");

        }
        //Salimos del juego y cargamos la escena del Menu Ej1Menu
        if (GUI.Button(areaButn5, new GUIContent("Salir"))) {
            SceneManager.LoadScene("Ej1Menu");
        }
    }

    //Calcula el tiempo pasado en segundos a minutos y segundos  para mostrarlo
    private void RelojTiempoJuego(float tiempoEnSegundos) {

        uint minutos = 5;
        uint segundos = 0;
        minutos = (uint)tiempoEnSegundos / 60;
        segundos = (uint)tiempoEnSegundos % 60;
        textContadorTiempo.text = minutos.ToString("00") + ":" + segundos.ToString("00");
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
