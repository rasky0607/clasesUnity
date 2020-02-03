using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bolaBlanca : MonoBehaviour {

	Rigidbody rb;
	Vector3 raton;
	public LineRenderer linea;
	Vector3 posBolaBlanca;
	Vector3 direccion;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		raton = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
		raton = Input.mousePosition;
		//Debug.DrawRay(transform.position,Input.mousePosition,Color.red);
		Debug.Log("posX " + raton.x + "posY " + raton.y + "posZ " + raton.z);
		//linea.transform.localScale = new Vector3(linea.transform.localScale.x, linea.transform.localScale.y, raton.y);
		
		//transform.rotation= Quaternion.LookRotation(transform.position, Input.mousePosition);
		
		if (Input.GetKeyDown(KeyCode.A))
		{
			//transform.position = new Vector3(transform.position.x +1, transform.position.y, transform.position.z);
            /*NO podemos usar isKinematic por que que entonces no se le puede aplicar fuerza
             Lo que nos facilitaria el trabajo enormemente, por que si conseguimos aplicar fuerza a la bola desde el palo,
             no tendremos que controlar la direccion hacia donde se mueve la bola.
             Sin embargo, quizas si aplicamos el script del pilla pilla entre el objeto bola blanca y el palo al pulsar
             una tecla (teniendo activo el isKinematic puede que n os sirva pra desplazar la bola, segun con la velocidad que movamos el palo*/
        rb.AddForce(-transform.position.x,- transform.position.y, -transform.position.z, ForceMode.Impulse);
		}

		//Si pulsa escape vuelve al menu
		if (Input.GetKey(KeyCode.Escape))
			SceneManager.LoadScene("MenuInicial");

	}

    private void FixedUpdate()
    {
		direccion = new Vector3(Input.mousePosition.x, 0.5F, Input.mousePosition.y);
		posBolaBlanca = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		linea.SetPosition(0,new Vector3(posBolaBlanca.x,linea.GetPosition(0).y,posBolaBlanca.z));
		linea.SetPosition(1,direccion);
		direccion = direccion - posBolaBlanca;
		//transform.LookAt(new Vector3(Input.mousePosition.x, transform.position.y, Input.mousePosition.y));
	}
}
