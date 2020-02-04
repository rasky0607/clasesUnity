using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//añadido para  indicar que es serializable  la estructura ( en este cason o lo añadimos, por que usamos el nombre cualificativo [System.Serializable]

//[ExecuteInEditMode]//ejecuta  solo determinadas partes del scrit
//[HelpURL("www/iesportadaalta.com")] //Redirige ala hora de darle al librito de la ayuda del inspector, en lugar de la url por defecto de unity
//[DisallowMultipleComponent]//Indica que este script es unico, lo que quiere decir que solo se puede arrastrar sobre un mismo GameObject una unica vez, ya que por defecto podemos asignar el mismo script al mismo GameObject  varias veces

//[RequireComponent(typeof(Rigidbody))]//Esta etiqueta exige que el componente al que este asociado este script, tengaun RigiBody

//creacion de structura
[System.Serializable]
 public struct DatosJugador {
    public string _nombre;
    public int _puntos;
    //etc..

}
public class miscript : MonoBehaviour {

    public DatosJugador datos;
    public float Velocidad = 0;
    public string _pulsame = "Pulsame";//Si nos fijamos en el  ispector esta variable no tiene  guion bajo
    [HideInInspector] //Esta etiqueta  oculta sta variable en el inspector a pesar de ser publica, pero podemos acceder a ella desde otros script.
    public GameObject _enemigo;

    [Range(1,5)]//Esta etiqueta indica que esta variable solo puede tener valores entre 0 y 5 y en el inspector a parecera como un barrita, como el value de el slider
    public float numero;
    [Range(1,Mathf.PI)]
    public double _nVidas;

    [Multiline (3)]//esta etiqueta permite aun string, tener hasta 3 lineas en el entorno grafico y el inspector 
    public string _texto = "En un lugar de la mancha";

    [SerializeField]//Permite mostrar en el inspector una variable privada
    private bool _Accion;

    [Tooltip("Representa el tiempo que dura un enemigo")]//toolptip de ayuda para el inspector  para cuando  el nombre de una varaible que vemos en el ispector no es muy descriptivo
    public int _tVDeVidaEnemigo = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
