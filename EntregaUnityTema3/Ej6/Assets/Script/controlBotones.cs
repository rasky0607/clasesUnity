using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Asignado a la nave
public class controlBotones : MonoBehaviour {

    float _velocidad = 5F; //Movimiento en X e Y
    float _velocidadZoom = 0.25F;

    //Variables para los movimeintos
    bool arriba = false;
    bool abajo = false;
    bool izquierda = false;
    bool derecha = false;
    bool aumentar = false;
    bool disminuir = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (derecha)
            transform.Translate(Vector3.right*Time.deltaTime*_velocidad);
        if (izquierda)
            transform.Translate(Vector3.left * Time.deltaTime * _velocidad);
        if (arriba)
            transform.Translate(Vector3.up * Time.deltaTime * _velocidad);
        if (abajo)
            transform.Translate(Vector3.down * Time.deltaTime * _velocidad);

        if (aumentar)
            transform.localScale = new Vector3(transform.localScale.x + _velocidadZoom * Time.deltaTime, transform.localScale.y + _velocidadZoom * Time.deltaTime, transform.localScale.z + _velocidadZoom * Time.deltaTime);

        if (disminuir)
            transform.localScale = new Vector3(transform.localScale.x - _velocidadZoom * Time.deltaTime, transform.localScale.y - _velocidadZoom * Time.deltaTime, transform.localScale.z - _velocidadZoom * Time.deltaTime);

        //Salir de aplicación
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

    }

    //Metodos para el control del movimiento y Zoom
    public void MoverDerecha() {
        derecha = true;
    }
    public void MoverIzq()
    {
        izquierda = true;
    }
    public void MoverArriba()
    {
        arriba = true;
    }
    public void MoverAbajo()
    {
        abajo = true;
    }
    public void AumentarEscala()
    {
        aumentar = true;
        Debug.Log(transform.localScale);
    }
    public void DisminuirEscala()
    {
        disminuir = true;
    }

    //Metodo que detiene todo
    public void DetenerTodo()
    {
         arriba = false;
         abajo = false;
         izquierda = false;
         derecha = false;
         aumentar = false;
         disminuir = false;
    }
}
