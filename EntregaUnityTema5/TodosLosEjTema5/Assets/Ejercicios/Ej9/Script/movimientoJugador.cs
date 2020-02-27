using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
/*Script asignado al prefab jugador*/
public class movimientoJugador : MonoBehaviour {
    public bool pintarMenu = false;//Cuando es falso no pinta cuando es true si
    public bool juegoEnPausa = false;
    public bool juegoFinalizado = false;//Cuando el juego esta finalizado, no se pinta el boton de continuar al abrir el menu GUI
    int numVidas = 3;
    public float velocidadAndar = 1F;
    public float velocidadRotacion = 40F;
    Animator animacionJugador;
    public TextMesh texto3d;
    static int colisionObjectoMismoTipo = 0;
    string tipoColisionAnterior =null;//Guardamos el tag del tipo de colision anterior
    //Puntos
    float esferaTipo2 = 2;
    float esferaTipo4 = 4;
    float cuboTipo3 = 3;
    float cuboTipo5 = 5;
    //texto puntos
    public Text textPuntos;
    float puntosTotales = 0;
    float puntosAnteriores = 0;//para calcular la diferencia de 3 puntos al restar, ya que cad 3 puntos pierde una vida
    //Numero de objetos de cada tipo
    int numCuboTipo3;
    int numCuboTipo5;
    int numEsferaTipo2;
    int numEsferaTipo4;
    int totalDeObstaculos;
    //texto resultado juego
    public Text textResultJuego;
    public Text textNumObjetosRestantes;
    // Use this for initialization
    void Start () {
        animacionJugador = GetComponent<Animator>();
        texto3d.text =  numVidas.ToString();
        textPuntos.text="Puntos: "+puntosTotales.ToString("00:00");
        tipoColisionAnterior = "nada";
        textResultJuego.text = "";
        numEsferaTipo2 = GameObject.FindGameObjectsWithTag("puntos2").Length;
        numCuboTipo3 = GameObject.FindGameObjectsWithTag("puntos3").Length;
        numEsferaTipo4 = GameObject.FindGameObjectsWithTag("puntos4").Length;
        numCuboTipo5 = GameObject.FindGameObjectsWithTag("puntos5").Length;
        totalDeObstaculos = numCuboTipo3 + numCuboTipo5 + numEsferaTipo4 + numEsferaTipo2;//Cantidad total de objetos que puntuan
        textNumObjetosRestantes.text = "Numero de objetos restantes: " + totalDeObstaculos.ToString("00");
    }
	
