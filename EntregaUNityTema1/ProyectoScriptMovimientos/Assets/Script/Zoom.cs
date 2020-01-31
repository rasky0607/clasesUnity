using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

    //Valor cuando pulso la tecla(segun si se pulsa o  no)
    float valorZoom = 0;
    float incrementoZoom = 0.5F;//Valor que incrementara el tamaño del objeto

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {  
        valorZoom = Input.GetAxis("zoom");
        //Zoom Completo:
        //Aumentando la scale en todas sus variables a la vez, tanto x y como z
        /*pero esto por desgracia por defecto depende de los frame
         * y eso  hace depender mucho la velocidad de el aumento segun el pc donde se ejecuta
         */
        //transform.localScale += new Vector3(incrementoZoom*valorZoom,incrementoZoom*valorZoom,incrementoZoom*valorZoom);

        //Forma basada en el tiempo para evitar el problema d elos Fragme usando la clase Time con la propiedad deltaTime Time.deltaTime
        transform.localScale += new Vector3(incrementoZoom * valorZoom *Time.deltaTime, incrementoZoom * valorZoom * Time.deltaTime, incrementoZoom * valorZoom * Time.deltaTime);


    }
}
