using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Mueve la esfera Origen a la destino aplicandole una fuerza,a partir de la cual rodara*/
public class moverConFisica : MonoBehaviour {
    //Fuerza para mi es lo mismo que velocidad para Sebas en este ejemplo de fisica.
    public float _velocidad=50F;
    Rigidbody _rigidbody;
    Vector3 _fuerzaDeEmpuje;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}

    /*Metodo usado en los ejercicios de Fisica, en lugar del Update, ya que este se jecuta por cada ciclo sin necesidad de usar Time.DeltaTime().
     Aun que de igual modo podemos  multiplicar por Time.DeltaTime, por si queremos que la velocidad aun sea menor)*/
    void FixedUpdate()
    {
        //Un  valor que devuelve entre 1 y -1 multiplicado porla velocidad.
        _fuerzaDeEmpuje = new Vector3(Input.GetAxis("Horizontal")*_velocidad*Time.deltaTime,0, Input.GetAxis("Vertical") * _velocidad*Time.deltaTime);
        //aplicamos la fuerza
        _rigidbody.AddForce(_fuerzaDeEmpuje);
        //_rigidbody.freezeRotation = true; //para evitar que la bola rozer(para esto debemos quitar el Time.deltaTime, por que si no va excesivamente lento
    }

    // Update is called once per frame
    void Update () {
		
	}
  
}
