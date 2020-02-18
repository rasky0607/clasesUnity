using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaAnimaDisparo : MonoBehaviour {

    //Animacion flecha
    /*Flecha animada solo realiza la accion pero no se mueve, la flecha  instanciada prefabFlecha es la que se lanza */
    Animator cargaFlecha;

    //Flecha disparada
   public GameObject prefabFlecha;//Objeto prefab que vamos a clonar en la misma posicion que el objeto flechaAnimada que a pesar de tener el mismo aspecto tiene distinta funcionalidad                           
    //Instanciamiento de la flecha
    Vector3 posOriginal;
    Quaternion rotacionOriginal;

 
    // Use this for initialization
    void Start () {

        cargaFlecha = GetComponent<Animator>();
        posOriginal = gameObject.transform.position;
        rotacionOriginal = gameObject.transform.rotation;
       
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))//Mientras estra presionado  el click Izq del raton
        {
            StartCoroutine(EsperaRecarga());//Comenzamos la animacion ce cargarla flecha hacia atras
        }
        if (Input.GetMouseButtonUp(0)) {//Cuando se suelta el boton IZq del raton, terminamos la animacion hacia delante y lanzamos la flecha
            cargaFlecha.SetBool("Cargando", false);//"Cargando" es el boleano del control de animacion ControlAnimacionFlecha         
            StartCoroutine(CrearFlechaClonada());
           
        }  
            
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

    IEnumerator CrearFlechaClonada() {     
        posOriginal = gameObject.transform.position;
        rotacionOriginal = gameObject.transform.rotation;      
        Instantiate(prefabFlecha, posOriginal, rotacionOriginal);//Instanciamos flecha clonada enla posicion del padre      
        yield return new WaitForSeconds(3F);
    }

}
