using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//añadido
using TMPro;
/*Se añade este script a la esfera llamado jugador*/
public class mover : MonoBehaviour {

    //como lo vamos  a mover con fisica
    public float _fuerza=30F;
    Rigidbody _rigidbody;
    public TextMeshPro _mensaje;
    public float _magnitud;

    //para el Salto
    public float _fuerzaSalto = 10F;
    //para evitar que no salte cuando esta en el aire
    float _umbralDelSalto = 0.01F;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {


        /*SALTO:
         * Esto tambien podria estar En FixeUpdate() sin problema*/
        if (Mathf.Abs(_rigidbody.velocity.y) < _umbralDelSalto)//para evitar que no salte cuando esta en el aire
            if (Input.GetButtonDown("Jump"))
            _rigidbody.AddForce(Vector3.up * _fuerzaSalto,ForceMode.Impulse);//Vector3.up, por que vamos amodificarlo en la cordenada Y para realizar el salto
    }


    void FixeUpdate() {
        _rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal") * _fuerza, 0, Input.GetAxis("Vertical") * _fuerza), ForceMode.Force);
        
    }

    void OnCollisionEnter(Collision other) {

        _magnitud = other.relativeVelocity.magnitude;//Recogemos la magnitud del impacto y apartir de esto podemos decidir si el objeto muere o no.
        if (other.collider.tag == "enemigo" && _magnitud >=2)
        {
            Destroy(other.gameObject, 1);     
            _mensaje.text = _magnitud.ToString();
        }
        else
            _mensaje.text = other.collider.name + ",Detectado enemmigo.";

    }

    void OnCollisionExit(Collision other)
    {
      
           
        if (other.collider.tag == "enemigo")
            Destroy(other.gameObject, 1);
        else
            _mensaje.text = other.collider.name + ",Detectado enemmigo.";
    }
}
