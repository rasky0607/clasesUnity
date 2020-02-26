using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaDiaparada : MonoBehaviour {
    //lanzamiento flecha
    Rigidbody rbFlecha;
    float fuerza = 70F;
    Vector3 fuerzaAdelante;
    float cargaDeFuerza = 10;
    public AudioSource sonidoFlechaDisparada;
    // Use this for initialization
    void Start () {
        sonidoFlechaDisparada.clip = null;
        rbFlecha = gameObject.GetComponent<Rigidbody>();//Recogemos el rigibody de la flecha
        LanzarFlecha();
    }
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 4);
	}

    public void LanzarFlecha()
    {
        sonidoFlechaDisparada.clip = Resources.Load<AudioClip>("Ej11/Sonidos/sonidoFlechaCortado");//Accedemos al recurso que va a reproducirse
        sonidoFlechaDisparada.Play();//Reporducimos sonido
        //Debug.Log("Empujando Flecha! " + gameObject.name);
        fuerzaAdelante = transform.forward * fuerza * Time.deltaTime * cargaDeFuerza;//Cntrl Izq o btn Iz raton, es decir (0)
        rbFlecha.AddForce(fuerzaAdelante, ForceMode.Impulse);
        //rbFlecha.useGravity = true;
    }

}
