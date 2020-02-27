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
    int numMunicion;
    public int municionInicial=35;//Numero de flechas con las que se inicia
    public Text textNumVidaCorazon;
    public int numVidaCorazon;
    public int numVidaInicial=30;//puntos de vida con los que se inica
    public Text textNumeroMonedas;
    public Text textResultadoJuego;
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
    int numeroEnemigosTotalesRestantes = 0;
    //Conjunto de enemigos
    GameObject[] conjuntoEnemigos;

    //Instanciar mas enemigos cada x segundos
    bool crearEnemigo=true;

    //Victoria 0 indica que ni perdio ni ha gado aun, 1 ha ganado -1 ha perdido
    int hasGanado=0;

    //Pociones
    public Text textNumPociones;
    int numPociones = 0;
  
    // Use this for initialization
    void Start()
    {
        PausarJuego(false);//Quitamos la pausa por si en algunr einicio se queda;
        //Monedas
        textNumeroMonedas.text = numeroDeMonedas.ToString();
        //Municion
        numMunicion = municionInicial;
        textNumMunicion.text = numMunicion.ToString();
        GameObject.FindGameObjectWithTag("arma").SendMessage("TieneMunicion", numMunicion);//Actualizamos la  varible numMunicion de la clase FlechaAnimaDisparo al empezar(haremos los mismo al recargar)
        //Recolecion de conjunto de gameobject con el tag "enemigo"
        conjuntoEnemigos = GameObject.FindGameObjectsWithTag("enemigo");

        //Vida
        numVidaCorazon = numVidaInicial;
        textNumVidaCorazon.text = numVidaCorazon.ToString();
        foreach(GameObject item in conjuntoEnemigos)//Informamos a cada uno de los objetos con ese tag
            GameObject.FindGameObjectWithTag(item.tag).SendMessage("InformarAlEnemigoDeVidaDeJugador", numVidaCorazon);//Informamos al enemigo de la vida del jugador para que sepa cuando parar de atacar
        //Reloj
        tiempoInicial = 360;//Tiempo limite de la partida
        tiempoAMostrarEnSegundos = tiempoInicial;

        //Recoger puntos de Respawn
        puntosRespawn = GameObject.FindGameObjectsWithTag("puntoRespawn");
        for (int i = 0; i < puntosRespawn.Length; i++)//Instanciamosun enemigo en cada respawn
        {
            Instantiate(prefabEnemigo, puntosRespawn[i].transform.position, puntosRespawn[i].transform.rotation);//Instanciamos Enemigo
           
        }

        //Pociones
        textNumPociones.text = numPociones.ToString();
       
    }

    private void FixedUpdate()
    {      
        //Reloj
        if (textContadorTiempo.text != "00:00")//El juego continua y el tiempo sigue corriendo
        {
            escalaDeTiempo = Time.deltaTime * velocidadDelTiempo;
            tiempoAMostrarEnSegundos -= escalaDeTiempo;
            RelojTiempoJuego(tiempoAMostrarEnSegundos);
        }
        else if (textContadorTiempo.text == "00:00")// Perdio!
        {
            //Enviamos mensaje a la clase MovimientoJugador par aque haga sonar el audio
            GameObject.FindGameObjectWithTag("jugador").SendMessage("SonarDerrota");//No funciona por que se para el juego(Creo)
            pintarMenuFinalPartida = true;//para que no pinte el boton de continuar al termianr
            //Fin del juego
            hasGanado = -1;//Indicamos que el jugador a perdido, (lo que mostrara un mensaje al jugador de que ha perdido)
            pintarMenu = true;//Pintamos el menu por lo que pararemos el juego
            

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
        if (Input.GetKey(KeyCode.Space))//Gasta una pocion si tiene y la vida es inferior al tope (30)
        {
            GastarPocion();
        }
        if (numVidaCorazon == 0 && textContadorTiempo.text != "00:00")//Has perdido,cuando te han matado, por que tu vida es 0 pero aun tenias tiempo de juego
        {
            //Enviamos mensaje a la clase MovimientoJugador par aque haga sonar el audio
            GameObject.FindGameObjectWithTag("jugador").SendMessage("SonarDerrota");//No funciona por que se para el juego(Creo)
            pintarMenuFinalPartida = true;//Si esto es verdad el  menu GUi pinta todo menos el boton continuar
            hasGanado = -1;//Indicamos que le jugador a perdido (lo que mostrara un mensaje al jugador de que ha perdido)
            pintarMenu = true;           

        }
        if (numMunicion == 0)//Cuando la municion llega a 0 se avisa a la clase FlechaAnimaDisparo
        {
            GameObject.FindGameObjectWithTag("arma").SendMessage("TieneMunicion", numMunicion);
        }
        if (!juegoEnPausa)//Es decir mientras el juego no este en pausa
        {
            StartCoroutine("InstanciarEnemigo");
        }
        numeroEnemigosTotalesRestantes = GameObject.FindGameObjectsWithTag("enemigo").Length;//Cuantos  objetos con el tag enemigo tenemos en la escena actualmente.
        if (numeroEnemigosTotalesRestantes == 0)
        {
            //Enviamos mensaje a la clase MovimientoJugador par aque haga sonar el audio
            GameObject.FindGameObjectWithTag("jugador").SendMessage("SonarVictoria");//No funciona por que se para el juego(Creo)
            Debug.Log("GANASSTEEEEEEEEEEEEEEEEE!!!");          
            hasGanado = 1;//Indicamos que ha ganado la partida
            pintarMenuFinalPartida = true;//Indicamos que la partida se termino, para que pinte el menu correspondiente
            pintarMenu = true;//Ejecutamos el pintar menu GUI y a la vez en este mismo pausamos el juego
            
        }
          

    }

    //Este metodo instancia un enemigo cada 30 segundos en un punto aleatorio del mapa
    IEnumerator InstanciarEnemigo() { 
        if (crearEnemigo)
        {
            crearEnemigo = false;//Flag para controlar la espera
            yield return new WaitForSeconds(30F);//esperamos 30 segundos 
            GameObject puntoParaInstanciar = puntosRespawn[Random.Range(0, puntosRespawn.Length)];//Punto aleatorio
            Instantiate(prefabEnemigo, puntoParaInstanciar.transform.position, puntoParaInstanciar.transform.rotation);//Instanciar enemigo           
            crearEnemigo = true;//Hasta que no pasan 30 segundos este flag no vuelve a ser true, por lo que nos aseguramos que siempre espere 30 segundos de lo contrario solo esperaria una vez

        }

    }

   /*Este metodo para o reanuda el juego
    Si el parametro pasado es true --> pausra el juego, si es false lo reanudara*/
    public void PausarJuego(bool pausa) {
        juegoEnPausa = pausa;
        if(juegoEnPausa)
            Time.timeScale = 0;//Velocidad del juego nula por lo tanto parada
        else if(!juegoEnPausa)
            Time.timeScale = 1;//Velocidad del juego normal     
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
        PausarJuego(true);//Paramos el juego
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
            //Al hacer click en este boton "Continuar" Continuamos el juego por lo que dejamos de pintar el menu y reanudamos el juego
            if (GUI.Button(areaButn2, new GUIContent("Continuar")))
            {
                pintarMenu = false;//Dejamos de pintar el menu GUI
                                   //juegoEnPausa = false;//Quitamos pausa del juego
                                   // NotificarJuegoEnPausa();
                PausarJuego(false);//Al hacer click en el boton continuar reanudamos el juego.

            }
        }
        else {//En caso de que la partida finalizase, es decir pintarMenuFinalParida sea true
            if (hasGanado == 1)//El jugador ha GANADO
            {
                
                //GUI.Label(areaButn2, "Has Ganado!");
                textResultadoJuego.color = Color.green;
                textResultadoJuego.text = "Has Ganado ^.^!";
            }
            else if (hasGanado == -1)//El jugador ha perdido
            {
                //GUI.Label(areaButn2, "Has Perdido!");
                textResultadoJuego.color = Color.red;
                textResultadoJuego.text = "Has Perdido! v.v ";
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
        }
        //Salimos del juego y cargamos la escena del Menu Ej1Menu
        if (GUI.Button(areaButn5, new GUIContent("Salir")))
        {
            SceneManager.LoadScene("Ej1Menu");
        }
    }

    public void ActivarPintarMenu() {
        pintarMenu = true;
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
           
            //GameObject.FindGameObjectWithTag("enemigo").SendMessage("InformarAlEnemigoDeVidaDeJugador", numVidaCorazon);//Informamos al enemigo que la vida del jugador cambio para que sepa si debe parar de atacar
        }
    }

    private void GanarMonedas(int numMonedas) {
        numeroDeMonedas += numMonedas;
        textNumeroMonedas.text = numeroDeMonedas.ToString();
        GameObject.FindGameObjectWithTag("cofre").SendMessage("NumeroDeMonedasGanadas", numeroDeMonedas);
    }

    private void GastarPocion() {
        Debug.Log(numVidaCorazon);
        if (numPociones>0 && numVidaCorazon < 30)//Si tiene pociones y la vida es menor de 30 (el tope)
        {
            //Enviamos mensaje a la clase MovimientoJugador par aque haga sonar el audio
            GameObject.FindGameObjectWithTag("jugador").SendMessage("SonarBeberPocion");
            Debug.Log("SONANDO pocion");
            numPociones--;//Disminuimos o restamos una pociones
            textNumPociones.text = numPociones.ToString();
            int vidaFaltante = 30 - numVidaCorazon;//Comprobamos cuanta vida falta exactamente
            numVidaCorazon += vidaFaltante;//Restablecemos la salud
            textNumVidaCorazon.text = numVidaCorazon.ToString();
        }
    }

    //Metodo con el que se comunica  la clase "AperturaCofres" cuando se gana una pocion
    private void GanarPocion()
    {
        numPociones++;
        textNumPociones.text = numPociones.ToString();
    }



}
