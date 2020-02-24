using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour {

    Animator animatorGuerrero;
    GameObject jugador;
    public float vision = 8;//Area  a la que el enemigo puede detectar al jugador
    float discantiaTarget=0;
    Vector3 posInicial; //Posicion Inicial del enemigo al arrancar
    public float velocidad =1F;
    bool quitarVida;
    //NavMeshAgent del enemigo para evitar obstaculos
    NavMeshAgent navEnemigo;
    public bool enemigoEnCamino = false;//Define si el enemigo esta persiguiendo al jugador;
    Transform transformEnemigo;

    //Puntos de vida represntado por cubos
    int vidaEnemigo = 20;
    public GameObject cincoDeVida;
    public GameObject diezDeVida;
    public GameObject quinceDeVida;
    public GameObject veinteDeVida;
    bool enemigoVivo = true;

    //Daño de el enemigo
    int danioDeAtaque = 5;//Representa la cantidad de vida que puede quitar el enemigo al jugador de un golpe

    //Puntos de ruta
    //public GameObject puntoA;
    //public GameObject puntoB;
    //Estado del juego Pausado/Reanudado
    bool juegoEnPausa = false;
    //Vida jugador
    int vidaJugador=30;

    // Use this for initialization
    void Start () {
        transformEnemigo = gameObject.GetComponent<Transform>();
        jugador = GameObject.FindGameObjectWithTag("jugador");
        animatorGuerrero = GetComponent<Animator>();
        posInicial = transformEnemigo.position;
        quitarVida = true;

        //NavMeshAgent del enemigo para evitar obstaculos
        navEnemigo = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update () {
     
       /* if (!juegoEnPausa)//Si el juego no esta en pausa
        {*/
            if (enemigoVivo)
            {              
                discantiaTarget = Vector3.Distance(jugador.transform.position, transformEnemigo.position);
                if (discantiaTarget < vision || enemigoEnCamino)//Si la distancia entre el jugador y el enemigo es menor que la vision, entonces se dirige a por el jugador
                {   
                    StartCoroutine(PerseguirJugador());
                }
                else//Si no esta en el rango de vision del enemigo el jugador, el enemigo se mueve entre los puntos a y b
                {
                    StartCoroutine("Patrullar");
                    Debug.Log("No persigue!");
                }
            }
            else if (!enemigoVivo)//Si muere el enemigo
            {
                StartCoroutine("EnemigoMuerto");
            }
        //}juegoEnPausa &&
        else if (vidaJugador == 0)//Si el jugador a muerto y el juego no esta pausado
        {
            StartCoroutine(VolverACasa());
        }
       /* else//Si el juego esta en pausa
        {           
            Debug.Log("JUEGO EN PAUSA");           
            StartCoroutine("PausadoEnemigo");           
        }*/


    }
     
   
    IEnumerator Patrullar() {

      
        yield return null;
    
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puntoA")
        {
            Debug.Log("ENTRE EN A");
            IrAunPuntoDeUnObjeto(puntoB.transform);
        }
        if (other.gameObject.tag == "puntoB")
        {
            Debug.Log("ENTRE EN B");
            IrAunPuntoDeUnObjeto(puntoA.transform);
        }
    }*/

    //Ir a un punto concreto en relacion al transform del objeto destino
    public void IrAunPuntoDeUnObjeto(Transform transformDestino)
    {
        if (enemigoVivo && !enemigoEnCamino)
        {
            animatorGuerrero.SetBool("andar", true);//Deja de andar 
            animatorGuerrero.SetBool("atacar", false);//Deja de atacar
            float areaDePosicion = 1;
            Vector3 puntoDevuelta = transformDestino.position;//Posicion Inicial del objeto
            navEnemigo.destination = puntoDevuelta;
            discantiaTarget = Vector3.Distance(puntoDevuelta, transformEnemigo.position);
            if (discantiaTarget < areaDePosicion)//Si la distancia entre el discantiaTarget y el enemigo es menor que la areaDePosInicial, entonces llego a casa
            {
                navEnemigo.destination = transformEnemigo.position;//Para que se pare                            
            }
        }
    }

    //Este metodo recibe un mensaje de la clase ControlUI cuando se ha modificado la variable JuegoPausado, indicando si esta en pausa o reanudado
   /* public void PausarOReanudadJuego(bool estado)
    {
        juegoEnPausa = estado;
    }*/

   
    //Cuando le disparamos u na flecha y colisiona con el le quitamos vida(que no es mas que ocultar cubos)
    private void OnCollisionEnter(Collision collision)
    {
        if (enemigoVivo)//Enemigo vivo
        {
            if (collision.gameObject.tag == "flechaDisparada")
            {
                vidaEnemigo -= 5;
                if (vidaEnemigo >= 0)
                {
                    switch (vidaEnemigo)
                    {
                        case 0:
                            cincoDeVida.GetComponent<Renderer>().enabled = false; ;                        
                            enemigoVivo = false;//Esta muerto
                            enemigoEnCamino = false;//para de perseguir al jugador

                            break;
                        case 5:
                            diezDeVida.GetComponent<Renderer>().enabled = false;
                            break;
                        case 10:
                            quinceDeVida.GetComponent<Renderer>().enabled = false;
                            break;
                        case 15:
                            veinteDeVida.GetComponent<Renderer>().enabled = false;
                            break;
                    }
                }
                if (!enemigoEnCamino)//Si no lo esta persiguiendo al sufrir daño, lo empezara a perseguir
                    enemigoEnCamino = true;
                Debug.Log("AU!!!!");
                Destroy(collision.gameObject);//Destruimos la flecha              
            }
        }
        else if (!enemigoVivo)//Si el enemigo esta muerto
        {
            animatorGuerrero.SetBool("andar", false);//para de andar          
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "jugador")//En contacto con el jugador
        {
            if (enemigoVivo)
            {
                //andamos
                animatorGuerrero.SetBool("atacar", false);//Dejo de atacar
                //animatorGuerrero.SetBool("andar", true);//Empieza a andar
            }
           
        }
    }

    //Al colisionar el enemigo con el jugador, este empieza a atacar y quitar vida
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "jugador")
        {
            //Atacamos
            if (vidaJugador > 0)
                StartCoroutine("Atacar");
            else if (juegoEnPausa)
                StopCoroutine("Atacar");
        }
      
    }
    //El enemigo optiene la cantiddad de vida del jugador para saber si debe parar de atacar
    public void InformarAlEnemigoDeVidaDeJugador(int numVidaJugador) {
        vidaJugador = numVidaJugador;     
    }

    //El enemigo resta vida al jugador cada 4 segundos
    IEnumerator Atacar()
    {
        //Debug.Log("1 METODO ATACANDO ESTADO  JUEGO -->" + juegoEnPausa);
        if (enemigoVivo && !juegoEnPausa)//Si el enemigo esta vivo y el juego no esta en pausa
        {
            animatorGuerrero.SetBool("andar", false);//Deja de andar
            animatorGuerrero.SetBool("atacar", true);//Empieza a  atacar
            if (quitarVida)//Esta  bandera nos permite quitar vida solo cada 4 segundos de forma continua(de lo contrario solo esperaria 4 segundos la primera vez)
            {
                quitarVida = false;
                yield return new WaitForSeconds(1.8F);//esperamos 1.8 segundos 
                if (!juegoEnPausa)//Si no esta en pausa le quitamos vida
                {
                    //Enviamos la notificacion a la Script ControlUI, la cual esta asociada al Canvas que tiene un tag UI para que el jugador pueda ver que le quitaron vida
                    GameObject.FindWithTag("UI").SendMessage("QuitarVida", danioDeAtaque);
                    Debug.Log("Menos 5 de vida");
                    quitarVida = true;
                }

            }

        }
        else if (enemigoVivo &&juegoEnPausa)/*Si esta pausado paramos la animacion de atacar(de otro modo puede que ne el caso de parar el juego
            justo cuando empieza a pegar, no pare de realizar la animacion, aunq ue no quite vida)*/
        {
            animatorGuerrero.SetBool("andar", false);//Deja de andar
            animatorGuerrero.SetBool("atacar", false);//Para de  atacar
        }
    }

    //El enemigo persigue al jugador
    IEnumerator PerseguirJugador() {        
        if (vidaJugador > 0 && !juegoEnPausa && enemigoVivo)
        {
            //Debug.Log("Persiguiendo");
            animatorGuerrero.SetBool("andar", true);//Empieza a andar             
            navEnemigo.destination = jugador.transform.position;
            enemigoEnCamino = true;
        }
        yield return null;
    }

    //Detiene al enemigo cuando se pulsa la tecla Esc mostrando el menu(es decir cuando se pausa el juego)
    /*IEnumerator PausadoEnemigo()
    {
        Debug.Log(gameObject.name + "Para mi el estado del juego es " + juegoEnPausa+ " y la vida del jugador "+vidaJugador );
        if (juegoEnPausa && vidaJugador > 0)//Si el juego esta en pausa
        {
            Debug.Log(gameObject.name +" Enemigo parado");
            animatorGuerrero.SetBool("andar", false);//Deja de andar             
            navEnemigo.destination = transformEnemigo.position;
            if (enemigoEnCamino)
                enemigoEnCamino = true;
            else if (!enemigoEnCamino)
            {
                enemigoEnCamino = false;
            }
            
                    
        }
        yield return null;
    }*/

    //Cuando el enemigo muere, se detiene en su posicion actual y realiza la animacion de muerte, pos teriomente es destroido
    IEnumerator EnemigoMuerto()
    {
        if (vidaJugador > 0 && !juegoEnPausa)
        {
            Debug.Log("muerto");
            //Ha muerto
            animatorGuerrero.SetBool("muerto", true);//Animacion de morir 
            animatorGuerrero.SetBool("finAnimacion", true);
            navEnemigo.destination = transform.position;
            enemigoEnCamino = false;
            yield return new WaitForSeconds(0.92F);
            Destroy(gameObject);
            GameObject.FindWithTag("UI").SendMessage("GanarMonedas",Random.Range(1,5));
        }
      
      
    }

    //Devuelve el Enemigo a la zona donde empezo aprozimadamente y cuando llega desactiva la animacion de andar
    IEnumerator VolverACasa() {
        animatorGuerrero.SetBool("atacar", false);//Deja de atacar
        float areaDePosicion = 2;
        Vector3 puntoDevuelta = posInicial;//Posicion Inicial del objeto
        navEnemigo.destination = puntoDevuelta;
        discantiaTarget = Vector3.Distance(puntoDevuelta, transformEnemigo.position);      
        if (discantiaTarget < areaDePosicion)//Si la distancia entre el discantiaTarget y el enemigo es menor que la areaDePosInicial, entonces llego a casa
        {
            navEnemigo.destination = transformEnemigo.position;//Para que se pare
            animatorGuerrero.SetBool("andar", false);//Deja de andar 
        }

        yield return null;
    }






}
