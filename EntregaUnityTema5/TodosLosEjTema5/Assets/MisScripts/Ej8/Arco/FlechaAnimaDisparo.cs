using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaAnimaDisparo : MonoBehaviour {

    //lanzamiento flecha
    Rigidbody rbFlecha;
    float fuerza=20F;
    Vector3 fuerzaAdelante;
    Animator cargaFlecha;
    float cargaDeFuerza = 1;

    //Flecha disparada
   public GameObject prefabFlecha;//Objeto prefab que vamos a clonar en la misma posicion que el objeto flechaAnimada que a pesar de tener el mismo aspecto tiene distinta funcionalidad
    /*Flecha animada solo realiza la accion pero no se mueve, la flecha  instanciada prefabFlecha es la que se lanza */
    Rigidbody rbFlechaClonada;
  

    // Use this for initialization
	void Start () {

        rbFlecha = GetComponent<Rigidbody>();
        cargaFlecha = GetComponent<Animator>();
      
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))//Mientras estra presionado  el click Izq del raton
        {
            StartCoroutine(EsperaRecarga());//Comenzamos la animacion ce cargarla flecha hacia atras
        }
        if (Input.GetMouseButtonUp(0)) {//Cuando se suelta el boton IZq del raton, terminamos la animacion hacia delante y lanzamos la flecha
            cargaFlecha.SetBool("Cargando", false);//"Cargando" es el boleano del control de animacion ControlAnimacionFlecha
            LanzarFlecha();
            //rbFlecha.useGravity = true;
            Instantiate(prefabFlecha, gameObject.transform.position, gameObject.transform.rotation);//Instanciamos flecha clonada enla posicion del padre
        }  
            
	}

    /**Esta Corutina realiza la animacion de carga de  un disparo de flecha
     y una vez iniciada, desactiva el animator para poder lanzar la flecha al soltar el boton del raton*/
     IEnumerator EsperaRecarga()
    {     
        cargaFlecha.enabled = true;//Desactivamos animator
        cargaFlecha.SetBool("Cargando", true);
        yield return new WaitForSeconds(1F);
        //cargaFlecha.SetBool("Cargando", false);
        cargaFlecha.enabled = false;//Desactivamos animator
    }
    /*Este metodo aplica fuerza ala flecha que vamos a lanzar*/
    public void LanzarFlecha() {

      
     
    }
}
