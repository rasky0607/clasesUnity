using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaAnimaDisparo : MonoBehaviour {

    //Script asginado a la flechaAnimada 
    /*Flecha animada solo realiza la animacion de cargar disparo moviendo la flecha hacia atras, pero no se mueve, la flecha  instanciada prefabFlecha es la que se lanza */
    Animator cargaFlecha;

    //Flecha disparada
   public GameObject prefabFlecha;//Objeto prefab que vamos a clonar en la misma posicion que el objeto flechaAnimada que a pesar de tener el mismo aspecto tiene distinta funcionalidad                           
    //Instanciamiento de la flecha
    Vector3 posOriginal;
    Quaternion rotacionOriginal;
    MeshRenderer mrFlechaAnimada;

    //Municion
    int numMunicion;
    //Estado del juego Pausado/Reanudado
    bool juegoEnPausa = false;

    //Corrutinas recogidas
    Coroutine coruCrearFlechas;
    Coroutine coruEsperarRecaga;

    // Use this for initialization
    void Start () {

        cargaFlecha = GetComponent<Animator>();
        posOriginal = gameObject.transform.position;
        rotacionOriginal = gameObject.transform.rotation;
        mrFlechaAnimada = gameObject.GetComponent<MeshRenderer>();
        //Activamos MesRender de la flecha animada mostrandola
        mrFlechaAnimada.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!juegoEnPausa)//Si juego en pausa es distintod e verdad o sea , no esta en pausa
        {        
            if (numMunicion>0)
            {
                //Activamos MesRender de la flecha animada mostrandola
                mrFlechaAnimada.enabled = true;
                if (Input.GetMouseButtonDown(0))//Mientras estra presionado  el click Izq del raton
                {
                  coruEsperarRecaga =StartCoroutine(EsperaRecarga());//Comenzamos la animacion ce cargarla flecha hacia atras
                }
                if (Input.GetMouseButtonUp(0))
                {//Cuando se suelta el boton IZq del raton, terminamos la animacion hacia delante y lanzamos la flecha
                    cargaFlecha.SetBool("Cargando", false);//"Cargando" es el boleano del control de animacion ControlAnimacionFlecha         
                    coruCrearFlechas= StartCoroutine(CrearFlechaClonada());//Creamos la flecha clonada que va ser disparada, esta flecha disparada tiene su propio script para los disparos
                }
            }
            else
            {
                //Desactivamos MesRender de la flecha animada ocultandola
                mrFlechaAnimada.enabled = false;
                StopCoroutine(coruCrearFlechas);//Paramos la corutina
                StopCoroutine(coruEsperarRecaga);//Paramos la corutina
            }
        }
            
	}

    //PReguntamos si el arco tiene municion atrvés de un mensaje enviado desde la clase ControlUI
    public void TieneMunicion(int numMunicion) {
        this.numMunicion = numMunicion;     
    }

    //Este metodo recibe un mensaje de la clase ControlUI cuando se ha modificado la variable JuegoPausado, indicando si esta en pausa o reanudado
    public void PausarOReanudadJuego(bool estado)
    {
        juegoEnPausa = estado;
    }


    /**Esta Corutina realiza la animacion de carga de  un disparo de flecha
     y una vez iniciada, desactiva el animator para poder lanzar la flecha al soltar el boton del raton*/
    IEnumerator EsperaRecarga()
    {     
        cargaFlecha.enabled = true;//Activamos animator
        cargaFlecha.SetBool("Cargando", true);
        yield return new WaitForSeconds(1F);
        //cargaFlecha.SetBool("Cargando", false);
        cargaFlecha.enabled = false;//Desactivamos animator
    }

    //Instancia una nueva flecha, a la cual se le aplica una fuerza
    IEnumerator CrearFlechaClonada() {     
        posOriginal = gameObject.transform.position;
        rotacionOriginal = gameObject.transform.rotation;      
        GameObject flechaClonada= Instantiate(prefabFlecha, posOriginal, rotacionOriginal);//Instanciamos flecha clonada enla posicion del padre 
        //Enviamos un mensaje a el metodo DescontarFlecha de el Scrit UI uan vez lanzamos una flecha
        GameObject.FindWithTag("UI").SendMessage("DescontarMunicion");
        flechaClonada.GetComponent<Rigidbody>().useGravity = true;//Activamos la gravedad de la flecha
        yield return new WaitForSeconds(3F);//esperamos 3 segundos
    }

}
