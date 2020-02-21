using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour {

    Animator animatorGuerrero;
    public GameObject jugador;
    float vision = 5;
    float discantiaTarget;
    Vector3 posInicial;
    public float velocidad =1F;
    bool quitarVida;
    //NavMeshAgent prueba
    NavMeshAgent navEnemigo;
    bool enemigoEnCamino = false;//Define si el enemigo esta persiguiendo al jugador;

    //Puntos de vida represntado por cubos
    int vidaEnemigo = 20;
    public GameObject cincoDeVida;
    public GameObject diezDeVida;
    public GameObject quinceDeVida;
    public GameObject veinteDeVida;
    bool enemigoVivo = true;

    //Puntos de ruta
    public GameObject puntoA;
    public GameObject puntoB;
    public GameObject puntoC;
    public GameObject puntoD;
    bool llegoA=false;
    bool llegoB = false;
    bool llegoC = false;
    bool llegoD = false;


    // Use this for initialization
    void Start () {
        animatorGuerrero = GetComponent<Animator>();
        posInicial = transform.position;
        quitarVida = true;

        //NavMeshAgent prueba
        navEnemigo = GetComponent<NavMeshAgent>();
      
    }

    // Update is called once per frame
    void Update () {
        if (!ControlUI.juegoEnPausa)//Si el juego no esta en pausa
        {
            if (enemigoVivo)
            {
                Vector3 targetDeEnemigo = posInicial;//Posicion actual del objeto
                discantiaTarget = Vector3.Distance(jugador.transform.position, transform.position);
                if (discantiaTarget < vision || enemigoEnCamino)//Si la distancia entre el jugador y el enemigo es menor que la vision, entonces se dirige a por el jugador
                {
                    animatorGuerrero.SetBool("andar", true);//Empieza a andar             
                    navEnemigo.destination = jugador.transform.position;
                    enemigoEnCamino = true;

                }
                else//Si no esta en el rango de vision del enemigo el jugador, el enemigo se mueve entre los puntos a y b
                {
                    animatorGuerrero.SetBool("andar", false);//Para de andar

                    //IrAunPuntoDeUnObjeto(puntoB.transform);
                }
            }
        }
        else
        {
            //*******Pendiente Revisar (No esta parando las corutinas?, sigue atacando) *******
            Debug.Log("Clase ENemigo parada?");
            StopAllCoroutines();
        }


    }


    private void OnTriggerEnter(Collider other)
    {
      
        /*switch (other.gameObject.tag)
        {
            case "puntoA":
                animatorGuerrero.SetBool("andar", true);
                Debug.Log("Entro!"+other.gameObject.tag);
                IrAunPuntoDeUnObjeto(puntoB.transform);
                break;
            case "puntoB":
                Debug.Log("Entro!" + other.gameObject.tag);
                animatorGuerrero.SetBool("andar", true);
                IrAunPuntoDeUnObjeto(puntoC.transform);
                break;
            case "puntoC":
                Debug.Log("Entro!" + other.gameObject.tag);
                animatorGuerrero.SetBool("andar", true);
                IrAunPuntoDeUnObjeto(puntoD.transform);
                break;
            case "puntoD":
                Debug.Log("Entro!" + other.gameObject.tag);
                animatorGuerrero.SetBool("andar", true);
                IrAunPuntoDeUnObjeto(puntoA.transform);
                break;
        }*/
      
    }

    //Ir a un punto concreto en relacion al transform del objeto destino
    public void IrAunPuntoDeUnObjeto(Transform transformDestino) {
        if (enemigoVivo)
        {
            Debug.Log("IR a puntos!");
            Vector3 targetDeEnemigo;
            targetDeEnemigo = transformDestino.transform.position;//Nuevo target del enemigo
            transform.LookAt(Vector3.MoveTowards(transform.position, transformDestino.transform.position, velocidad * Time.deltaTime));//Lo orientamos hacia el punto
            transform.position = Vector3.MoveTowards(transform.position, targetDeEnemigo, velocidad * Time.deltaTime);//Persigue la posicion del punto
        }

    }
    //Cuando le disparamos u na flecha y colisiona con el le quitamos vida(que no es mas que ocultar cubos)
    private void OnCollisionEnter(Collision collision)
    {
        if (enemigoVivo)
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
                            //Ha muerto
                            animatorGuerrero.SetBool("muerto", true);//Animacion de morir
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
                Destroy(collision.gameObject);              
            }
        }
        else if (!enemigoVivo)
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
                StopCoroutine(Atacar());
                //andamos
                animatorGuerrero.SetBool("atacar", false);//Dejo de atacar
                animatorGuerrero.SetBool("andar", true);//Empieza a andar
            }
           
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "jugador")
        {
                //Atacamos
                //animatorGuerrero.SetBool("andar", false);//Deja de andar
                //animatorGuerrero.SetBool("atacar", true);//Empieza a  atacar
                StartCoroutine(Atacar());           
        }
      
    }

    IEnumerator Atacar()
    {
        if (enemigoVivo)
        {
            animatorGuerrero.SetBool("andar", false);//Deja de andar
            animatorGuerrero.SetBool("atacar", true);//Empieza a  atacar
            if (quitarVida)
            {
                quitarVida = false;
                yield return new WaitForSeconds(1.5F);//esperamos 4 segundos              
                                                      //Enviamos la notificacion a la Script ControlUI, la cual esta asociada al Canvas que tiene un tag UI para que el jugador pueda ver que le quitaron vida
                GameObject.FindWithTag("UI").SendMessage("QuitarVida", 5);
                Debug.Log("Menos 5 de vida");
                quitarVida = true;

            }
        }
   
    }






}
