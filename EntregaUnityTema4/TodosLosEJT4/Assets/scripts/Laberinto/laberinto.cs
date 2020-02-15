using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class laberinto : MonoBehaviour {

    public float velocidadMov = 10F;
    public float velocidadRotacion = 55F;
    Quaternion orientacionInicial;
    int numCapsulasCogidas = 0;
    public Text textoPuntuacion;
    public GameObject panel;
    Vector3 posJugadorInicial;
    public GameObject capsulaDeMuestra;//Esta capsula sera copiada, para que al reiniciar pueda ser recreada en las posiciones indicadas
    Vector3 posCapsula1;
    Vector3 posCapsula2;
    Vector3 posCapsula3;
    Vector3 posCapsula4;
    public GameObject puerta1;
    public GameObject puerta2;
    public GameObject puerta3;
    public GameObject puerta4;
    public GameObject puerta5;
    public GameObject puerta6;
    //Capsulas de premio
    public GameObject capsula1;
    public GameObject capsula2;
    public GameObject capsula3;
    public GameObject capsula4;
    //Posicion inciial de las puertas
    Vector3 posPuerta1;
    Vector3 posPuerta2;
    Vector3 posPuerta3;
    Vector3 posPuerta4;
    Vector3 posPuerta5;
    Vector3 posPuerta6;
    public float _velocidadRotacion = 2F;
    //Banderas
    bool puerta1abierta = false;
    bool puerta2abierta = false;
    bool puerta3abierta = false;
    bool puerta5abierta = false;
    bool puerta6abierta = false;

    //Texto Fin de juego
    public Text textFinJuego;

    Quaternion orientacionIniciP2;

    // Use this for initialization
    void Start () {
        orientacionInicial = transform.rotation;
        panel.SetActive(false);
        posJugadorInicial = transform.position;
        posCapsula1 = capsula1.transform.position;
        posCapsula2 = capsula2.transform.position;
        posCapsula3 = capsula3.transform.position;
        posCapsula4 = capsula4.transform.position;
        //Posiciones inicial de puertas
        posPuerta1 = puerta1.transform.position;
        posPuerta2 = puerta2.transform.position;
        posPuerta3 = puerta3.transform.position;
        posPuerta5 = puerta5.transform.position;
        textFinJuego.text=" ";
    }
	
	// Update is called once per frame
	void Update () {

        //Movimiento
        transform.Translate(new Vector3( 0,0,Input.GetAxis("Vertical")* velocidadMov * Time.deltaTime));
        transform.Rotate(new Vector3(0,  + Input.GetAxis("Horizontal")* velocidadRotacion * Time.deltaTime,0));

        if (numCapsulasCogidas == 4)
            textFinJuego.text = "Ganaste!, Fin de juego!.";

        //Volver al menu inicial
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("MenuInicial");
         
	}
    //Colocamos el muñeco de pie
    public void Levantarse() {
        transform.SetPositionAndRotation(transform.position, orientacionInicial);
    }

    public void Ayuda() {
        panel.SetActive(true);
    }

    public void Reiniciar() {
        numCapsulasCogidas = 0;
        textoPuntuacion.text = " " + numCapsulasCogidas + " de 4";
        transform.position = posJugadorInicial;
        //faltaria  volver amostrar las capsulas
     
    }

    public void Aceptar() {
        panel.SetActive(false);
    }

    
    private void OnTriggerEnter(Collider other)
    {   
        switch (other.tag)
        {
            case "capsulaPremio":
                numCapsulasCogidas++;
                Debug.Log("COGIDO!");
                textoPuntuacion.text = " " + numCapsulasCogidas + " de 4";
                Destroy(other.gameObject);
                break;
            case "puerta1":
                Debug.Log("DENTRO!");
                Quaternion origen = puerta1.transform.rotation;
                if (puerta1abierta==false)
                {//de origen a destino
                    //puerta1.transform.rotation = Quaternion.Lerp(puerta1.transform.rotation, Quaternion.Euler(0, 90, 0), _velocidadRotacion * Time.deltaTime);
                    Abrir(puerta1);
                    //puerta1abierta = true;
                }
                else if(puerta1abierta==true) {
                    //puerta1.transform.rotation = Quaternion.Lerp(puerta1.transform.rotation, origen, _velocidadRotacion * Time.deltaTime);
                    Cerrar(puerta1);
                    //puerta1abierta = false;
                }
                //puerta1.transform.tran
                break;
            case "puerta2":
                if (!puerta2abierta)
                {
                    puerta2.transform.Translate(0, 2.5F, 0);
                    puerta2abierta = true;
                }
                else if (puerta2abierta)
                {
                    puerta2.transform.Translate(0, -2.5F, 0);
                    puerta2abierta = false;
                }

                break;
            case "puerta3":
                if (!puerta3abierta)
                {
                    puerta3.transform.Translate(0, 2.5F, 0);
                    puerta3abierta = true;
                }
                else if (puerta3abierta)
                {
                    puerta3.transform.Translate(0, -2.5F, 0);
                    puerta3abierta = false;
                }
                //puerta3.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), _velocidadRotacion * Time.deltaTime);
                break;
            case "puerta5":
                if (!puerta5abierta)
                {
                    puerta5.transform.Translate(0, 0, 2.5F);
                    puerta5abierta = true;
                }
                else if (puerta5abierta)
                {
                    puerta5.transform.Translate(0, 0, -2.5F);
                    puerta5abierta = false;
                }
                break;
            case "puerta6":
                if (!puerta6abierta)
                {
                    puerta6.transform.Translate(0, 0, -4);
                    puerta6abierta = true;
                }
                else if (puerta6abierta)
                {
                    puerta6.transform.Translate(-0, 0, 4);
                    puerta6abierta = false;
                }
                //puerta6.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), _velocidadRotacion * Time.deltaTime);
                break;
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {

            case "puerta1":
                Debug.Log("DENTRO!");
                Quaternion origen = puerta1.transform.rotation;
                if (puerta1abierta == false)
                {//de origen a destino
                 //puerta1.transform.rotation = Quaternion.Lerp(puerta1.transform.rotation, Quaternion.Euler(0, 90, 0), _velocidadRotacion * Time.deltaTime);
                    Abrir(puerta1);
                    puerta1abierta = true;
                }
                else if (puerta1abierta == true)
                {
                    //puerta1.transform.rotation = Quaternion.Lerp(puerta1.transform.rotation, origen, _velocidadRotacion * Time.deltaTime);
                    Cerrar(puerta1);
                    puerta1abierta = false;
                }
                //puerta1.transform.tran
                break;
          
        }
    }

    void Abrir(GameObject puerta)
    {

        puerta.transform.rotation = Quaternion.Lerp(puerta.transform.rotation, Quaternion.Euler(0, 90, 0), _velocidadRotacion * Time.deltaTime);
        
    }

    void Cerrar(GameObject puerta)
    {
        puerta.gameObject.transform.rotation = Quaternion.Lerp(puerta.transform.rotation, Quaternion.Euler(0, 0, 0), _velocidadRotacion * Time.deltaTime);
    }
}
