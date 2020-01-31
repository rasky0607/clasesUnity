using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovimientPala1 : MonoBehaviour {
    //Dejamos un poco de menos marjen  en los limites(en lugar de 5 MAx y -5 Min) para dejar un poco  de marjen en los laterales
    const float MAX = 4;
    const float MIN = -4;
    float _postZ = 0.0F;
    public float _velocidad = 8F;
    public string teclaDerech = null;
    public string teclaIzq = null;
    public TextMeshPro _mensaje = null;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (teclaDerech.Equals(string.Empty) || teclaIzq.Equals(string.Empty))
            _mensaje.text = "Introduce teclas para pala1!";
        else
        {
            _mensaje.text = string.Empty;
            //Teclas asignadas Flechas derecha e izquierda
            _postZ += Input.GetAxis(teclaDerech) * _velocidad * Time.deltaTime;
            _postZ -= Input.GetAxis(teclaIzq) * _velocidad * Time.deltaTime;
            //Controlamos el espacio maxmimo y minimo por donde se puede mover Z
            _postZ = Mathf.Clamp(_postZ, MIN, MAX);
            //cambiamos la posicion de la pala
            transform.position = new Vector3(transform.position.x, transform.position.y, _postZ);
        }
        
    }
}