	// Update is called once per frame
	void Update () {
        animacionJugador.SetBool("andar", false);
        //Desplazamiendo del personaje
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(0, 0, Input.GetAxis("Vertical") * velocidadAndar * Time.deltaTime);
            animacionJugador.SetBool("andar", true);
        }
        //transform.Translate(Input.GetAxis("Horizontal") * velocidadAndar * Time.deltaTime, 0, 0);
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * velocidadRotacion * Time.deltaTime, 0);
            animacionJugador.SetBool("andar", true);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            pintarMenu = true;
        }
        textNumObjetosRestantes.text = "Numero de objetos restantes: "+ totalDeObstaculos.ToString("00");

        if (totalDeObstaculos == 0 &&numVidas>0)//Ha ganado por que no quedan mas objetos y tiene mas de 0 vidas
        {
            textResultJuego.color = Color.green;
            textResultJuego.text = "Has ganado";
            juegoFinalizado = true;
            pintarMenu = true;
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
        PausarJuego(true);//Paramos el juego
        int ancho = 200;
        int alto = 30;
        int x = (Screen.width / 2) - (ancho / 2);//Cogemos el ancho de  la pantall lo dividimos entre 2 y  le restamos nuestro ancho entre 2
        int y = (Screen.height / 2) - (alto / 2);
        Rect areaButn2 = new Rect(x, y - 40, ancho, alto);
        Rect areaButn3 = new Rect(x, y, ancho, alto);
        Rect areaButn4 = new Rect(x, y+40, ancho, alto);
        //Al hacer click en este boton "Continuar" Continuamos el juego por lo que dejamos de pintar el menu y reanudamos el juego
        if (!juegoFinalizado)
        {
            if (GUI.Button(areaButn2, new GUIContent("Continuar")))
            {
                pintarMenu = false;//Dejamos de pintar el menu GUI
                PausarJuego(false);//Al hacer click en el boton continuar reanudamos el juego.

            }
        }

        //Dejamos de pintar menu cargamos de nuevo la escena
        if (GUI.Button(areaButn3, new GUIContent("Reiniciar")))
        {
            
            SceneManager.LoadScene("Ej9");
        }

        //Dejamos de pintar menu y volvemos al menu
        if (GUI.Button(areaButn4, new GUIContent("Salir")))
        {
            
            SceneManager.LoadScene("Ej1Menu");
        }


    }
 
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "puntos2"://esfera
                if (tipoColisionAnterior.Equals("nada"))//si no hay colision anterior aun
                {
                    puntosTotales += esferaTipo2;
                }
                break;
            case "puntos3"://cubo
                if (tipoColisionAnterior.Equals("nada"))//si no hay colision anterior aun
                {
                    puntosTotales += cuboTipo3;
                }
                break;
            case "puntos4"://esfera
                if (tipoColisionAnterior.Equals("nada"))//si no hay colision anterior aun
                {
                    puntosTotales += esferaTipo4;
                }
                break;
            case "puntos5"://cubo
                if (tipoColisionAnterior.Equals("nada"))//si no hay colision anterior aun
                {
                    puntosTotales += cuboTipo5;
                }
                break;
        }
    }
   
    private void OnCollisionExit(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "puntos2"://esfera es el tag puntos2
                Debug.Log("Entrando en el tipo 2" + "tipo anterior: " + tipoColisionAnterior);
                if (tipoColisionAnterior != "puntos2" && tipoColisionAnterior != "puntos4")//Si  no colisionamos con el mismo tipo de objeto que antes(es decir tipo esferas)
                {
                    if (tipoColisionAnterior == "puntos3" || tipoColisionAnterior == "puntos5")//Es decir la anterior colision fueron cubos
                    {
                        puntosTotales += esferaTipo2/2;
                        Destroy(collision.gameObject);//Destruimos el objeto
                        totalDeObstaculos--;//Restamos un objeto menos que punta en la escena
                    }                        
                }
                else
                {
                    //preguntamos que tipo de esfera fue la anterior colision
                    if (tipoColisionAnterior == "puntos4")
                        puntosTotales = puntosTotales - (esferaTipo4 + esferaTipo2);//Restamos los puntos de la anterior colision y de la anterior
                    if (tipoColisionAnterior == "puntos2")
                        puntosTotales = puntosTotales - (esferaTipo2 + esferaTipo2);//restamos los puntos de la anterior colision y de la actual

                    //Perdio Puntos comprobaremos si debera perder vidas
                    perdidaDeVida();
                }
                tipoColisionAnterior = collision.gameObject.tag; //Guardamos la colision para preguntar despues si se colisiona con objeto del mismo tipo             
                break;
            case "puntos3"://cubo es el tag puntos3
                Debug.Log("Entrando en el tipo 3" +"tipo anterior: "+tipoColisionAnterior);
                if (tipoColisionAnterior != "puntos3" && tipoColisionAnterior != "puntos5")//Si  no colisionamos con el mismo tipo de objeto que antes(es decir tipo esferas)
                {
                    if (tipoColisionAnterior == "puntos2" || tipoColisionAnterior == "puntos4")//Es decir la anterior colision fueron esferas
                    {
                        puntosTotales += cuboTipo3/2;
                        Destroy(collision.gameObject);
                        totalDeObstaculos--;//Restamos un objeto menos que punta en la escena
                    }

                }
                else
                {
                    //preguntamos que tipo de esfera fue la anterior colision
                    if (tipoColisionAnterior == "puntos3")
                        puntosTotales = puntosTotales - (cuboTipo3 + cuboTipo3);//Restamos los puntos de la anterior colision y de la anterior
                    if (tipoColisionAnterior == "puntos5")
                        puntosTotales = puntosTotales - (cuboTipo3 + cuboTipo5);//restamos los puntos de la anterior colision y de la actual

                    //Perdio Puntos comprobaremos si debera perder vidas
                    perdidaDeVida();
                }
                tipoColisionAnterior = collision.gameObject.tag; //Guardamos la colision para preguntar despues si se colisiona con objeto del mismo tipo             
                break;
            case "puntos4"://esfera es el tag puntos4
                Debug.Log("Entrando en el tipo 4" + "tipo anterior: " + tipoColisionAnterior);
                if (tipoColisionAnterior != "puntos2" && tipoColisionAnterior != "puntos4")//Si  no colisionamos con el mismo tipo de objeto que antes(es decir tipo esferas)
                {
                    if (tipoColisionAnterior == "puntos3" || tipoColisionAnterior == "puntos5")//Es decir la anterior colision fueron cubos
                    {
                        puntosTotales += esferaTipo4/2;
                        Destroy(collision.gameObject);
                        totalDeObstaculos--;//Restamos un objeto menos que punta en la escena
                    }

                }
                else
                {
                    //preguntamos que tipo de esfera fue la anterior colision
                    if (tipoColisionAnterior == "puntos4")
                        puntosTotales = puntosTotales - (esferaTipo4 + esferaTipo2);//Restamos los puntos de la anterior colision y de la anterior
                    if (tipoColisionAnterior == "puntos2")
                        puntosTotales = puntosTotales - (esferaTipo2 + esferaTipo2);//restamos los puntos de la anterior colision y de la actual

                    //Perdio Puntos comprobaremos si debera perder vidas
                    perdidaDeVida();
                }
                tipoColisionAnterior = collision.gameObject.tag; //Guardamos la colision para preguntar despues si se colisiona con objeto del mismo tipo             
                break;
            case "puntos5"://cubo es el tag puntos5
                Debug.Log("Entrando en el tipo 5" + "tipo anterior: " + tipoColisionAnterior);
                if (tipoColisionAnterior != "puntos3" && tipoColisionAnterior != "puntos5")//Si  no colisionamos con el mismo tipo de objeto que antes(es decir tipo esferas)
                {
                    if (tipoColisionAnterior == "puntos2" || tipoColisionAnterior == "puntos4")//Es decir la anterior colision fueron esferas
                    {
                        Debug.Log("SUMA?");
                        puntosTotales += cuboTipo5 / 2;//Suma la mitad
                        Destroy(collision.gameObject);
                        totalDeObstaculos--;//Restamos un objeto menos que punta en la escena
                    }
                }
                else
                {
                    Debug.Log("RESTA?");
                    //preguntamos que tipo de esfera fue la anterior colision
                    if (tipoColisionAnterior == "puntos3")
                        puntosTotales = puntosTotales - (cuboTipo3 + cuboTipo3);//Restamos los puntos de la anterior colision y de la anterior
                    if (tipoColisionAnterior == "puntos5")
                        puntosTotales = puntosTotales - (cuboTipo5 + cuboTipo5);//restamos los puntos de la anterior colision y de la actual
                    //Perdio Puntos comprobaremos si debera perder vidas
                    perdidaDeVida();
                }
                tipoColisionAnterior = collision.gameObject.tag; //Guardamos la colision para preguntar despues si se colisiona con objeto del mismo tipo             
                break;
        }
        textPuntos.text = "Puntos: " + puntosTotales.ToString("0.00");
        puntosAnteriores = puntosTotales;//Guardamos los puntos obtenidos al final de la colision para calcular luego la diferencia antes de el resultado de la siguiente colision
    }

    private void perdidaDeVida()
    {
        float result =  puntosAnteriores - puntosTotales;
        Debug.Log("##RESTANDO##");
        int n = 0;//Numeoro de veces que se le ha restado 3 puntos al jugador, esto determinara el numero de vidas que se le resta
        n =(int)result / 3;
        n = Mathf.Abs(n);//Para evitar resultados negativos en caso de que el jugador tenga puntos negativos
        Debug.Log("Diferencia entre pActuales "+puntosTotales+" y PAnteriores "+puntosAnteriores+" = "+result+" "+ "numero de veces restado 3 puntos al jugador " + n);
        if (numVidas > 0)
        {
            numVidas = numVidas - n;
            texto3d.text ="Vidas: "+ numVidas.ToString();
        }
        if (numVidas <= 0)
        {
            juegoFinalizado = true;//El juego ha finalizado(ha muerto el jugador)
            pintarMenu = true;
            texto3d.text = numVidas.ToString();
            textResultJuego.color = Color.red;
            textResultJuego.text = "Has perdido";
        }
       
    }
}
