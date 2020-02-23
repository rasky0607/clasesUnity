﻿using System.Collections;
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
    int numMunicion;
    public int municionInicial=20;//Numero de flechas con las que se inicia
    public Text textNumVidaCorazon;
    public int numVidaCorazon;
    public int numVidaInicial=30;//puntos de vida con los que se inica
    public Text textNumeroMonedas;
    int numeroDeMonedas = 0;
    public GameObject panelAyuda1;
    //public GameObject prefabCargarMunicion;
    //Puntos de reaparicion del enemigo (puede que no se implemente), pero se dejara picado igualmente
    GameObject[] puntosRespawn;
    //Pintar OnGUI
    public bool pintarMenu = false;//Cuando es falso no pinta cuando es true si
    bool pintarMenuFinalPartida = false;//Cuando la vida a 0 antes que el tiempo

    //Reloj de tiempo del juego
    int tiempoInicial;
    public float velocidadDelTiempo = 1;//puede se velocidad normal 1, el doble de velocidad normal 2 o parado 0.
    float escalaDeTiempo = 0f;//Escala de tiempo  obtenida del tiempo transcurrido en cada frame por TimeDeltaTime
    float tiempoAMostrarEnSegundos = 0f;
    public Text textContadorTiempo;
    string textoDeReloj;

    //Prefab Enemigo
     public GameObject prefabEnemigo;

    // Use this for initialization
    void Start()
    {
        //Monedas
        textNumeroMonedas.text = numeroDeMonedas.ToString();
        //Municion
        numMunicion = municionInicial;
        textNumMunicion.text = numMunicion.ToString();
        GameObject.FindGameObjectWithTag("arma").SendMessage("TieneMunicion", numMunicion);//Actualizamos la  varible numMunicion de la clase FlechaAnimaDisparo al empezar(haremos los mismo al recargar)

        //Vida
        numVidaCorazon = numVidaInicial;
        textNumVidaCorazon.text = numVidaCorazon.ToString();
        GameObject.FindGameObjectWithTag("enemigo").SendMessage("InformarAlEnemigoDeVidaDeJugador", numVidaCorazon);//Informamos al enemigo de la vida del jugador para que sepa cuando parar de 
        //Reloj
        tiempoInicial = 300;
        tiempoAMostrarEnSegundos = tiempoInicial;

        //Recoger puntos de Respawn
        puntosRespawn = GameObject.FindGameObjectsWithTag("puntoRespawn");
        /*for (int i = 0; i < puntosRespawn.Length; i++)
        {
            Debug.Log("respawn "+i +"--> "+puntosRespawn[i].transform.position);
        }*/
       
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
        else
        {//Se para el juego por que el tiempo llego a 00:00
            juegoEnPausa = true;
            NotificarJuegoEnPausa();
        }

    }

    // Update is called once per frame
    void Update()
    {

        //Cuando se pulsa escape pintamos un menu con GUI
        if (Input.GetKey(KeyCode.Escape))
        {
            pintarMenu = true;
        }
        if (numVidaCorazon == 0 && textContadorTiempo.text != "00:00")//Cuando te han matado, por que tu vida es 0 pero aun tenias tiempo de juego
        {
            pintarMenuFinalPartida = true;//Si esto es verdad el  menu GUi pinta todo menos el boton continuar
            pintarMenu = true;           

        }
        if (numMunicion == 0)//Cuando la municion llega a 0 se avisa a la clase FlechaAnimaDisparo
        {
            GameObject.FindGameObjectWithTag("arma").SendMessage("TieneMunicion", numMunicion);
        }
        //StartCoroutine("InstanciarEnemigo"); 

    }

    IEnumerator InstanciarEnemigo() {
        GameObject puntoParaInstanciar = puntosRespawn[Random.Range(0, puntosRespawn.Length)];
        Instantiate(prefabEnemigo, puntoParaInstanciar.transform.position, puntoParaInstanciar.transform.rotation);//Instanciamos flecha clonada enla posicion del padre 
        yield return new WaitForSeconds(30F);
    }

    //Enviamos un mensaje a todas las clases para indicar que el juego esta pausado
    public void NotificarJuegoEnPausa() {
        GameObject.FindGameObjectWithTag("arma").SendMessage("PausarOReanudadJuego", juegoEnPausa);
        GameObject.FindGameObjectWithTag("jugador").SendMessage("PausarOReanudadJuego", juegoEnPausa);
        GameObject.FindGameObjectWithTag("enemigo").SendMessage("PausarOReanudadJuego", juegoEnPausa);      
    }

    //Este metodo puede  recibir un mensaje desde cualquier otra clase para cambiar el valor de la variable pintarMenu a true
    public void ActivarPintarMenu() {
        pintarMenu = true;
    }

    //Pintamos el Menu
    private void OnGUI()
    {
        if (pintarMenu)
        {
            Menu();
        }

    }

    private void Menu()
    {
        juegoEnPausa = true;//Ponemos en pausa el juego
        NotificarJuegoEnPausa();
        int ancho = 200;
        int alto = 30;
        int x = (Screen.width / 2) - (ancho / 2);//Cogemos el ancho de  la pantall lo dividimos entre 2 y  le restamos nuestro ancho entre 2
        int y = (Screen.height / 2) - (alto / 2);
        Rect areaButn2 = new Rect(x, y - 40, ancho, alto);
        Rect areaButn3 = new Rect(x, y, ancho, alto);
        Rect areaButn4 = new Rect(x, y + 40, ancho, alto);
        Rect areaButn5 = new Rect(x, y + 80, ancho, alto);
        if (!pintarMenuFinalPartida)//Si esto es falso, es por que el juego no ha terminado al menos por la muerte del jugador(es decir tiene tiempo y vida) y el menu pintara el boton de continuar
        {
            //Continuamos el juego por l o que dejamos de pintar el menu
            if (GUI.Button(areaButn2, new GUIContent("Continuar")))
            {
                pintarMenu = false;//Dejamos de pintar el menu GUI
                juegoEnPausa = false;//Quitamos pausa del juego
                NotificarJuegoEnPausa();
            }
        }
        //Dejamos de pintar menu y pintamos una ventana nueva de ayuda sobre el juego
        if (GUI.Button(areaButn3, new GUIContent("Ayuda")))
        {
            panelAyuda1.SetActive(true);
            //Desactivamos el menu GUI para mostrar los paneles de ayuda
            pintarMenu = false;
        }
        //Reiniciamos la escena Ej11 para reiniciar el juego 
        if (GUI.Button(areaButn4, new GUIContent("Reiniciar")))
        {
            SceneManager.LoadScene("Ej11");
            juegoEnPausa = false;
            NotificarJuegoEnPausa();
            pintarMenu = false;
            if (pintarMenuFinalPartida)
            {
                numVidaCorazon = 10;
                pintarMenuFinalPartida = false;
            }
           
          

        }
        //Salimos del juego y cargamos la escena del Menu Ej1Menu
        if (GUI.Button(areaButn5, new GUIContent("Salir")))
        {
            SceneManager.LoadScene("Ej1Menu");
        }
    }



    //Calcula el tiempo pasado en segundos a minutos y segundos  para mostrarlo
    private void RelojTiempoJuego(float tiempoEnSegundos)
    {

        uint minutos = 5;
        uint segundos = 0;
        minutos = (uint)tiempoEnSegundos / 60;
        segundos = (uint)tiempoEnSegundos % 60;
        textContadorTiempo.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }

    //Metodo llamado por la clase FlechaANimaDisparo cuando se realiza un disparo de flecha para descontarla dela municion total
    private void DescontarMunicion()
    {
        if (numMunicion > 0)
        { 
            numMunicion = numMunicion - 1;
            textNumMunicion.text = numMunicion.ToString();
        }
    }
    //Aumenta la cantida de flechas que tiene del jugador disponibles
    private void RecargarMunicion(int cantidad)
    {
        numMunicion += cantidad;
        textNumMunicion.text = numMunicion.ToString();
        GameObject.FindGameObjectWithTag("arma").SendMessage("TieneMunicion", numMunicion);//Actualizamos la  varible numMunicion de la clase FlechaAnimaDisparo al recargar
    }

    //Descontar vida del jugador en el text que la representa
    private void QuitarVida(int danio)
    {
        if (numVidaCorazon > 0 && !juegoEnPausa)//Si tiene vida y el juego no esta en pausa
        {      
            numVidaCorazon -= danio;
            textNumVidaCorazon.text = numVidaCorazon.ToString();
            GameObject.FindGameObjectWithTag("enemigo").SendMessage("InformarAlEnemigoDeVidaDeJugador", numVidaCorazon);//Informamos al enemigo que la vida del jugador cambio para que sepa si debe parar de atacar
        }
    }

    private void GanarMonedas(int numMonedas) {
        numeroDeMonedas += numMonedas;
        textNumeroMonedas.text = numeroDeMonedas.ToString();
    }



}
