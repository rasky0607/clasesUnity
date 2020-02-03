using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cYf : MonoBehaviour {

	public GameObject cilindroNoCinematico;
	public GameObject sphereNoCinematico;
	Rigidbody rbcilindroNoCinematico;
	Rigidbody rbSphereNoCinematico;
	//Fuerzas
	float fuerzaDeEmpuje = 10F;
	//Panel de Ayuda
	public GameObject panel;

	// Use this for initialization
	void Start () {
        //Asginamos los rigiBody de cada objeto
		rbcilindroNoCinematico = cilindroNoCinematico.GetComponent<Rigidbody>();
        rbSphereNoCinematico= sphereNoCinematico.GetComponent<Rigidbody>();
		panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        #region Objetos NO cinematicos
        //Derech
        if (Input.GetKey(KeyCode.D))
		{
			rbcilindroNoCinematico.AddTorque(new Vector3(rbcilindroNoCinematico.transform.position.x, rbcilindroNoCinematico.transform.position.y, rbcilindroNoCinematico.transform.position.z * -fuerzaDeEmpuje), ForceMode.Impulse);
			rbSphereNoCinematico.AddTorque(new Vector3(rbSphereNoCinematico.transform.position.x, rbSphereNoCinematico.transform.position.y, rbSphereNoCinematico.transform.position.z * +fuerzaDeEmpuje), ForceMode.Force);
		}
		//IZq
		if (Input.GetKey(KeyCode.A))
		{
			rbcilindroNoCinematico.AddTorque(new Vector3(rbcilindroNoCinematico.transform.position.x, rbcilindroNoCinematico.transform.position.y, rbcilindroNoCinematico.transform.position.z * fuerzaDeEmpuje), ForceMode.Impulse);
			rbSphereNoCinematico.AddTorque(new Vector3(rbSphereNoCinematico.transform.position.x, rbSphereNoCinematico.transform.position.y, rbSphereNoCinematico.transform.position.z * -fuerzaDeEmpuje), ForceMode.Force);
		}
		//Adelante
		if (Input.GetKey(KeyCode.W)) {
			rbcilindroNoCinematico.AddTorque(new Vector3(rbcilindroNoCinematico.transform.position.x * fuerzaDeEmpuje, rbcilindroNoCinematico.transform.position.y, rbcilindroNoCinematico.transform.position.z), ForceMode.VelocityChange);
			rbSphereNoCinematico.AddTorque(new Vector3(rbSphereNoCinematico.transform.position.x * fuerzaDeEmpuje, rbSphereNoCinematico.transform.position.y, rbSphereNoCinematico.transform.position.z), ForceMode.VelocityChange);
		}
        //Atras
		if (Input.GetKey(KeyCode.S)) {
			rbcilindroNoCinematico.AddTorque(new Vector3(rbcilindroNoCinematico.transform.position.x * -fuerzaDeEmpuje, rbcilindroNoCinematico.transform.position.y, rbcilindroNoCinematico.transform.position.z), ForceMode.Impulse);
			rbSphereNoCinematico.AddTorque(new Vector3(rbSphereNoCinematico.transform.position.x * -fuerzaDeEmpuje, rbSphereNoCinematico.transform.position.y, rbSphereNoCinematico.transform.position.z), ForceMode.Force);
		}
		#endregion

		//Vuelve al menu principal
		if (Input.GetKey(KeyCode.Escape))
			SceneManager.LoadScene("MenuInicial");
            
	}

	public void ClickAyuda() {
		panel.SetActive(true);
    }

    public void ClickAceptar() {
		panel.SetActive(false);
    }
}
