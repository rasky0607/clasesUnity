using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//añadido
using TMPro;
using System.Threading;

public class movimiento : MonoBehaviour {
    float _velocidad = 3.00F;
    float _posX = 0;
    float _posZ = 0;
    float _posXInicial=0.00F;
    float _posZInicial= 0.00F;
    const float MAX = 4;
    const float MIN = -4;
    public int _vida = 20;
    bool choque = false;
    static int _nIntentos = 0;
    public TextMeshPro _mensaje = null;
    // Use this for initialization
    void Start () {
       
        
        _posXInicial = transform.position.x;
        _posZInicial = transform.position.z;
        //**Pendiente*** transform.position = new Vector3(_posXInicial, transform.position.y, _posZInicial);
        _mensaje.text = "Vida: " + _vida;
        print("||X->" + transform.position.x + " ||Y->" + transform.position.y + " ||Z->" + transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {

        _posX += Input.GetAxis("Vertical") * _velocidad * Time.deltaTime;
        _posZ -= Input.GetAxis("Horizontal") * _velocidad * Time.deltaTime;
        _posX = Mathf.Clamp(_posX, MIN, MAX);
        _posZ = Mathf.Clamp(_posZ, MIN, MAX);

        transform.position = new Vector3(_posX, transform.position.y, _posZ);

        if (_vida <= 0)
         {
            _nIntentos++;
            //Colocamos la esfera en el inicio y restauramos el texto informativo
            _mensaje.text = "Vida: " + _vida;
         _vida = 20;
          //**Pendiente*** Intentar colocar la esfera fuera del laberinto al reiniciar la vida y el empezar la partida
         //transform.position = new Vector3(0.32F, 0.081116F, -4.018F);
        _mensaje.text = "Vida: " + _vida +"<Reinicio de vida!> [Intento:"+_nIntentos+"] ";
         _vida = 20;
         Thread.Sleep(500);
        }
       

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "item")
        {
            if (choque)
            {
                _vida -= 5;
                _mensaje.text = "Vida: " + _vida;
                choque = false;
            }
          
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            choque = true;
        }
    }
    



}
